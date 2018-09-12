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

using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class BodyPart
    {
        public BodyPart()
        {
            ArmorValues = new ArmorValues();
            SD = new Zones();
        }

        [JsonProperty("dtype")]
        public int DType { get; set; }

        [JsonIgnore]
        public DamageType DamageType_Binder
        {
            get { return (DamageType)DType; }
            set { DType = (int)value; }
        }

        [JsonProperty("dval")]
        public int DVal { get; set; }

        [JsonProperty("dvar")]
        public float DVar { get; set; }

        [JsonProperty("acache")]
        public ArmorValues ArmorValues { get; set; }

        [JsonProperty("bh")]
        public int BH { get; set; }

        [JsonProperty("bpsd")]
        public Zones SD { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
