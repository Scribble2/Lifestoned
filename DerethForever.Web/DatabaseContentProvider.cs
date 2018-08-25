using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Web;
using Dapper;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Content;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Models.Weenie;
using DerethForever.Web.Models.WorldRelease;

namespace DerethForever.Web
{
    public class DatabaseContentProvider : DatabaseProviderBase, IContentProvider
    {
        public bool CreateWeenie(string token, Weenie weenie)
        {
            throw new NotImplementedException();
        }

        public WorldRelease CutWorldRelease(string token, ReleaseType releaseType)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWeenie(string token, uint weenieClassId)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAllContent(string token)
        {
            throw new NotImplementedException();
        }

        public Content GetContent(string token, Guid contentGuid)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCurrentWorldRelease(string token)
        {
            throw new NotImplementedException();
        }

        public WorldRelease GetCurrentWorldReleaseInfo(string token)
        {
            throw new NotImplementedException();
        }

        public byte[] GetFullyLayeredPngIcon(uint weenieClassId)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(string token, Guid recipeGuid)
        {
            throw new NotImplementedException();
        }

        public List<SubscriptionModel> GetSubscriptions(string token, string accountGuid)
        {
            using (DbConnection connection = GetConnection())
            {
                return connection.Query<SubscriptionModel>(
                    "SELECT * FROM subscription WHERE accountGuid = @gid",
                    new { gid = Guid.Parse(accountGuid).ToByteArray() }).ToList();
            }
        }

        public Weenie GetWeenie(string token, uint weenieClassId)
        {
            throw new NotImplementedException();
        }

        public byte[] GetWorldRelease(string token, string fileName)
        {
            throw new NotImplementedException();
        }

        public WorldRelease GetWorldReleaseInfo(string token, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<WeenieSearchResult> RecentChanges(string token)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode UpdateContent(string token, Content content)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions)
        {
            try
            {
                using (DbConnection connection = GetConnection())
                {
                    connection.Execute(
                        "UPDATE subscription SET accessLevel = @level WHERE subscriptionGuid = @gid",
                        new { gid = Guid.Parse(subscriptionGuid).ToByteArray(), level = newPermissions });
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateRecipe(string token, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWeenie(string token, Weenie weenie)
        {
            throw new NotImplementedException();
        }

        public List<WeenieSearchResult> WeenieSearch(string token, SearchWeeniesCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}