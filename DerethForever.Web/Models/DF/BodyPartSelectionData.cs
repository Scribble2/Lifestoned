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
using Newtonsoft.Json;

namespace DerethForever.Web.Models.DF
{
    public class BodyPartSelectionData
    {
        [JsonProperty("highLeftBack")]
        public double? HighLeftBack { get; set; }

        [JsonProperty("highLeftFront")]
        public double? HighLeftFront { get; set; }

        [JsonProperty("highRightBack")]
        public double? HighRightBack { get; set; }

        [JsonProperty("highRightFront")]
        public double? HighRightFront { get; set; }

        [JsonProperty("lowLeftBack")]
        public double? LowLeftBack { get; set; }

        [JsonProperty("lowLeftFront")]
        public double? LowLeftFront { get; set; }

        [JsonProperty("lowRightBack")]
        public double? LowRightBack { get; set; }

        [JsonProperty("lowRightFront")]
        public double? LowRightFront { get; set; }

        [JsonProperty("midLeftBack")]
        public double? MidLeftBack { get; set; }

        [JsonProperty("midLeftFront")]
        public double? MidLeftFront { get; set; }

        [JsonProperty("midRightBack")]
        public double? MidRightBack { get; set; }

        [JsonProperty("midRightFront")]
        public double? MidRightFront { get; set; }
    }
}
