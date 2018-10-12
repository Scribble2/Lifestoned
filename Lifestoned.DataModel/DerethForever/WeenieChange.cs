using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.DerethForever
{
    public class WeenieChange
    {
        [JsonProperty("weenie")]
        public Weenie Weenie { get; set; }

        [JsonProperty("userGuid")]
        public string UserGuid { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("submitted")]
        public bool Submitted { get; set; }

        [JsonProperty("comments")]
        public DateTime SubmissionTime { get; set; }
        
        [JsonProperty("discussion")]
        public List<ChangeDiscussionEntry> Discussion { get; set; } = new List<ChangeDiscussionEntry>();
    }
}
