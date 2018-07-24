/*****************************************************************************************
Copyright 2018 Dereth Forever

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Net;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Content;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Models.WorldRelease;
using DerethForever.Web.Models.Weenie;

namespace DerethForever.Web
{
    public interface IContentProvider
    {
        List<Content> GetAllContent(string token);

        Content GetContent(string token, Guid contentGuid);

        HttpStatusCode UpdateContent(string token, Content content);

        List<WeenieSearchResult> WeenieSearch(string token, SearchWeeniesCriteria criteria);

        List<WeenieSearchResult> RecentChanges(string token);

        Weenie GetWeenie(string token, uint weenieClassId);

        bool UpdateWeenie(string token, Weenie weenie);

        bool CreateWeenie(string token, Weenie weenie);

        bool DeleteWeenie(string token, uint weenieClassId);

        byte[] GetFullyLayeredPngIcon(uint weenieClassId);

        byte[] GetWorldRelease(string token, string fileName);

        byte[] GetCurrentWorldRelease(string token);

        WorldRelease GetCurrentWorldReleaseInfo(string token);

        WorldRelease GetWorldReleaseInfo(string token, string fileName);

        WorldRelease CutWorldRelease(string token, ReleaseType releaseType);

        List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria);

        Recipe GetRecipe(string token, Guid recipeGuid);

        bool UpdateRecipe(string token, Recipe recipe);

        List<SubscriptionModel> GetSubscriptions(string token, string accountGuid);

        /// <summary>
        /// using the token provided, attempts to update the permissions of the specified
        /// subscription.  provider will validate the token's permissions accordingly.
        /// </summary>
        bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions);
    }
}
