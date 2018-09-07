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
using System.ComponentModel.DataAnnotations;

namespace Lifestoned.DataModel.Shared
{
    [Flags]
    public enum AttackType
    {
        Undef               = 0x0,
        Punch               = 0x1,
        Thrust              = 0x2,
        Slash               = 0x4,
        Kick                = 0x8,
        [Display(Name       = "Offhand Punch")]
        OffhandPunch        = 0x10,
        // Unarmed             = 0x19,
        [Display(Name       = "Double Slash")]
        DoubleSlash         = 0x20,
        [Display(Name       = "Triple Slash")]
        TripleSlash         = 0x40,
        [Display(Name       = "Double Thrust")]
        DoubleThrust        = 0x80,
        [Display(Name       = "Triple Thrust")]
        TripleThrust        = 0x100,
        [Display(Name       = "Offhand Thrust")]
        OffhandThrust       = 0x200,
        [Display(Name       = "Offhand Slash")]
        OffhandSlash        = 0x400,
        [Display(Name       = "Offhand Double Slash")]
        OffhandDoubleSlash  = 0x800,
        [Display(Name       = "Offhand Triple Slash")]
        OffhandTripleSlash  = 0x1000,
        [Display(Name       = "Offhand Double Thrust")]
        OffhandDoubleThrust = 0x2000,
        [Display(Name       = "Offhand Triple Thrust")]
        OffhandTripleThrust = 0x4000,
        // MultiStrike         = 0x79E0
    }
}
