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
using System.Security.Claims;
using System.Web.Mvc;
using DerethForever.Web.Models;
using DerethForever.Web.Models.Account;
using DerethForever.Web.Models.CachePwn;
using DerethForever.Web.Models.Weenie;

namespace DerethForever.Web.Controllers
{
    public class BaseController : Controller
    {
        private const string _Session_ImportedWeenie = "__importedWeenie";

        private const string _Session_BaseModel = "__baseModel";

        private const string _Session_Account = "__account";

        public CachePwnWeenie ImportedWeenie
        {
            get { return (CachePwnWeenie)Session[_Session_ImportedWeenie]; }
            set { Session[_Session_ImportedWeenie] = value; }
        }

        public BaseModel CurrentBaseModel
        {
            get { return (BaseModel)Session[_Session_BaseModel]; }
            set { Session[_Session_BaseModel] = value; }
        }

        public static ApiAccountModel CurrentUser
        {
            get { return (ApiAccountModel)System.Web.HttpContext.Current.Session[_Session_Account]; }
            set { System.Web.HttpContext.Current.Session[_Session_Account] = value; }
        }

        public string GetUserToken()
        {
            var ci = User?.Identity as ClaimsIdentity;
            var claim = ci?.FindFirst("token");
            
            return claim?.Value;
        }

        public string GetUserName()
        {
            return User.Identity.Name;
        }

        public string GetUserGuid()
        {
            return JwtCookieManager.GetUserGuid(GetUserToken());
        }
    }
}
