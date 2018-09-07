using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lifestoned.DataModel.Account;
using Lifestoned.DataModel.Shared;

namespace DerethForever.Web.Providers
{
    public class DummyAuthProvider : IAuthProvider
    {
        private const string accountId = "87101398-7BF4-47D1-A445-E19132075919";
        private const string subId = "37EC111C-E3C5-449A-BD5D-E31D6B028112";
        private List<string> roles;

        public DummyAuthProvider()
        {
            roles = new List<string>();
            foreach (AccessLevel level in Enum.GetValues(typeof(AccessLevel)))
                roles.Add(level.ToString());
        }

        private ApiAccountModel me = new ApiAccountModel()
        {
            AccountGuid = accountId,
            DisplayName = "Behemoth",
            Email = "behemothoftenkarrdun@gmail.com",
            Name = "Behemoth"
        };

        private SubscriptionModel mySub = new SubscriptionModel()
        {
            AccountGuid = Guid.Parse(accountId),
            Name = "Behemoth's Sub",
            SubscriptionGuid = Guid.Parse(subId),
            SubscriptionId = 1,
            AccessLevel = 5
        };

        public LoginResult Authenticate(string username, string password)
        {
            return new LoginResult()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Token = JwtCookieManager.CreateToken(Guid.Parse(me.AccountGuid), 1, me.Name, me.DisplayName, roles.ToArray())
                };
        }

        public ApiAccountModel GetAccount(string token, string accountGuid)
        {
            return me;
        }

        public List<ApiAccountModel> GetAccounts(string token)
        {
            return new List<ApiAccountModel>() { me };
        }

        public List<SubscriptionModel> GetSubscriptions(string token, string accountGuid)
        {
            if (accountGuid == accountId)
                return new List<SubscriptionModel>() { mySub };

            return new List<SubscriptionModel>();
        }

        public bool Register(RegisterModel model)
        {
            return true;
        }

        public void UpdateAccount(string token, ApiAccountModel model)
        {
        }

        public bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions)
        {
            return true;
        }
    }
}