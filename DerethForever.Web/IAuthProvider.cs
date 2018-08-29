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
using DerethForever.Web.Models.Account;

namespace DerethForever.Web
{
    public interface IAuthProvider
    {
        /// <summary>
        /// attempts an authorization with the provided credentials.  if successful, returns an
        /// auth token.  if not, returns null.  exceptional cases are thrown as exceptions.
        /// </summary>
        LoginResult Authenticate(string username, string password);

        /// <summary>
        /// attempts to create an account with the provider.  password validation errors
        /// are thrown as argument exceptions.  default account permissions are set by the
        /// provider and should not be assumed.
        /// </summary>
        bool Register(RegisterModel model);

        /// <summary>
        /// gets a list of accounts from the provider.  provider will determine if the
        /// provided token has the permissions to do so.  non-http-OK responses will
        /// trigger an ApplicationException to be thrown.
        /// </summary>
        List<ApiAccountModel> GetAccounts(string token);

        /// <summary>
        /// gets the requested account from the provider.  provider will determine if the
        /// provided token has the permissions to do so.  non-http-OK responses will
        /// trigger an ApplicationException to be thrown.
        /// </summary>
        ApiAccountModel GetAccount(string token, string accountGuid);

        /// <summary>
        /// updates the specified account.  provider will determine if the
        /// provided token has the permissions to do so.  non-http-OK responses will
        /// trigger an ApplicationException to be thrown.
        /// </summary>
        void UpdateAccount(string token, ApiAccountModel model);

        List<SubscriptionModel> GetSubscriptions(string token, string accountGuid);

        /// <summary>
        /// using the token provided, attempts to update the permissions of the specified
        /// subscription.  provider will validate the token's permissions accordingly.
        /// </summary>
        bool UpdatePermissions(string token, string subscriptionGuid, ulong newPermissions);
    }
}
