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
using DerethForever.Web.Models.Weenie;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DerethForever.Web
{
    public class ManagedWorldProvider : IManagedWorldProvider
    {
        public string Authenticate(string url, string username, string password)
        {
            var client = new RestClient(url);
            var authRequest = new RestRequest("/Account/Authenticate", Method.POST);
            authRequest.JsonSerializer = new NonSuckyJsonSerializer();
            authRequest.AddJsonBody(new { Username = username, Password = password });
            var authResponse = client.Execute(authRequest);
            
            if (authResponse.StatusCode == HttpStatusCode.OK)
                return (string)JObject.Parse(authResponse.Content).SelectToken("authToken");

            throw new ApplicationException($"Unable to authenticate with {url}.  Response message was {authResponse.Content}.");
        }

        public IRestResponse UpdateWeenie(string url, string token, Weenie weenie)
        {
            var client = new RestClient(url);
            var request = new RestRequest($"/Weenie/Update", Method.POST);
            request.JsonSerializer = new NonSuckyJsonSerializer();
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddJsonBody(weenie);
            var response = client.Execute(request);

            return response;
        }

        public IRestResponse PreviewWeenie(string url, string token, Weenie weenie)
        {
            var client = new RestClient(url);
            var request = new RestRequest($"/Weenie/Preview", Method.POST);
            request.JsonSerializer = new NonSuckyJsonSerializer();
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddJsonBody(weenie);
            var response = client.Execute(request);

            return response;
        }
    }
}
