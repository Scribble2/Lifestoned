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
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc.Filters;
using DerethForever.Web.Controllers;
using Newtonsoft.Json.Linq;

namespace DerethForever.Web
{
    public class JwtCookieManager : IAuthenticationFilter
    {
        public void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            SessionSecurityToken sst = null;
            try
            {
                if (FederatedAuthentication.SessionAuthenticationModule.TryReadSessionTokenFromCookie(out sst))
                {
                    var ticketClaim = sst.ClaimsPrincipal.Claims.FirstOrDefault(c => c.Type == "token");

                    // validate that the cookie wasn't expired
                    if (ticketClaim != null && !IsExpired(ticketClaim.Value))
                    {
                        filterContext.Principal = sst.ClaimsPrincipal;

                        if (BaseController.CurrentUser == null)
                        {
                            var token = (sst.ClaimsPrincipal.Identity as ClaimsIdentity).FindFirst("token")?.Value;
                            BaseController.CurrentUser = AuthProviderHost.PrimaryAuthProvider.GetAccount(token, null);
                        }
                    }
                    else
                        // clear the cookie so we don't have to do this every time
                        SignOut();
                }
            }
            catch
            {
                // unfortunately, "TryReadSession" throws.  often.
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // no-op
        }
        
        /// <summary>
        /// parses the token to set the cookie with a ClaimsPrincipal, returns the expiration time of the token.
        /// </summary>
        public static ClaimsPrincipal SetCookie(string token)
        {
            var parts = token.Split('.');
            var bodyBase64 = parts[1];

            // parse the header and body into objects
            var bodyJson = Encoding.UTF8.GetString(Base64UrlDecode(bodyBase64));
            var bodyData = JObject.Parse(bodyJson);

            // standard claims
            string username = (string)bodyData["unique_name"];
            string accountGuid = (string)bodyData["nameid"];
            int expire = (int)bodyData["exp"];
            int issued = (int)bodyData["nbf"];

            // Dereth Forever custom claims
            int accountId = (int)bodyData["account_id"];
            string displayName = (string)bodyData["display_name"];
            string[] roles;

            try
            {
                roles = bodyData["role"].ToObject<string[]>();
            }
            catch
            {
                roles = new string[] { bodyData["role"].ToObject<string>() };
            }
            
            int duration = expire - issued - 60; // fudge factor of 1 minute

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, displayName),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("accountGuid", accountGuid),
                new Claim("accountId", accountId.ToString()),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                    "DerethForever.Auth"),
                new Claim("token", token)
            };

            foreach (string role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            
            ClaimsIdentity ci = new ClaimsIdentity(claims, "DerethForever");
            ClaimsPrincipal cp = new ClaimsPrincipal(ci);

            FederatedAuthentication.SessionAuthenticationModule.CookieHandler.HideFromClientScript = true;
            var sessionToken = FederatedAuthentication.SessionAuthenticationModule.CreateSessionSecurityToken(cp, null, DateTime.UtcNow, DateTime.UtcNow.AddSeconds(duration), false);
            FederatedAuthentication.SessionAuthenticationModule.AuthenticateSessionSecurityToken(sessionToken, true);

            return cp;
        }

        public static string GetUserGuid(string token)
        {
            var parts = token.Split('.');
            var bodyBase64 = parts[1];
            var bodyJson = Encoding.UTF8.GetString(Base64UrlDecode(bodyBase64));
            var bodyData = JObject.Parse(bodyJson);
            return (string)bodyData["nameid"];
        }

        public static string GetUserName(string token)
        {
            var parts = token.Split('.');
            var bodyBase64 = parts[1];
            var bodyJson = Encoding.UTF8.GetString(Base64UrlDecode(bodyBase64));
            var bodyData = JObject.Parse(bodyJson);
            string username = (string)bodyData["unique_name"];
            return username;
        }
        
        public static string GetUserDisplayName(string token)
        {
            var parts = token.Split('.');
            var bodyBase64 = parts[1];
            var bodyJson = Encoding.UTF8.GetString(Base64UrlDecode(bodyBase64));
            var bodyData = JObject.Parse(bodyJson);
            string displayName = (string)bodyData["display_name"];
            return displayName;
        }

        public static void SignOut()
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
        }

        private bool IsExpired(string token)
        {
            var parts = token.Split('.');
            var bodyBase64 = parts[1]; // we only want to get the username out.  everything else just goes as is.

            // parse the header and body into objects
            var bodyJson = Encoding.UTF8.GetString(Base64UrlDecode(bodyBase64));
            var bodyData = JObject.Parse(bodyJson);

            int expiration = (int)bodyData["exp"];
            var unixTimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            return (unixTimestamp >= expiration);
        }

        private static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new System.Exception("Illegal base64url string!");
            }

            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }
    }
}
