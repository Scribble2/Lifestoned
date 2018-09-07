using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Enums;
using log4net;
using Newtonsoft.Json;

namespace DerethForever.Web.Providers
{
    public class LocalAuthProvider : IAuthProvider
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string LocalAuthFilename = "LifestonedAuth.json";
        private string _localPath;

        // normally, we would make these static, but the implementation is with a singleton so it's not 
        // necessary.  making them instance variables should (if ever useful) allow for concurrent auth providers
        private volatile List<LocalAccount> _accountCache;
        private volatile uint _nextAccountId = 1;
        private volatile uint _nextSubId = 1;
        private object _locker = new object();

        /// <summary>
        /// due to the nature of the dynamic provider selection, all initialization must
        /// be done in the default constructor
        /// </summary>
        public LocalAuthProvider()
        {
            var configPath = ConfigurationManager.AppSettings["LocalAuthProviderDir"];

            if (string.IsNullOrWhiteSpace(configPath) || !Directory.Exists(configPath))
                throw new ConfigurationErrorsException("LocalAuthProviderDir app setting is missing or invalid.");

            _localPath = Path.Combine(_localPath, LocalAuthFilename);

            lock (_locker)
            {
                LoadCache();
            }
        }

        public LoginResult Authenticate(string username, string password)
        {
            var account = _accountCache.FirstOrDefault(a => a.Username.ToLower() == username.ToLower());

            if (account?.PasswordMatches(password) == true)
            {
                string token = JwtCookieManager.CreateToken(account.AccountGuid, account.Id, account.Username, account.DisplayName, account.GetRoles());
                return new LoginResult() { StatusCode = System.Net.HttpStatusCode.OK, Token = token };
            }

            return new LoginResult() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public ApiAccountModel GetAccount(string token, string accountGuid)
        {
            var account = GetAccount(token);

            if (account == null)
                return null;
            Guid result;

            // envoys can get any account
            if (account.AccessLevel >= AccessLevel.Envoy && Guid.TryParse(accountGuid, out result))
                return _accountCache.FirstOrDefault(a => a.AccountGuid == result)?.ToApiAccountModel();

            // anyone can get their own account
            if (account.AccountGuid.ToString().ToLower() == accountGuid.ToLower())
                return account.ToApiAccountModel();

            return null;
        }

        public List<ApiAccountModel> GetAccounts(string token)
        {
            var account = GetAccount(token);

            // getting accounts requires at least Envoy access   
            if ((account?.AccessLevel ?? AccessLevel.Player) < AccessLevel.Envoy)
                return new List<ApiAccountModel>();

            return _accountCache.Select(a => a.ToApiAccountModel()).ToList();
        }

        public List<SubscriptionModel> GetSubscriptions(string token, string accountGuid)
        {
            List<SubscriptionModel> subs = new List<SubscriptionModel>();

            var account = GetAccount(token);

            if (account == null)
                return subs;

            Guid result;
            if (Guid.TryParse(accountGuid, out result))
            {
                if (account.AccessLevel >= AccessLevel.Envoy)
                    subs.Add(_accountCache.FirstOrDefault(a => a.AccountGuid == result)?.ToSubscriptionModel());
                else if (account.AccountGuid == result)
                    subs.Add(account.ToSubscriptionModel());
            }

            return subs;
        }

        public bool Register(RegisterModel model)
        {
            lock (_locker)
            {
                if (_accountCache.Any(a => a.Username.ToLower() == model.Username.ToLower() || a.Email.ToLower() == model.Email.ToLower()))
                    throw new ArgumentException("A user with that name or email already exists.");

                var account = LocalAccount.CreateNewAccount();
                account.AccessLevel = AccessLevel.Player;
                account.DisplayName = model.DisplayName;
                account.Username = model.Username;
                account.Email = model.Email;
                account.SetPassword(model.Password);

                account.Id = _nextAccountId;
                _nextAccountId++;

                account.SubscriptionId = _nextSubId;
                _nextSubId++;

                _accountCache.Add(account);
                SaveCache();
            }

            return true;
        }

        public void UpdateAccount(string token, ApiAccountModel model)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(model?.AccountGuid))
                return;

            var account = GetAccount(token);

            if (account == null)
                return;

            Guid accountGuid;

            if (!Guid.TryParse(model.AccountGuid, out accountGuid))
                return;

            if (accountGuid == account.AccountGuid || account.AccessLevel >= AccessLevel.Developer)
            {
                lock (_locker)
                {
                    var editedAccount = _accountCache.FirstOrDefault(la => la.AccountGuid == accountGuid);
                    if (editedAccount == null)
                        return;

                    bool dirty = false;

                    if (!string.IsNullOrWhiteSpace(model.DisplayName))
                    {
                        dirty = true;
                        editedAccount.DisplayName = model.DisplayName;
                    }

                    if (!string.IsNullOrWhiteSpace(model.Email))
                    {
                        dirty = true;
                        editedAccount.Email = model.Email;
                    }

                    if (dirty)
                        SaveCache();
                }
            }
        }

        public bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(subscriptionGuid))
                return false;

            var account = GetAccount(token);

            if (account == null)
                return false;

            Guid subGuid;
            if (!Guid.TryParse(subscriptionGuid, out subGuid))
                return false;

            lock (_locker)
            {
                var editedAccount = _accountCache.FirstOrDefault(la => la.SubscriptionGuid == subGuid);
                editedAccount.AccessLevel = (AccessLevel)newPermissions;

                SaveCache();
            }

            return true;
        }

        private LocalAccount GetAccount(string token)
        {
            try
            {
                var accountGuidString = JwtCookieManager.GetUserGuid(token);
                Guid accountGuid;

                if (!Guid.TryParse(accountGuidString, out accountGuid))
                    return null;

                return _accountCache.FirstOrDefault(la => la.AccountGuid == accountGuid);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// requires a lock to already be established
        /// </summary>
        private void SaveCache()
        {
            var content = JsonConvert.SerializeObject(_accountCache);
            File.WriteAllText(_localPath, content);
        }

        /// <summary>
        /// requires a lock to already be established
        /// </summary>
        private void LoadCache()
        {
            var content = File.ReadAllText(_localPath);
            _accountCache = JsonConvert.DeserializeObject<List<LocalAccount>>(content);
        }
    }
}