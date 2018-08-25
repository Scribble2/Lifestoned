using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Enums;

namespace DerethForever.Web
{
    public class DatabaseAuthProvider : DatabaseProviderBase, IAuthProvider
    {
        public LoginResult Authenticate(string username, string password)
        {
            HttpStatusCode resultStatus = HttpStatusCode.Unauthorized;
            string resultToken = null;

            using (DbConnection connection = GetConnection())
            {
                var result = connection.Query<AccountModel>(
                    "SELECT * FROM account WHERE accountName = @name;",
                    new { name = username }).FirstOrDefault();

                if (string.Compare(result.Name, username, true) == 0)
                {
                    // compare the password
                    string hashedPassword = HashPassword(password, result.PasswordSalt);

                    if (string.Compare(result.PasswordHash, hashedPassword) == 0)
                    {
                        // password correct
                        resultStatus = HttpStatusCode.OK;

                        // fetch subscription / roles
                        var role = connection.Query<SubscriptionModel>(
                            "SELECT * FROM subscription WHERE accountGuid = @gid;",
                            new { gid = result.Gid.ToByteArray() }).FirstOrDefault();

                        List<string> roles = new List<string>();
                        foreach (AccessLevel level in Enum.GetValues(typeof(AccessLevel)))
                        {
                            if ((int)role.AccessLevel >= (int)level)
                                roles.Add(level.ToString());
                        }

                        // token
                        resultToken = CreateFakeToken(
                            result.Gid,
                            result.Id,
                            result.Name,
                            result.DisplayName,
                            roles.ToArray());
                    }
                }
            }

            return new LoginResult()
            {
                StatusCode = resultStatus,
                Token = resultToken
            };
        }

        public ApiAccountModel GetAccount(string token, string accountGuid)
        {
            if (string.IsNullOrEmpty(accountGuid))
                accountGuid = JwtCookieManager.GetUserGuid(token);

            using (DbConnection connection = GetConnection())
            {
                using (var result = connection.QueryMultiple(
                    "SELECT * FROM account WHERE accountGuid = @gid; SELECT * FROM managed_world WHERE accountGuid = @gid;",
                    new { gid = Guid.Parse(accountGuid).ToByteArray() }))
                {
                    AccountModel account = result.ReadSingle<AccountModel>();
                    List<ManagedServerModel> servers = result.Read<ManagedServerModel>().ToList();

                    return new ApiAccountModel()
                    {
                        AccountGuid = account.Gid.ToString(),
                        Name = account.Name,
                        DisplayName = account.DisplayName,
                        Email = account.Email,
                        ManagedWorlds = servers
                    };
                }
            }
        }

        public List<ApiAccountModel> GetAccounts(string token)
        {
            using (DbConnection connection = GetConnection())
            {
                var results = connection.Query<AccountModel>("SELECT * FROM account;");

                return results.Select((account) => new ApiAccountModel()
                {
                    AccountGuid = account.Gid.ToString(),
                    Name = account.Name,
                    DisplayName = account.DisplayName,
                    Email = account.Email
                }).ToList();
            }
        }

        public bool Register(RegisterModel model)
        {
            try
            {
                using (DbConnection connection = GetConnection())
                {
                    Guid gid = Guid.NewGuid();
                    string salt = GenerateSalt();
                    string hashedPassword = HashPassword(model.Password, salt);

                    var id = connection.Query(
                        "INSERT INTO account (accountGuid, accountName, displayName, email, passwordHash, passwordSalt) VALUES (@gid, @account, @name, @email, @hash, @salt); SELECT accountId FROM account WHERE accountGuid = @gid",
                        new
                        {
                            gid = gid.ToByteArray(),
                            account = model.Username,
                            name = model.DisplayName,
                            email = model.Email,
                            hash = hashedPassword,
                            salt = salt
                        }).Single();

                    connection.Execute(
                        "INSERT INTO subscription (subscriptionGuid, accountGuid, subscriptionName, accessLevel) VALUES (@sgid, @agid, 'default', 0);",
                        new { sgid = Guid.NewGuid().ToByteArray(), agid = gid.ToByteArray() });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateAccount(string token, ApiAccountModel model)
        {
            throw new NotImplementedException();
        }

        private static string HashPassword(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] buffer = passwordBytes.Concat(saltBytes).ToArray();
            byte[] hash;

            // rehash it
            using (SHA512Managed hasher = new SHA512Managed())
            {
                hash = hasher.ComputeHash(buffer);
            }

            return Convert.ToBase64String(hash);
        }

        private static string GenerateSalt()
        {
            byte[] salt = new byte[64]; // 64 bytes = 512 bits, ideal for use with SHA512
            using (var salter = new RNGCryptoServiceProvider())
            {
                salter.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private static string CreateFakeToken(Guid gid, uint id, string name, string display, string[] roles)
        {
            long issue = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            JObject token = new JObject();
            token.Add("exp", issue + 1800); // 30 minutes
            token.Add("nbf", issue);
            token.Add("nameid", gid.ToString());
            token.Add("account_id", id);
            token.Add("unique_name", name);
            token.Add("display_name", display);
            token.Add("role", JToken.FromObject(roles));

            return string.Format("{0}.{1}.{2}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("{ \"alg\":\"NONE\",\"typ\":\"JWT\" }")),
                Convert.ToBase64String(Encoding.UTF8.GetBytes(token.ToString(Formatting.None))),
                null);
        }
    }
}