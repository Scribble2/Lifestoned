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
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Lifestoned.DataModel.Content;
using Lifestoned.Providers;

namespace DerethForever.Web.Controllers
{
    public class ContentController : BaseController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var contentList = ContentProviderHost.CurrentProvider.GetAllContent(GetUserToken());
            return View(contentList);
        }

        [HttpGet]
        [Authorize]
        public ActionResult New()
        {
            return View(new Content());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(Guid contentId)
        {
            var contentList = ContentProviderHost.CurrentProvider.GetAllContent(GetUserToken());
            var content = contentList.FirstOrDefault(c => c.ContentGuid == contentId);

            return View(content);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Content c)
        {
            if (!ModelState.IsValid)
                return View(c);
            
            return View(c);
        }
    }
}
