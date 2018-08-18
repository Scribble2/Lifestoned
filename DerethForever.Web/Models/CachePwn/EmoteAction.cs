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

namespace DerethForever.Web.Models.CachePwn
{
    public class EmoteAction
    {
        [JsonProperty("type")]
        public uint EmoteActionType { get; set; }

        [JsonProperty("delay")]
        public float? Delay { get; set; }

        [JsonProperty("extent")]
        public float? Extent { get; set; }

        [JsonProperty("amount")]
        public uint? Amount { get; set; }

        [JsonProperty("motion")]
        public int? Motion { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("amount64")]
        public ulong? Amount64 { get; set; }

        [JsonProperty("heroxp64")]
        public ulong? HeroXp64 { get; set; }

        [JsonProperty("cprof")]
        public CreateItem Item { get; set; }

        [JsonProperty("min64")]
        public long? Minimum64 { get; set; }

        [JsonProperty("max64")]
        public long? Maximum64 { get; set; }

        [JsonProperty("percent")]
        public float? Percent { get; set; }

        [JsonProperty("display")]
        public byte? Display_Binder { get; set; }

        public bool? Display
        {
            get { return (Display_Binder == null) ? (bool?)null : (Display_Binder.Value == 0 ? true : false); }
            set { Display_Binder = (value == null) ? (byte?)null : (value.Value ? (byte)0 : (byte)1); }
        }

        [JsonProperty("max")]
        public uint? Max { get; set; }

        [JsonProperty("min")]
        public uint? Min { get; set; }

        [JsonProperty("fmax")]
        public float? FMax { get; set; }

        [JsonProperty("fmin")]
        public float? FMin { get; set; }

        [JsonProperty("stat")]
        public uint? Stat { get; set; }

        [JsonProperty("pscript")]
        public uint? PScript { get; set; }

        [JsonProperty("sound")]
        public uint? Sound { get; set; }

        [JsonProperty("mPosition")]
        public Position MPosition { get; set; }

        [JsonProperty("frame")]
        public Frame Frame { get; set; }

        [JsonProperty("spellid")]
        public uint? SpellId { get; set; }

        [JsonProperty("teststring")]
        public string TestString { get; set; }

        [JsonProperty("wealth_rating")]
        public uint? WealthRating { get; set; }

        [JsonProperty("treasure_class")]
        public uint? TreasureClass { get; set; }

        [JsonProperty("treasure_type")]
        public int? TreasureType { get; set; }
    }
}
