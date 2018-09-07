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
using System.Web.Mvc;
using DerethForever.Web.Models.Recipe;
using DerethForever.Web.Providers;

namespace DerethForever.Web.Controllers
{
    public class RecipeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new IndexModel());
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            try
            {
                model.Results = SandboxContentProviderHost.CurrentProvider.RecipeSearch(GetUserToken(), model.Criteria);
                model.HasResults = true;
            }
            catch (Exception ex)
            {
                model.Results = null;
                model.HasResults = false;
                model.ErrorMessages.Add("Error retrieving data from the API");
                model.Exception = ex;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = SandboxContentProviderHost.CurrentProvider.GetRecipe(GetUserToken(), id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Recipe model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = string.Empty;
                foreach (ModelState state in ModelState.Values)
                {
                    foreach (ModelError error in state.Errors)
                    {
                        errorMessage += error.ErrorMessage;
                    }
                }

                model.ErrorMessages.Add(errorMessage);
                return View(model);
            }

            model.LastModified = DateTime.Now;
            model.ModifiedBy = GetUserName();

            try
            {
                SandboxContentProviderHost.CurrentProvider.UpdateRecipe(GetUserToken(), model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add("Error saving recipe in the API");
                model.Exception = ex;
            }

            return View(model);
        }
    }
}
