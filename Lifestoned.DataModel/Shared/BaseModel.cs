using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Shared
{
    /// <summary>
    /// base model that contains anything "standard" on pages like error messages or whatnot
    /// </summary>
    public class BaseModel
    {
        [JsonIgnore]
        public List<string> ErrorMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> SuccessMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> InfoMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> WarningMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public Exception Exception { get; set; }

        public static void CopyBaseData(BaseModel from, BaseModel to)
        {
            if (from == null || to == null)
                return;

            to.ErrorMessages = from.ErrorMessages;
            from.ErrorMessages = new List<string>();
            to.SuccessMessages = from.SuccessMessages;
            from.SuccessMessages = new List<string>();
            to.InfoMessages = from.InfoMessages;
            from.InfoMessages = new List<string>();
            to.WarningMessages = from.WarningMessages;
            from.WarningMessages = new List<string>();
            to.Exception = from.Exception;
            from.Exception = null;
        }
    }
}