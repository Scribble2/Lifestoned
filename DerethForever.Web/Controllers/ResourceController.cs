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
using System.IO;
using System.Web.Mvc;
using Lifestoned.DataModel.WorldRelease;
using Lifestoned.Lib.ClientLib.Enum;
using Lifestoned.Providers;

namespace DerethForever.Web.Controllers
{
    public class ResourceController : BaseController
    {
        public ActionResult GetFullyLayeredPngIcon(uint weenieClassId)
        {
            byte[] src = new byte[] { };

            if (weenieClassId > 0)
            {
                try
                {
                    var weenie = ContentProviderHost.CurrentProvider.GetWeenie(null, weenieClassId);
                    src = Lifestoned.Lib.ResourceManager.GetFullyLayeredPngIcon(weenie.ItemType, weenie.UnderlayId, weenie.OverlayId, weenie.IconId, weenie.UIEffects);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return File(src, "image/png");
        }

        [HttpGet]
        public ActionResult GetDynamicIcon(int? itemType, uint? underlayId, uint? overlayId, uint? iconId, int? uiEffects)
        {
            byte[] src = new byte[] { };
            src = Lifestoned.Lib.ResourceManager.GetFullyLayeredPngIcon(itemType, underlayId, overlayId, iconId, uiEffects);
            return File(src, "image/png");
        }

        [HttpGet]
        public ActionResult GetImage(uint imageId)
        {
            byte[] src = new byte[] { };

            if (imageId > 0)
            {
                try
                {
                    src = Lifestoned.Lib.ResourceManager.GetPngImage(imageId);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return File(src, "image/png");
        }

        [HttpGet]
        public ActionResult GetCurrentWorldRelease()
        {
            byte[] src = new byte[] { };
            Release info = new Release();

            try
            {
                info = ContentProviderHost.CurrentProvider.GetCurrentWorldReleaseInfo(GetUserToken());
                src = ContentProviderHost.CurrentProvider.GetCurrentWorldRelease(GetUserToken());
            }
            catch (Exception)
            {
                return null;
            }

            return File(src, "application/zip", info.FileName);
        }

        [HttpGet]
        public ActionResult GetWorldRelease(string fileName)
        {
            byte[] src = new byte[] { };

            if (fileName?.Length > 0)
            {
                try
                {
                    src = ContentProviderHost.CurrentProvider.GetWorldRelease(GetUserToken(), fileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return File(src, "application/zip");
        }

        [HttpGet]
        public ActionResult GetCurrentWorldReleaseInfo()
        {
            Release releaseInfo = new Release() { Type = ReleaseType.Unknown };

            try
            {
                releaseInfo = ContentProviderHost.CurrentProvider.GetCurrentWorldReleaseInfo(GetUserToken());
            }
            catch (Exception)
            {
                return null;
            }

            return Json(releaseInfo);
        }

        [HttpGet]
        public ActionResult GetWorldReleaseInfo(string fileName)
        {
            Release src = new Release() { Type = ReleaseType.Unknown };

            if (fileName?.Length > 0)
            {
                try
                {
                    src = ContentProviderHost.CurrentProvider.GetWorldReleaseInfo(GetUserToken(), fileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return Json(src);
        }
    }
}
