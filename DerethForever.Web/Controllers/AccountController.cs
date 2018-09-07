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
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DerethForever.Web.Providers;
using Lifestoned.DataModel.Account;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DerethForever.Web.Controllers
{
    public class AccountController : BaseController
    {
        private const string _Session_LoginModel = "__loginModel";

        private LoginModel SessionLoginModel
        {
            get { return (LoginModel)Session[_Session_LoginModel]; }
            set { Session[_Session_LoginModel] = value; }
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginModel m = SessionLoginModel ?? new LoginModel();
            SessionLoginModel = null;

            return View(m);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginResult = AuthProviderHost.PrimaryAuthProvider.Authenticate(model.Username, model.Password);

            if (loginResult.StatusCode == HttpStatusCode.Unauthorized)
            {
                model.ErrorMessages.Add("Incorrect Username or Password");
                return View(model);
            }

            if (loginResult.StatusCode != HttpStatusCode.OK)
            {
                model.ErrorMessages.Add("Error connecting to API");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(loginResult.Token))
            {
                JwtCookieManager.SetCookie(loginResult.Token);
                return RedirectToAction("Index", "Home", null);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            JwtCookieManager.SignOut();
            BaseController.CurrentUser = null;
            return RedirectToAction("Index", "Home", null);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (AuthProviderHost.PrimaryAuthProvider.Register(model))
                {
                    SessionLoginModel = new LoginModel();
                    SessionLoginModel.InfoMessages.Add("Registration success.");
                    return RedirectToAction("Login");
                }

                model.ErrorMessages.Add("Registration failed without an error message.");
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add("Error during registration");
                model.Exception = ex;
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Accounts()
        {
            var accounts = AuthProviderHost.PrimaryAuthProvider.GetAccounts(GetUserToken());
            AccountListModel model = new AccountListModel() { Accounts = accounts };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Subs(string id)
        {
            SubListModel model = new SubListModel();

            try
            {
                // id is the account guid.  subscriptions are on the main API, not the auth API
                var account = AuthProviderHost.PrimaryAuthProvider.GetAccount(GetUserToken(), id);
                var subs = AuthProviderHost.PrimaryAuthProvider.GetSubscriptions(GetUserToken(), id);

                model.AccountGuid = id;
                model.AccountName = account.Name;

                // copy over the default access levels
                subs.ForEach(m => m.NewAccessLevel = (AccessLevel)m.AccessLevel);

                model.Subscriptions = subs;
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add("Error retrieving data from API(s)");
                model.Exception = ex;
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Subs(SubListModel model)
        {
            // see if any subs were changed
            foreach (var sub in model.Subscriptions)
            {
                if (sub.NewAccessLevel != null && (ulong)sub.NewAccessLevel.Value != sub.AccessLevel)
                {
                    // attempt to update it
                    try
                    {
                        if (AuthProviderHost.PrimaryAuthProvider.UpdatePermissions(GetUserToken(), sub.SubscriptionGuid.ToString(), (ulong)sub.NewAccessLevel))
                        {
                            model.SuccessMessages.Add("Subscription " + sub.Name + " updated.");
                            sub.AccessLevel = (ulong)sub.NewAccessLevel;
                        }
                        else
                            model.WarningMessages.Add("Subscription " + sub.Name + " was not updated.");
                    }
                    catch (Exception ex)
                    {
                        model.ErrorMessages.Add("Subscription " + sub.Name + " encountered an error during update.");
                        model.Exception = ex;
                        break;
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var account = AuthProviderHost.PrimaryAuthProvider.GetAccount(GetUserToken(), JwtCookieManager.GetUserGuid(GetUserToken()));

            return View(account);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(ApiAccountModel model)
        {
            try
            {
                string gid = GetUserGuid();

                if (string.Compare(gid, model.AccountGuid, true) != 0
                    && !User.IsInRole("Admin"))
                    throw new UnauthorizedAccessException("You do not have permission to edit this user");

                if (model.AccountAction == "AddManagedWorld")
                {
                    model.ManagedWorlds.Add(new ManagedServerModel());
                    model.AccountAction = "";
                    ModelState.Clear();
                    return View(model);
                }

                model.ManagedWorlds.RemoveAll(w => w == null || w.Deleted);
                AuthProviderHost.PrimaryAuthProvider.UpdateAccount(GetUserToken(), model);
                BaseController.CurrentUser = model;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add("Call to server to update your account failed.");
                model.Exception = ex;
            }

            model.AccountAction = "";
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SelectServer(string href, string selectedServer)
        {
            if (!string.IsNullOrWhiteSpace(selectedServer))
            {
                var user = CurrentUser;
                var server = user.ManagedWorlds.FirstOrDefault(w => w.ManagedServerGuid.Value.ToString() == selectedServer);
                if (server != null)
                {
                    user.SelectedManagedWorld = server.ServerName;
                    user.SelectedManagedWorldGuid = server.ManagedServerGuid;
                }

                CurrentUser = user;
            }

            if (!string.IsNullOrWhiteSpace(href))
                return new RedirectResult(href);

            return RedirectToAction("Index", "Home");
        }
    }
}
