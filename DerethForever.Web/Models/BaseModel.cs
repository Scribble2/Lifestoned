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
using Newtonsoft.Json;

namespace DerethForever.Web.Models
{
    /// <summary>
    /// base model that contains anything "standard" on pages like error messages or whatnot
    /// </summary>
    public class BaseModel
    {
        [JsonIgnore]
        public List<string> ErrorMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> SuccessMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> InfoMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> WarningMessages { get; set; } = new List<string>();

        [JsonIgnore]
        public Exception Exception { get; set; }

        public static void CopyBaseData(BaseModel from, BaseModel to)
        {
            if (from == null || to == null)
                return;

            to.ErrorMessages = from.ErrorMessages;
            from.ErrorMessages = new List<string>();
            to.SuccessMessages = from.SuccessMessages;
            from.SuccessMessages = new List<string>();
            to.InfoMessages = from.InfoMessages;
            from.InfoMessages = new List<string>();
            to.WarningMessages = from.WarningMessages;
            from.WarningMessages = new List<string>();
            to.Exception = from.Exception;
            from.Exception = null;
        }
    }
}
