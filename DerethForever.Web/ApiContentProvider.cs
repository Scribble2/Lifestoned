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
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.Content;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Models.WorldRelease;
using DerethForever.Web.Models.Weenie;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;

namespace DerethForever.Web
{
    public class ApiContentProvider : IContentProvider
    {
        private readonly RestClient _client;

        public ApiContentProvider(string endpoint)
        {
            _client = new RestClient(endpoint);
        }

        private RestRequest BuildRequest(string endpoint, Method method, string authToken = null)
        {
            RestRequest request = new RestRequest(endpoint, method);
            request.JsonSerializer = new NonSuckyJsonSerializer();

            if (!string.IsNullOrWhiteSpace(authToken))
                request.AddHeader("Authorization", "Bearer " + authToken);

            return request;
        }

        public List<Content> GetAllContent(string token)
        {
            RestRequest request = BuildRequest("/Content/GetAll", Method.GET, token);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<Content>>(response.Content);

            throw new ApplicationException("Unable to retreive Content from server", response.ErrorException);
        }

        public Content GetContent(string token, Guid contentGuid)
        {
            throw new NotImplementedException();

            // var request = BuildRequest("/Content/Get/" + contentGuid.ToString(), Method.GET, token);
            // var response = _client.Execute(request);

            // if (response.StatusCode == HttpStatusCode.OK)
            //    return JsonConvert.DeserializeObject<Content>(response.Content);
            // if (response.StatusCode == HttpStatusCode.NotFound)
            //    return null;

            // throw new ApplicationException("Unable to retreive Content from server", response.ErrorException);
        }

        public HttpStatusCode UpdateContent(string token, Content content)
        {
            RestRequest request = BuildRequest("/Content/Update", Method.POST, token);
            request.AddJsonBody(content);
            IRestResponse response = _client.Execute(request);
            return response.StatusCode;
        }

        public List<WeenieSearchResult> WeenieSearch(string token, SearchWeeniesCriteria criteria)
        {
            RestRequest request = BuildRequest("/Weenie/Search", Method.POST, token);
            request.AddJsonBody(criteria);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<WeenieSearchResult>>(response.Content);

            throw new ApplicationException("Unable to search for weenies from server: " + response.Content, response.ErrorException);
        }

        public List<WeenieSearchResult> RecentChanges(string token)
        {
            RestRequest request = BuildRequest("/Weenie/Recent", Method.GET, token);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<WeenieSearchResult>>(response.Content);

            throw new ApplicationException("Unable to get recent weenie changes from server: " + response.Content, response.ErrorException);
        }

        public List<WeenieSearchResult> AllUpdates(string token)
        {
            RestRequest request = BuildRequest("/Weenie/AllUpdates", Method.GET, token);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<WeenieSearchResult>>(response.Content);

            throw new ApplicationException("Unable to get recent weenie changes from server: " + response.Content, response.ErrorException);
        }

        public Weenie GetWeenie(string token, uint weenieClassId)
        {
            RestRequest request = BuildRequest($"/Weenie/Get", Method.GET, token);
            request.AddQueryParameter("weenieId", weenieClassId.ToString());
            IRestResponse response = _client.Execute(request);

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Weenie>(response.Content, jsonSettings);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            throw new ApplicationException("Unable to get weenie from server: " + response.Content, response.ErrorException);
        }

        public bool UpdateWeenie(string token, Weenie weenie)
        {
            RestRequest request = BuildRequest($"/Weenie/Update", Method.POST, token);
            request.AddJsonBody(weenie);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // returned when nothing to update, try to create it instead
                return CreateWeenie(token, weenie);
            }

            throw new ApplicationException("Unable to update weenie: " + response.Content, response.ErrorException);
        }

        public bool CreateWeenie(string token, Weenie weenie)
        {
            RestRequest request = BuildRequest($"/Weenie/Create", Method.POST, token);
            request.AddJsonBody(weenie);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            throw new ApplicationException("Unable to create weenie: " + response.Content, response.ErrorException);
        }

        public byte[] GetFullyLayeredPngIcon(uint weenieClassId)
        {
            RestRequest request = BuildRequest("/Resource/GetFullyLayeredPngIcon", Method.GET);
            request.AddQueryParameter("weenieClassId", weenieClassId.ToString());
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<byte[]>(response.Content);

            throw new ApplicationException("Unable to get recipe from server: " + response.Content, response.ErrorException);
        }

        public List<Recipe> RecipeSearch(string token, SearchRecipesCriteria criteria)
        {
            RestRequest request = BuildRequest("/Recipe/Search", Method.POST, token);
            request.AddJsonBody(criteria);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<Recipe>>(response.Content);

            throw new ApplicationException("Unable to search for recipes from server: " + response.Content, response.ErrorException);
        }

        public Recipe GetRecipe(string token, Guid recipeGuid)
        {
            RestRequest request = BuildRequest("/Recipe/Get", Method.GET, token);
            request.AddQueryParameter("recipeGuid", recipeGuid.ToString());
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Recipe>(response.Content);

            throw new ApplicationException("Unable to get recipe from server: " + response.Content, response.ErrorException);
        }

        public bool UpdateRecipe(string token, Recipe recipe)
        {
            RestRequest request = BuildRequest($"/Recipe/Update", Method.POST, token);
            request.AddJsonBody(recipe);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            throw new ApplicationException("Unable to update weenie: " + response.Content, response.ErrorException);
        }

        public List<SubscriptionModel> GetSubscriptions(string token, string accountGuid)
        {
            RestRequest request = BuildRequest("/Subscription/GetByAccount", Method.GET, token);
            request.AddQueryParameter("accountGuid", accountGuid);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<SubscriptionModel>>(response.Content);

            throw new ApplicationException("Unable to get subscriptions: " + response.Content, response.ErrorException);
        }

        public bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions)
        {
            RestRequest request = BuildRequest("/Subscription/UpdatePermissions", Method.POST, token);
            request.AddJsonBody(new { subscriptionGuid, newPermissions });
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ApplicationException("Destination server disallowed your request.");
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                SimpleMessage message = JsonConvert.DeserializeObject<SimpleMessage>(response.Content);
                throw new ApplicationException("Destination server returned BadRequest: " + message.Message);
            }

            return false;
        }

        public bool DeleteWeenie(string token, uint weenieClassId)
        {
            RestRequest request = BuildRequest("/Weenie/Delete", Method.DELETE, token);
            request.AddQueryParameter("weenieClassId", weenieClassId.ToString());
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ApplicationException("Destination server disallowed your request.");

            throw new ApplicationException("Unexpected error from server: " + response.Content);
        }

        public WorldRelease CutWorldRelease(string token, ReleaseType releaseType)
        {
            RestRequest request = BuildRequest("/Server/CutWorldRelease", Method.GET, token);
            request.AddQueryParameter("ReleaseType", releaseType.ToString());
            var savedTimeout = _client.Timeout;
            _client.Timeout = 600000;
            IRestResponse response = _client.Execute(request);
            _client.Timeout = savedTimeout;

            WorldRelease newRelease = null;

            // No updates available or
            // Currently cutting a release / server is busy
            if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.Conflict)
            {
                return newRelease;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // check to make sure that the release was successful:
                var storedReleasePath = Path.GetFullPath(ConfigurationManager.AppSettings["WorldReleaseDir"]);
                newRelease = JsonConvert.DeserializeObject<WorldRelease>(response.Content);

                if (!Directory.Exists(storedReleasePath))
                {
                    try
                    {
                        Directory.CreateDirectory(storedReleasePath);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Unable to create stored release folder: " + ex.Message, ex);
                    }
                }

                // If version is missing, no changes available:
                if (newRelease?.Version == null)
                {
                    return null;
                }

                if (!(newRelease.Version?.Length > 0))
                    throw new ApplicationException(
                        "World Release information contained errors: " + response.Content,
                        response.ErrorException);

                // Save the release info too th `estoredReleasePath` path in the App.config
                try
                {
                    File.WriteAllText(
                        Path.GetFullPath(Path.Combine(storedReleasePath, newRelease.Version + ".json")),
                        response.Content);
                }
                catch (Exception e)
                {
                    throw new ApplicationException(
                        "Could not save release information to disk: " + e.Message + response.Content,
                        response.ErrorException);
                }

                try
                {
                    // Get the release
                    var release = GetWorldRelease(token, newRelease.FileName);
                    File.WriteAllBytes(Path.Combine(storedReleasePath, newRelease.FileName), release);
                }
                catch (Exception e)
                {
                    throw new ApplicationException(
                        "Could not save release to disk: " + e.Message + response.Content, response.ErrorException);
                }
                return newRelease;
            }

            throw new ApplicationException("Unable to get the world release info from server: " + response.Content, response.ErrorException);
        }

        public WorldRelease GetCurrentWorldReleaseInfo(string token)
        {
            RestRequest request = BuildRequest("/Resource/GetCurrentWorldReleaseInfo", Method.GET, token);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<WorldRelease>(response.Content);

            throw new ApplicationException("Unable to get the world release info from server: " + response.Content, response.ErrorException);
        }

        public WorldRelease GetWorldReleaseInfo(string token, string fileName)
        {
            RestRequest request = BuildRequest("/Resource/GetWorldReleaseInfo", Method.GET, token);
            request.AddQueryParameter("fileName", fileName);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<WorldRelease>(response.Content);

            throw new ApplicationException("Unable to get the world release info from server: " + response.Content, response.ErrorException);
        }

        public byte[] GetWorldRelease(string token, string fileName)
        {
            RestRequest request = BuildRequest("/Resource/GetWorldRelease", Method.GET, token);
            request.AddQueryParameter("fileName", fileName);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<byte[]>(response.Content);

            throw new ApplicationException("Unable to get the world release from server: " + response.Content, response.ErrorException);
        }

        public byte[] GetCurrentWorldRelease(string token)
        {
            RestRequest request = BuildRequest("/Resource/GetCurrentWorldRelease", Method.GET, token);
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<byte[]>(response.Content);

            throw new ApplicationException("Unable to get the world release from server: " + response.Content, response.ErrorException);
        }
    }
}
