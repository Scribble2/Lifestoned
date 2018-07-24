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
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Shared
{
    public class AbilitySet
    {
        [JsonProperty("strength")]
        public Ability Strength { get; set; } = new Ability() { AbilityId = (int)AbilityId.Strength, Base = 10 };

        [JsonProperty("endurance")]
        public Ability Endurance { get; set; } = new Ability() { AbilityId = (int)AbilityId.Endurance, Base = 10 };

        [JsonProperty("coordination")]
        public Ability Coordination { get; set; } = new Ability() { AbilityId = (int)AbilityId.Coordination, Base = 10 };

        [JsonProperty("quickness")]
        public Ability Quickness { get; set; } = new Ability() { AbilityId = (int)AbilityId.Quickness, Base = 10 };

        [JsonProperty("focus")]
        public Ability Focus { get; set; } = new Ability() { AbilityId = (int)AbilityId.Focus, Base = 10 };

        [JsonProperty("self")]
        public Ability Self { get; set; } = new Ability() { AbilityId = (int)AbilityId.Self, Base = 10 };
    }
}
