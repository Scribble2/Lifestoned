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
    public enum WeaponType
    {
        [Display(Name = "00 - Undefined")]
        Undefined = 0,
        [Display(Name = "01 - Unarmed")]
        Unarmed = 1,
        [Display(Name = "02 - Sword")]
        Sword = 2,
        [Display(Name = "03 - Axe")]
        Axe = 3,
        [Display(Name = "04 - Mace")]
        Mace = 4,
        [Display(Name = "05 - Spear")]
        Spear = 5,
        [Display(Name = "06 - Dagger")]
        Dagger = 6,
        [Display(Name = "07 - Staff")]
        Staff = 7,
        [Display(Name = "08 - Bow")]
        Bow = 8,
        [Display(Name = "09 - Crossbow")]
        Crossbow = 9,
        [Display(Name = "10 - Thrown Weapons")]
        ThrownWeapons = 10,
        [Display(Name = "11 - Two Handed")]
        TwoHanded = 11,
        [Display(Name = "12 - Magic")]
        Magic = 12,
    }

    public static class WeaponTypeExtensions
    {
        public static string GetDescription(this WeaponType? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this WeaponType? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
