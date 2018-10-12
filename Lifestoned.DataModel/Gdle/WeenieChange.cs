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
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
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

        [JsonProperty("submissionTime")]
        public DateTime SubmissionTime { get; set; }

        public string SubmissionTimeDisplay
        {
            get { return SubmissionTime.ToString("g"); }
        }

        [JsonProperty("discussion")]
        public List<ChangeDiscussionEntry> Discussion { get; set; } = new List<ChangeDiscussionEntry>();

        [JsonIgnore]
        public uint NewCommentWeenieId { get; set; }

        [JsonIgnore]
        public string NewComment { get; set; }

        public static WeenieChange ConvertFromDF(DerethForever.WeenieChange source)
        {
            WeenieChange converted = new WeenieChange();
            converted.Weenie = Weenie.ConvertFromWeenie(source.Weenie);
            converted.UserGuid = source.UserGuid;
            converted.UserName = source.UserName;
            converted.Submitted = source.Submitted;
            converted.SubmissionTime = source.SubmissionTime;
            converted.Discussion = source.Discussion.ToList(); // force a copy
            return converted;
        }
    }
}
