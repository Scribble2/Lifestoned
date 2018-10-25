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
using System.ComponentModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lifestoned.DataModel.Shared
{
    /// <summary>
    /// this is a dual purpose class for interacting with the Api as well as serving 
    /// as a model for this web ui
    /// </summary>
    public class WeenieSearchResult
    {
        [Description("Weenie Id")]
        [JsonProperty("weenieClassId")]
        public uint WeenieClassId { get; set; }

        [Description("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Description("Description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Description("Type")]
        [JsonProperty("weenieType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WeenieType? WeenieType { get; set; }

        [JsonIgnore]
        public string WeenieType_Display
        {
            get
            {
                return this.WeenieType.GetName();
            }
        }

        [Description("Item Type")]
        [JsonProperty("itemType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType? ItemType { get; set; }

        [JsonIgnore]
        public string ItemType_Display
        {
            get
            {
                return this.ItemType.GetName();
            }
        }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }
        
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("isDone")]
        public bool IsDone { get; set; }

        [JsonIgnore]
        public bool HasSandboxChange { get; set; }
    }
}
