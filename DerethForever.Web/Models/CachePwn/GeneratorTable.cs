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
    public class GeneratorTable
    {
        [JsonProperty("delay")]
        public float Delay { get; set; }

        [JsonProperty("frame")]
        public Frame Frame { get; set; } = new Frame();

        [JsonProperty("initCreate")]
        public uint InitCreate { get; set; }

        [JsonProperty("maxNum")]
        public uint MaxNumber { get; set; }

        [JsonProperty("objcell_id")]
        public uint ObjectCell { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("ptid")]
        public uint PaletteId { get; set; }

        [JsonProperty("shade")]
        public float Shade { get; set; }

        [JsonProperty("slot")]
        public uint Slot { get; set; }

        [JsonProperty("stackSize")]
        public int StackSize { get; set; }

        [JsonProperty("type")]
        public uint WeenieClassId { get; set; }

        [JsonProperty("whenCreate")]
        public uint WhenCreate { get; set; }

        [JsonProperty("whereCreate")]
        public uint WhereCreate { get; set; }
    }
}
