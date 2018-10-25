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
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class AttributeSet
    {
        [JsonProperty("strength")]
        public Attribute Strength { get; set; }

        [JsonProperty("endurance")]
        public Attribute Endurance { get; set; }

        [JsonProperty("coordination")]
        public Attribute Coordination { get; set; }

        [JsonProperty("quickness")]
        public Attribute Quickness { get; set; }

        [JsonProperty("focus")]
        public Attribute Focus { get; set; }

        [JsonProperty("self")]
        public Attribute Self { get; set; }

        [JsonProperty("health")]
        public Vital Health { get; set; } = new Vital();

        [JsonProperty("stamina")]
        public Vital Stamina { get; set; } = new Vital();

        [JsonProperty("mana")]
        public Vital Mana { get; set; } = new Vital();
    }
}
