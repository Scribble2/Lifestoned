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
using DerethForever.Web.Models.Discord;
using Lifestoned.DataModel.WorldRelease;
using Lifestoned.Providers;

namespace DerethForever.Web.Controllers
{
    public class ServerController : BaseController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExportChanges()
        {
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Redeploy()
        {
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rebase()
        {
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ReloadCache()
        {
            SandboxContentProviderHost.CurrentProvider.ReloadCache();
            return RedirectToAction("Index", "Server");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CutWorldRelease(ReleaseType type)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CutWorldReleaseEx(ReleaseType type)
        {
            var results = ContentProviderHost.CurrentProvider.CutWorldRelease(GetUserToken(), type);
            // If null or unknown, there are no updates available:
            var success = (results == null || results.Type == ReleaseType.Unknown) ? false : true;

            if (success)
            {
                WorldReleaseEvent wre = new WorldReleaseEvent();
                wre.User = CurrentUser.DisplayName;
                wre.ReleaseTime = DateTimeOffset.Now;
                wre.Name = results.FileName;
                wre.Size = results.FileSize;
                DiscordController.PostToDiscordAsync(wre);
            }

            return RedirectToAction("Index", "WorldRelease");
        }
    }
}
