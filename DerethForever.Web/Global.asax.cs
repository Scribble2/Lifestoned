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
using System.Configuration;
using System.IdentityModel.Services;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Lifestoned.Lib;

namespace DerethForever.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DapperMappingConfig.RegisterMapping();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string cacheDir = ConfigurationManager.AppSettings["SandboxCacheDir"];
            string apiEndpoint = ConfigurationManager.AppSettings["DerethForever.Api"];
            string finalDir = ConfigurationManager.AppSettings["FinalDir"];

            SandboxContentProviderHost.CurrentProvider = new SandboxContentProvider(new LocalContentProvider(finalDir), cacheDir);
            ContentProviderHost.CurrentProvider = SandboxContentProviderHost.CurrentProvider;
            ContentProviderHost.ManagedWorldProvider = new ManagedWorldProvider();
            AuthProviderHost.PrimaryAuthProvider = new DummyAuthProvider();

            PortalDatReader.Initialize(ConfigurationManager.AppSettings["PortalDat"]);

            // To handle exceptions
            GlobalFilters.Filters.Add(new CustomErrorHandler.CustomExceptionFilter());
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, System.EventArgs e)
        {
            // If the user is not authorised to see this page or access this function, send them to the error page.
            if (Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                Response.ClearContent();
                Response.RedirectToRoute("AuthHandler", (RouteTable.Routes["AuthHandler"] as Route).Defaults);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
            CryptographicException cryptoEx = error as CryptographicException;

            // so, explanation is due here.  these Crypto exceptions fire when something about your cookie
            // goes bad.  changing ADFS password, machine key changes, cookie expires, etc.  we will
            // attempt to force a sign-out and if one of those are successful, we can clear the error.

            bool clear = false;

            if (cryptoEx != null)
            {
                try
                {
                    FederatedAuthentication.SessionAuthenticationModule.SignOut();
                    clear = true;
                }
                catch
                {
                    // swallow
                }

                try
                {
                    FormsAuthentication.SignOut();
                    clear = true;
                }
                catch
                {
                    // swallow
                }
            }

            // clear and move on.
            if (clear)
                Server.ClearError();
            else
            {
                // TODO: handle saving of exception
                // Server.Transfer("~/Error/Index");
            }
        }
    }
}
