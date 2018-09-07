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
    public enum Int64PropertyId
    {
        [Display(Name = "1 - Total Experience")]
        TotalExperience = 1,

        [Display(Name = "2 - Available Experience")]
        AvailableExperience = 2,

        [Display(Name = "3 - Augmentation Cost")]
        AugmentationCost = 3,

        [Display(Name = "4 - Item Total Experience")]
        ItemTotalXp = 4,

        [Display(Name = "5 - Item Base Experience")]
        ItemBaseXp = 5,

        [Display(Name = "6 - Available Luminance")]
        AvailableLuminance = 6,

        [Display(Name = "7 - Maximum Luminance")]
        MaximumLuminance = 7,

        [Display(Name = "8 - Interaction Requirements")]
        InteractionReqs = 8,

        [Display(Name = "9001 - DO NOT USE")]
        DeleteTime = 9001
    }

    public static class PropertyInt64Extensions
    {
        public static string GetName(this Int64PropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
