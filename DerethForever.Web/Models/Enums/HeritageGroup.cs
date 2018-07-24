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
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DerethForever.Web.Models.Enums
{
    public enum HeritageGroup
    {
        [Description("1 - Aluvian")]
        Aluvian             = 1,

        [Description("2 - Gharundim")]
        Gharundim           = 2,

        [Description("3 - Sho")]
        Sho                 = 3,

        [Description("4 - Viamontian")]
        Viamontian          = 4,

        [Description("5 - Umbraen Shadow")]
        UmbraenShadow       = 5,

        [Description("6 - Gear Knight")]
        GearKnight          = 6,

        [Description("7 - Tumerok")]
        Tumerok             = 7,

        [Description("8 - Lugian")]
        Lugian              = 8,

        [Description("9 - Empyrean")]
        Empyrean            = 9,

        [Description("10 - Penumbraen Shadow")]
        PenumbraenShadow    = 10,

        [Description("11 - Undead")]
        Undead              = 11,

        [Description("12 - Olthoi Soldier")]
        OlthoiSoldier       = 12,

        [Description("13 - Olthoi Spitter")]
        OlthoiSpitter       = 13
    }
}
