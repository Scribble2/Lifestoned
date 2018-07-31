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
    public class Page
    {
        [JsonProperty("authorAccount")]
        public string AuthorAccount { get; set; }

        [JsonProperty("authorID")]
        public uint? AuthorId { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("ignoreAuthor")]
        public byte? IgnoreAutor_Binder { get; set; }

        public bool? IgnoreAuthor
        {
            get { return ((IgnoreAutor_Binder == null) ? (bool?)null : (IgnoreAutor_Binder.Value == 0 ? true : false)); }
            set { IgnoreAutor_Binder = (value == null) ? (byte?)null : (value.Value ? (byte)0 : (byte)1); }
        }

        [JsonProperty("pageText")]
        public string PageText { get; set; }
    }
}
