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
using DerethForever.Web.Models.Enums;

namespace DerethForever.Web.Models.Shared
{
    /// <summary>
    /// allows for attribute decoration of properties on the Emote class to control
    /// which properties are applicable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EmoteTypeAttribute : Attribute
    {
        public EmoteTypeAttribute() : base()
        {
        }

        public EmoteTypeAttribute(EmoteType emoteType)
        {
            TypeList.Add(emoteType);
        }

        public EmoteTypeAttribute(params EmoteType[] emoteTypes)
        {
            TypeList.AddRange(emoteTypes);
        }

        public EmoteTypeAttribute(params uint[] emoteTypes)
        {
            foreach (uint emoteType in emoteTypes)
                TypeList.Add((EmoteType)emoteType);
        }

        public List<EmoteType> TypeList { get; set; } = new List<EmoteType>();
    }
}
