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
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lifestoned.DataModel.WorldRelease;
using Newtonsoft.Json;

namespace DerethForever.Web.Controllers
{
    public class WorldReleaseController : BaseController
    {
        // GET: Release
        public ActionResult Index(IndexModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.Results = new List<Release>();
                string releaseDir = Path.GetFullPath(ConfigurationManager.AppSettings["WorldReleaseDir"]);
                var allReleases = Directory.GetFiles(releaseDir, "*.json", SearchOption.AllDirectories).OrderByDescending(f => new FileInfo(f).CreationTime).ToList();

                foreach (var file in allReleases)
                {
                    model.Results.Add(JsonConvert.DeserializeObject<Release>(System.IO.File.ReadAllText(file)));
                }
            }
            catch (Exception ex)
            {
                model.Results = null;
                model.ShowResults = false;
                model.ErrorMessages.Add("Error retrieving data from disk.");
                model.Exception = ex;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Get(string fileName)
        {
            byte[] src = new byte[] { };

            if (fileName?.Length > 0)
            {
                try
                {
                    string releaseDir = Path.GetFullPath(ConfigurationManager.AppSettings["WorldReleaseDir"]);
                    string filePath = Path.GetFullPath(Path.Combine(releaseDir, fileName));
                    src = System.IO.File.ReadAllBytes(filePath);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return File(src, "application/zip", fileName);
        }
    }
}
