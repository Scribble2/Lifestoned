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
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Lifestoned.Providers
{
    public class DerethForeverAuthProvider : IAuthProvider
    {
        private readonly RestClient _client;

        public DerethForeverAuthProvider(string authEndpoint)
        {
            _client = new RestClient(authEndpoint);
        }

        public LoginResult Authenticate(string username, string password)
        {
            var authRequest = BuildRequest("/Account/Authenticate", Method.POST);
            authRequest.AddJsonBody(new { Username = username, Password = password });
            var authResponse = _client.Execute(authRequest);

            LoginResult result = new LoginResult();
            result.StatusCode = authResponse.StatusCode;

            if (authResponse.StatusCode == HttpStatusCode.OK)
                result.Token = (string)JObject.Parse(authResponse.Content).SelectToken("authToken");

            return result;
        }

        public List<ApiAccountModel> GetAccounts(string token)
        {
            var request = BuildRequest("/Account/GetAll", Method.GET, token);
            var response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<ApiAccountModel>>(response.Content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ApplicationException("Destination server disallowed your request.");

            throw new ApplicationException($"Unexpected response {response.StatusCode} from server.  Content: {response.Content}.");
        }

        public ApiAccountModel GetAccount(string token, string accountGuid)
        {
            RestRequest request;

            if (string.IsNullOrWhiteSpace(accountGuid))
                accountGuid = JwtCookieManager.GetUserGuid(token);

            if (JwtCookieManager.GetUserGuid(token).ToLower() == accountGuid.ToLower())
            {
                // bypass the admin api if we're asking for our own account
                request = BuildRequest("/Account/GetMyAccount", Method.GET, token);
            }
            else
            {
                request = BuildRequest("/Account/Get", Method.GET, token);
                request.AddQueryParameter("accountGuid", accountGuid);
            }

            var response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiAccountModel>(response.Content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ApplicationException("Destination server disallowed your request.");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            throw new ApplicationException($"Unexpected response {response.StatusCode} from server.  Content: {response.Content}.");
        }

        public void UpdateAccount(string token, ApiAccountModel model)
        {
            var request = BuildRequest("/Account/UpdateAccount", Method.POST, token);
            request.AddJsonBody(model);
            var response = _client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException(response.Content.Replace("\\r\\n", "\r\n"));
        }

        public bool Register(RegisterModel model)
        {
            var request = BuildRequest("/Account/Register", Method.POST);
            request.AddJsonBody(model);
            var authResponse = _client.Execute(request);

            LoginResult result = new LoginResult();
            result.StatusCode = authResponse.StatusCode;

            if (authResponse.StatusCode != HttpStatusCode.OK)
                return false;
            
            return true;
        }

        private RestRequest BuildRequest(string endpoint, Method method, string authToken = null)
        {
            var request = new RestRequest(endpoint, method);
            request.JsonSerializer = new NonSuckyJsonSerializer();

            if (!string.IsNullOrWhiteSpace(authToken))
                request.AddHeader("Authorization", "Bearer " + authToken);

            return request;
        }
    }
}
