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
    public class Vital
    {
        [JsonProperty("cp_spent")]
        public uint? XpSpent { get; set; }

        [JsonProperty("level_from_cp")]
        public uint? LevelFromCp { get; set; }

        [JsonProperty("init_level")]
        public uint? Ranks { get; set; }

        [JsonProperty("current")]
        public uint? Current { get; set; }

        public static Vital Convert(DerethForever.Ability ability)
        {
            Vital v = new Vital();
            v.Ranks = ability.Ranks;
            v.Current = ability.Base + ability.Ranks;
            v.XpSpent = ability.ExperienceSpent;
            v.LevelFromCp = 0;
            return v;
        }
    }
}