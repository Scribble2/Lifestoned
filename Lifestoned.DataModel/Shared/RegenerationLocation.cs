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
    public enum RegenerationLocation
    {
        [Display(Name = "000 - Undef")]
        Undef            = 0x000,
        [Display(Name = "001 - On Top")]
        OnTop            = 0x001,
        [Display(Name = "002 - Scatter")]
        Scatter          = 0x002,
        [Display(Name = "004 - Specific")]
        Specific         = 0x004,
        [Display(Name = "008 - Contain")]
        Contain          = 0x008,
        [Display(Name = "016 - Wield")]
        Wield            = 0x010,
        [Display(Name = "032 - Shop")]
        Shop             = 0x020,
        [Display(Name = "056 - Checkpoint")]
        Checkpoint       = 0x038,
        [Display(Name = "064 - Treasure")]
        Treasure         = 0x040,
        [Display(Name = "065 - On Top Treasure")]
        OnTopTreasure    = 0x041,
        [Display(Name = "066 - Scatter Treasure")]
        ScatterTreasure  = 0x042,
        [Display(Name = "068 - Specific Treasure")]
        SpecificTreasure = 0x044,
        [Display(Name = "072 - Contains Treasure")]
        ContainTreasure  = 0x048,
        [Display(Name = "080 - Wield Treasure")]
        WieldTreasure    = 0x050,
        [Display(Name = "096 - Shop Treasure")]
        ShopTreasure     = 0x060
    }
}
