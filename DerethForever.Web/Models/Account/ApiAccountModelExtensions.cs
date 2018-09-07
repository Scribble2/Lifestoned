using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Account
{
    public static class ApiAccountModelExtensions
    {
        public static List<SelectListItem> GetManagedWorldSelectListItems(this Lifestoned.DataModel.Account.ApiAccountModel model)
        {
            return model.ManagedWorlds.Select(w => new SelectListItem() { Text = w.ServerName, Value = w.ManagedServerGuid.ToString() }).ToList();
        }
    }
}