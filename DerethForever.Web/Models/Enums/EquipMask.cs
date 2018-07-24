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

namespace DerethForever.Web.Models.Enums
{
    /// <summary>
    /// Called Inventory_Loc in the client.
    /// </summary>
    [Flags]
    public enum EquipMask
    {
        Undef            = 0x00000000,
        [Display(Name    = "Head Wear")]
        HeadWear         = 0x00000001,
        [Display(Name    = "Chest Wear")]
        ChestWear        = 0x00000002,
        [Display(Name    = "Abdomen Wear")]
        AbdomenWear      = 0x00000004,
        [Display(Name    = "Upper Arm Wear")]
        UpperArmWear     = 0x00000008,
        [Display(Name    = "Lower Arm Wear")]
        LowerArmWear     = 0x00000010,
        [Display(Name    = "Hand Wear")]
        HandWear         = 0x00000020,
        [Display(Name    = "Upper Leg Wear")]
        UpperLegWear     = 0x00000040,
        [Display(Name    = "Lower Leg Wear")]
        LowerLegWear     = 0x00000080,
        [Display(Name    = "Foot Wear")]
        FootWear         = 0x00000100,
        [Display(Name    = "Chest Armor")]
        ChestArmor       = 0x00000200,
        [Display(Name    = "Abdomen Armor")]
        AbdomenArmor     = 0x00000400,
        [Display(Name    = "Upper Arm Armor")]
        UpperArmArmor    = 0x00000800,
        [Display(Name    = "Lower Arm Armor")]
        LowerArmArmor    = 0x00001000,
        [Display(Name    = "Upper Leg Armor")]
        UpperLegArmor    = 0x00002000,
        [Display(Name    = "Lower Leg Armor")]
        LowerLegArmor    = 0x00004000,
        [Display(Name    = "Neck Wear")]
        NeckWear         = 0x00008000,
        [Display(Name    = "Wrist Left")]
        WristWearLeft    = 0x00010000,
        [Display(Name    = "Wrist Right")]
        WristWearRight   = 0x00020000,
        [Display(Name    = "Finger Left")]
        FingerWearLeft   = 0x00040000,
        [Display(Name    = "Finger Right")]
        FingerWearRight  = 0x00080000,
        [Display(Name    = "Melee Weapon")]
        MeleeWeapon      = 0x00100000,
        [Display(Name    = "Shield")]
        Shield           = 0x00200000,
        [Display(Name    = "Missile Weapon")]
        MissileWeapon    = 0x00400000,
        [Display(Name    = "Missile Ammo")]
        MissileAmmo      = 0x00800000,
        Held             = 0x01000000,
        [Display(Name    = "Two Hand")]
        TwoHanded        = 0x0200000,
        [Display(Name    = "Trinket")]
        TrinketOne       = 0x04000000,
        [Display(Name    = "Cloak")]
        Cloak            = 0x08000000,
        [Display(Name    = "Sigil One")]
        SigilOne         = 0x10000000,
        [Display(Name    = "Sigil Two")]
        SigilTwo         = 0x20000000,
        [Display(Name    = "Sigil Three")]
        SigilThree       = 0x40000000
    }
}
