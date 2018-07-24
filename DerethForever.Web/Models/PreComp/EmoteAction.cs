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

namespace DerethForever.Web.Models.PreComp
{
    public class EmoteAction
    {
        public uint Type { get; set; }

        public uint EmoteTypeId
        {
            get { return Type; }
        }

        public float Delay { get; set; }

        public float Extent { get; set; }

        public string Message { get; set; } = "";

        public uint? Min { get; set; }

        public uint? Minimum
        {
            get { return Min; }
        }

        public uint? Max { get; set; }

        public uint? Maximum
        {
            get { return Max; }
        }

        public uint? WealthRating { get; set; }

        public uint? TreasureClass { get; set; }

        public uint? TreasureType { get; set; }

        public uint? Stat { get; set; }

        public long? Min64 { get; set; }

        public long? Minimum64
        {
            get { return Min64; }
        }

        public long? Max64 { get; set; }

        public long? Maximum64
        {
            get { return Max64; }
        }

        public long? Display { get; set; }

        public double? Percent { get; set; }

        public Item Item { get; set; }

        public ulong? Amount64 { get; set; }

        public uint? Amount { get; set; }

        public ulong? HeroXp64 { get; set; }

        public int? Motion { get; set; }

        public uint? SpellId { get; set; }

        public uint? Sound { get; set; }

        public string TestString { get; set; } = "";

        public uint? PScript { get; set; }

        public uint? PhysicsScript
        {
            get { return PScript; }
        }

        public Position Frame { get; set; }
    }
}
