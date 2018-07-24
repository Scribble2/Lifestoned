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
using System.Web.Mvc;
using System.Web.Routing;

namespace DerethForever.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "AuthHandler",
                "Account/{action}",
                new { controller = "Account", action = "Login", errMsg = UrlParameter.Optional }
            );

            routes.MapRoute(
                "ErrorHandler",
                "Error/{action}/{errMsg}",
                new { controller = "Error", action = "Index", errMsg = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Content",
                "Content/{action}",
                new { controller = "Content", action = "Index" }
            );

            routes.MapRoute(
                "Weenie",
                "Weenie/{action}",
                new { controller = "Weenie", action = "Index" }
            );

            routes.MapRoute(
                "GetWorldReleaseInfo",
                "Resource/GetWorldReleaseInfo",
                new { controller = "Resource", action = "GetWorldReleaseInfo" }
            );

            routes.MapRoute(
                "GetWorldRelease",
                "Resource/GetWorldRelease",
                new { controller = "Resource", action = "GetWorldRelease" }
            );

            // Add constraint when new View folders are created:
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "Home|Server|Weenie|Content|Account|Recipe|ModelViewer|Resource|WorldRelease" }
            );

            // Catch all 404 / File Not found routes
            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
