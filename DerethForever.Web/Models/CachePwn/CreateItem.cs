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
using DerethForever.Web.Models.Shared;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.CachePwn
{
    public class CreateItem
    {
        [JsonProperty("wcid")]
        public uint? WeenieClassId { get; set; }

        [JsonProperty("palette")]
        public uint? Palette { get; set; }

        [JsonProperty("shade")]
        public double? Shade { get; set; }

        [JsonProperty("destination")]
        public uint? Destination { get; set; }

        [JsonProperty("stack_size")]
        public int? StackSize { get; set; }

        [JsonProperty("try_to_bond")]
        public byte? TryToBond { get; set; }

        public CreationProfile Convert()
        {
            CreationProfile cp = new CreationProfile()
            {
                // CreationProfileGuid = Guid.NewGuid(),
                Destination = Destination,
                Palette = Palette,
                Shade = Shade,
                StackSize = StackSize,
                TryToBond = TryToBond != null && (TryToBond.Value > 0),
                WeenieClassId = WeenieClassId
            };

            return cp;
        }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
