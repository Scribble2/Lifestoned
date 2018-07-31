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
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Shared
{
    public class EmoteSet
    {
        [JsonProperty("emoteSetGuid")]
        public Guid? EmoteSetGuid { get; set; }

        [JsonProperty("weenieClassId")]
        [Display(Name = "Weenie Class Id")]
        public uint WeenieClassId { get; set; }

        [JsonProperty("sortOrder")]
        [Display(Name = "Sort Order")]
        public uint SortOrder { get; set; }

        [JsonProperty("emoteCategoryId")]
        public uint EmoteCategoryId { get; set; }

        [JsonIgnore]
        [Display(Name = "Emote Category")]
        public EmoteCategory EmoteCategory
        {
            get { return (EmoteCategory)EmoteCategoryId; }
            set { EmoteCategoryId = (uint)value; }
        }

        [JsonProperty("probability")]
        [Display(Name = "Probibility")]
        public float? Probability { get; set; }

        [JsonProperty("emotes")]
        [Display(Name = "Emotes")]
        public List<Emote> Emotes { get; set; } = new List<Emote>();

        /// <summary>
        /// Used for Categories Refuse == 1, Give == 6
        /// </summary>
        [JsonProperty("classId")]
        [Display(Name = "Class Id")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.Refuse, EmoteCategory.Give })]
        public uint? ClassId { get; set; }

        /// <summary>
        /// Used for Category HeartBeat == 5
        /// </summary>
        [JsonProperty("style")]
        [Display(Name = "Style")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.HeartBeat })]
        public uint? Style { get; set; }

        /// <summary>
        /// Used for Category HeartBeat == 5
        /// </summary>
        [JsonProperty("subStyle")]
        [Display(Name = "Sub Style")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.HeartBeat })]
        public uint? SubStyle { get; set; }

        /// <summary>
        /// Used for Categories QuestSuccess, QuestFailure, TestSuccess, TestFailure, EventSuccess, EventFailure, TestNoQuality, QuestNoFellow, TestNoFellow,
        /// GotoSet, NumFellowsSuccess, NumFellowsFailure, NumCharacterTitlesSuccess, NumCharacterTitlesFailure, ReceiveLocalSignal, ReceiveTalkDirect
        /// </summary>
        [JsonProperty("quest")]
        [Display(Name = "Quest")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.QuestFailure, EmoteCategory.QuestSuccess, EmoteCategory.TestSuccess, EmoteCategory.TestFailure })]
        public string Quest { get; set; }

        /// <summary>
        /// used for Category == Vendor
        /// </summary>
        [JsonProperty("vendorType")]
        [Display(Name = "Vendor Type")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.Vendor })]
        public uint? VendorType { get; set; }

        /// <summary>
        /// used for Category == WoundedTaunt
        /// </summary>
        [JsonProperty("minHealth")]
        [Display(Name = "Minimum Health")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.WoundedTaunt })]
        public float? MinHealth { get; set; }

        /// <summary>
        /// used for Category == WoundedTaunt
        /// </summary>
        [JsonProperty("maxHealth")]
        [Display(Name = "Maximum Health")]
        [EmoteCategory(new EmoteCategory[] { EmoteCategory.WoundedTaunt })]
        public float? MaxHealth { get; set; }

        [JsonIgnore]
        [Display(Name = "Emote Type")]
        public EmoteType NewEmoteType { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        /// <summary>
        /// checks the EmoteType attributes of the requested property to determine whether or not
        /// it should be shown
        /// </summary>
        public static bool IsPropertyVisible(string propertyName, EmoteCategory category)
        {
            var property = typeof(EmoteSet).GetProperty(propertyName);
            var attribs = property.GetCustomAttributes(typeof(EmoteCategoryAttribute), false).Cast<EmoteCategoryAttribute>().ToList();

            if (attribs == null || attribs.Count < 1)
                return true;

            // because the lists are long and could get unwieldy, we'll allow for multiple on the same property
            return attribs.Any(a => a.CategoryList.Contains(category));
        }
    }
}
