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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class Emote
    {
        [JsonProperty("category")]
        public uint Category { get; set; }

        [JsonIgnore]
        [Display(Name = "Emote Category")]
        public EmoteCategory EmoteCategory
        {
            get { return (EmoteCategory)Category; }
            set { Category = (uint)value; }
        }

        [JsonProperty("emotes")]
        public List<EmoteAction> Emotes { get; set; }

        [JsonProperty("probability")]
        public float? Probability { get; set; }

        [JsonProperty("vendorType")]
        [EmoteCategory(EmoteCategory.Vendor)]
        public uint? VendorType { get; set; }

        [JsonProperty("quest")]
        [EmoteCategory(EmoteCategory.QuestFailure)]
        [EmoteCategory(EmoteCategory.QuestSuccess)]
        [EmoteCategory(EmoteCategory.TestSuccess)]
        [EmoteCategory(EmoteCategory.TestFailure)]
        [EmoteCategory(EmoteCategory.GotoSet)]
        public string Quest { get; set; }

        [JsonProperty("classID")]
        [EmoteCategory(EmoteCategory.Refuse)]
        [EmoteCategory(EmoteCategory.Give)]
        public uint? ClassId { get; set; }

        [JsonProperty("style")]
        [EmoteCategory(EmoteCategory.HeartBeat)]
        public uint? Style { get; set; }

        [JsonProperty("substyle")]
        [EmoteCategory(EmoteCategory.HeartBeat)]
        public uint? SubStyle { get; set; }

        [JsonProperty("minhealth")]
        [EmoteCategory(EmoteCategory.WoundedTaunt)]
        public float? MinHealth { get; set; }

        [JsonProperty("maxhealth")]
        [EmoteCategory(EmoteCategory.WoundedTaunt)]
        public float? MaxHealth { get; set; }

        [JsonIgnore]
        public int? SortOrder { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        /// <summary>
        /// checks the EmoteType attributes of the requested property to determine whether or not
        /// it should be shown
        /// </summary>
        public static bool IsPropertyVisible(string propertyName, Emote emote)
        {
            var property = typeof(Emote).GetProperty(propertyName);
            var attribs = property.GetCustomAttributes(typeof(EmoteCategoryAttribute), false).Cast<EmoteCategoryAttribute>().ToList();

            if (attribs == null || attribs.Count < 1)
                return true;

            // because the lists are long and could get unwieldy, we'll allow for multiple on the same property
            return attribs.Any(a => a.CategoryList.Contains(emote.EmoteCategory));
        }
    }
}
