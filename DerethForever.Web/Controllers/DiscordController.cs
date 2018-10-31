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
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using DerethForever.Web.Models.Discord;
using log4net;
using Lifestoned.Providers;
using RestSharp;

namespace DerethForever.Web.Controllers
{
    public class DiscordController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// queues up a task to send the notification.  usefull for stuff where the user doesn't
        /// care about the result (ie, anybody other than admins debugging this)
        /// </summary>
        public static void PostToDiscordAsync(IDiscordMessage notification)
        {
            Task.Run(() => PostToDiscord(notification));
        }

        public static void PostToDiscord(IDiscordMessage notification)
        {
            Message request = notification.GetDiscordMessage();
            string urlKey = ConfigurationManager.AppSettings["DiscordHookToUse"];
            if (string.IsNullOrEmpty(urlKey))
                return;

            string url = ConfigurationManager.AppSettings[urlKey];
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return;

            RestClient client = new RestClient(url);
            RestRequest rr = new RestRequest();
            rr.JsonSerializer = new NonSuckyJsonSerializer();
            rr.AddJsonBody(request);
            rr.Method = Method.POST;

            try
            {
                IRestResponse response = client.Execute(rr);

                if (response.StatusCode == HttpStatusCode.OK)
                    log.Info($"Message posted to discord successfully: {response.Content}");
                else
                    log.Error($"Non-OK code posting message to discord. {Environment.NewLine}Content: {response.Content} {Environment.NewLine}Error Message: {response.ErrorMessage}");

                return; // response.StatusCode;
            }
            catch (Exception ex)
            {
                log.Error("Exception posting message to discord.", ex);
            }

            return; // HttpStatusCode.InternalServerError;
        }
    }
}
