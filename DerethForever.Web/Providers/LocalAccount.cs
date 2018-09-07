using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Providers
{
    public class LocalAccount
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("accountGuid")]
        public Guid AccountGuid { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("passwordSalt")]
        public string PasswordSalt { get; set; }

        [JsonIgnore]
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Player;

        [JsonProperty("accessLevel")]
        public uint AccessLevel_Binder
        {
            get { return (uint)AccessLevel; }
            set { AccessLevel = (AccessLevel)value; }
        }

        [JsonProperty("subscriptionGuid")]
        public Guid SubscriptionGuid { get; set; }

        [JsonProperty("subscriptionId")]
        public uint SubscriptionId { get; set; }

        public void SetPassword(string password)
        {
            PasswordHash = GetPasswordHash(password, PasswordSalt);
        }

        public ApiAccountModel ToApiAccountModel()
        {
            ApiAccountModel apiModel = new ApiAccountModel()
            {
                AccountGuid = AccountGuid.ToString(),
                DisplayName = DisplayName,
                Email = Email,
                Name = Username
            };

            return apiModel;
        }

        public SubscriptionModel ToSubscriptionModel()
        {
            SubscriptionModel sm = new SubscriptionModel()
            {
                AccessLevel_Binder = AccessLevel,
                AccountGuid = AccountGuid,
                Name = "Default Subscription",
                SubscriptionId = SubscriptionId,
                SubscriptionGuid = SubscriptionGuid
            };
            return sm;
        }

        public bool PasswordMatches(string password)
        {
            var input = GetPasswordHash(password, PasswordSalt);
            return input == PasswordHash;
        }

        public string[] GetRoles()
        {
            var roles = new List<string>();
            foreach (AccessLevel level in Enum.GetValues(typeof(AccessLevel)))
                if (AccessLevel >= level)
                    roles.Add(level.ToString());
            return roles.ToArray();
        }

        private static string GetPasswordHash(string password, string salt)
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

        public static LocalAccount CreateNewAccount()
        {
            LocalAccount account = new LocalAccount();
            account.AccountGuid = Guid.NewGuid();
            account.SubscriptionGuid = Guid.NewGuid();
            account.PasswordSalt = GenerateSalt();
            return account;
        }
    }
}