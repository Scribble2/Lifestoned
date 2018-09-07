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
using System.ComponentModel.DataAnnotations;

namespace Lifestoned.DataModel.Shared
{
    public enum Destination
    {
        [Display(Name = "0x00 - Undefined")]
        Undef                     = 0x0,

        [Display(Name = "0x01 - Contain")]
        Contain                   = 0x1,

        [Display(Name = "0x02 - Wield")]
        Wield                     = 0x2,

        [Display(Name = "0x04 - Shop")]
        Shop                      = 0x4,

        [Display(Name = "0x07 - Checkpoint")]
        Checkpoint                = 0x7,

        [Display(Name = "0x08 - Treasure")]
        Treasure                  = 0x8,

        [Display(Name = "0x09 - Contain Treasure")]
        ContainTreasure           = 0x9,

        [Display(Name = "0x0A - Wield Treasure")]
        WieldTreasure             = 0xA,

        [Display(Name = "0x0C - Shop Treasure")]
        ShopTreasure              = 0xC,

        [Display(Name = "0x10 - House Buy")]
        HouseBuy                  = 0x10,

        [Display(Name = "0x20 - House Rent")]
        HouseRent                 = 0x20,

        [Display(Name = "0x7FFFFFFF - Force Destination")]
        ForceDestinationType32Bit = 0x7FFFFFFF,
    }
}
