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
using System.Web;
using System.Web.Mvc;
using log4net;

namespace DerethForever.Web
{
    public class CustomErrorHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public class CustomExceptionFilter : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                var controller = filterContext.Controller as Controller;
                controller.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                controller.Response.TrySkipIisCustomErrors = true;
                filterContext.ExceptionHandled = true;

                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var exception = filterContext.Exception;
                var model = new HandleErrorInfo(exception, controllerName, actionName);
                var view = new ViewResult();

                view.ViewName = "Error";
                view.ViewData = new ViewDataDictionary();
                view.ViewData.Model = model;

                // capture model data
                var viewData = controller.ViewData;
                if (viewData != null && viewData.Count > 0)
                {
                    viewData.ToList().ForEach(view.ViewData.Add);
                }

                // Show error
                view.ExecuteResult(filterContext);

                // log error
                Log.Error("Uncaught exception", exception);
            }
        }
    }
}
