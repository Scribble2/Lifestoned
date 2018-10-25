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
    public enum UiEffects
    {
        [Display(Name       = "Undef")]
        Undef               = 0x0000,
        [Display(Name       = "Magical")]
        Magical             = 0x0001,
        [Display(Name       = "Poisoned")]
        Poisoned            = 0x0002,
        [Display(Name       = "Boost Health")]
        BoostHealth         = 0x0004,
        [Display(Name       = "Boost Mana")]
        BoostMana           = 0x0008,
        [Display(Name       = "Boost Stamina")]
        BoostStamina        = 0x0010,
        [Display(Name       = "Fire")]
        Fire                = 0x0020,
        [Display(Name       = "Lightning")]
        Lightning           = 0x0040,
        [Display(Name       = "Frost")]
        Frost               = 0x0080,
        [Display(Name       = "Acid")]
        Acid                = 0x0100,
        [Display(Name       = "Bludgeoning")]
        Bludgeoning         = 0x0200,
        [Display(Name       = "Slashing")]
        Slashing            = 0x0400,
        [Display(Name       = "Piercing")]
        Piercing            = 0x0800,
        [Display(Name       = "Nether")]
        Nether              = 0x1000
    }
}
