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
    public class Frame
    {
        [JsonProperty("origin")]
        public XYZ Position { get; set; } = new XYZ();

        [JsonProperty("angles")]
        public Quaternion Rotations { get; set; } = new Quaternion();

		[JsonIgnore]
        public string Display
        {
            get { return $"[{Position.Display}] {Rotations.Display}"; }
            set
            {
                int pos = value != null ? value.IndexOf(']') : -1;
				if (pos < 0)
                {
                    Position.Display = string.Empty;
                    Rotations.Display = string.Empty;
                    return;
                }

                Position.Display = value.Substring(1, pos - 1);
                Rotations.Display = value.Substring(pos + 2);
            }
        }
    }
}
