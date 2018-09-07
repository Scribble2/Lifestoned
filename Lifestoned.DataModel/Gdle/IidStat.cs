using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class IidStat
    {
        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonIgnore]
        public string PropertyIdBinder
        {
            get { return ((IidPropertyId)Key).GetName(); }
        }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
