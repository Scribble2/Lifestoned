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

namespace Lifestoned.DataModel.Gdle
{
    public class XYZ
    {
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }

        [JsonProperty("z")]
        public float Z { get; set; }

		[JsonIgnore]
        public string Display
        {
            get { return $"{X:0.000000} {Y:0.000000} {Z:0.000000}"; }
            set
            {
                int start = 0;
                int pos = value != null ? value.IndexOf(' ') : -1;
                if (pos < 0)
                {
                    X = 0.0f;
                    Y = 0.0f;
                    Z = 0.0f;
                    return;
                }

                float tx = 0.0f;
                float ty = 0.0f;
                float tz = 0.0f;

                float.TryParse(value.Substring(start, pos - start), out tx);

                start = pos + 1;
                pos = value.IndexOf(' ', start);
                float.TryParse(value.Substring(start, pos - start), out ty);

                start = pos + 1;
                float.TryParse(value.Substring(start), out tz);

                X = tx;
                Y = ty;
                Z = tz;
            }
        }
    }
}
