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
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.DF
{
    public class GeneratorTable
    {
        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("weenieClassId")]
        public uint WeenieClassId { get; set; }

        [JsonProperty("delay")]
        public float Delay { get; set; }

        [JsonProperty("initCreate")]
        public uint InitCreate { get; set; }

        [JsonProperty("maxNumber")]
        public uint MaxNumber { get; set; }

        [JsonProperty("whenCreate")]
        public uint WhenCreate { get; set; }

        [JsonIgnore]
        public RegenerationType WhenCreateEnum
        {
            get { return (RegenerationType)WhenCreate; }
            set { WhenCreate = (uint)value; }
        }

        [JsonProperty("whereCreate")]
        public uint WhereCreate { get; set; }

        [JsonIgnore]
        public RegenerationLocation WhereCreateEnum
        {
            get { return (RegenerationLocation)WhereCreate; }
            set { WhereCreate = (uint)value; }
        }

        [JsonProperty("stackSize")]
        public int StackSize { get; set; }

        [JsonProperty("paletteId")]
        public uint PaletteId { get; set; }

        [JsonProperty("slot")]
        public uint Slot { get; set; }

        [JsonProperty("objectCell")]
        public uint ObjectCell { get; set; }

        [JsonProperty("shade")]
        public float Shade { get; set; }

        public Frame Frame { get; set; } = new Frame();

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
