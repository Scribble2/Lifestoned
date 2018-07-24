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

namespace DerethForever.Web.Models.Enums
{
    public enum TreasureClass
    {
        [Display(Name       = "000 - Undef")]
        Undef               = 0,
        [Display(Name       = "001 - Coins")]
        Coins               = 1,
        [Display(Name       = "002 - Gem")]
        Gem                 = 2,
        [Display(Name       = "003 - Jewelry")]
        Jewelry             = 3,
        [Display(Name       = "004 - Art Object")]
        ArtObject           = 4,
        [Display(Name       = "005 - Weapon")]
        Weapon              = 5,
        [Display(Name       = "006 - Armor")]
        Armor               = 6,
        [Display(Name       = "007 - Clothing")]
        Clothing            = 7,
        [Display(Name       = "008 - Scroll")]
        Scroll              = 8,
        [Display(Name       = "009 - Caster")]
        Caster              = 9,
        [Display(Name       = "010 - Mana Stone")]
        ManaStone           = 10,
        [Display(Name       = "011 - Food Drink")]
        FoodDrink           = 11,
        [Display(Name       = "012 - Heal Kit")]
        HealKit             = 12,
        [Display(Name       = "013 - Lockpick")]
        Lockpick            = 13,
        [Display(Name       = "014 - Spell Component")]
        SpellComponent      = 14,
        [Display(Name       = "015 - Leather Armor")]
        LeatherArmor        = 15,
        [Display(Name       = "016 - Studded Leather Armor")]
        StuddedLeatherArmor = 16,
        [Display(Name       = "017 - Chain Mail Armor")]
        ChainMailArmor      = 17,
        [Display(Name       = "018 - Covenant Armor")]
        CovenantArmor       = 18,
        [Display(Name       = "019 - Plate Mail Armor")]
        PlateMailArmor      = 19,
        [Display(Name       = "020 - Heritage Low Armor")]
        HeritageLowArmor    = 20,
        [Display(Name       = "021 - Heritage High Armor")]
        HeritageHighArmor   = 21,
        [Display(Name       = "022 - Sword Weapon")]
        SwordWeapon         = 22,
        [Display(Name       = "023 - Mace Weapon")]
        MaceWeapon          = 23,
        [Display(Name       = "024 - Axe Weapon")]
        AxeWeapon           = 24,
        [Display(Name       = "025 - Spear Weapon")]
        SpearWeapon         = 25,
        [Display(Name       = "026 - Unarmed Weapon")]
        UnarmedWeapon       = 26,
        [Display(Name       = "027 - Staff Weapon")]
        StaffWeapon         = 27,
        [Display(Name       = "028 - Dagger Weapon")]
        DaggerWeapon        = 28,
        [Display(Name       = "029 - Bow Weapon")]
        BowWeapon           = 29,
        [Display(Name       = "030 - Crossbow Weapon")]
        CrossbowWeapon      = 30,
        [Display(Name       = "031 - Atlatl Weapon")]
        AtlatlWeapon        = 31
        // NOTE: some of these are missing this is from the 2005 client pdb.   We believe there are 48 as of 2017 Coral Golem.
    }

    public static class TreasureClassExtensions
    {
        public static string GetDescription(this TreasureClass? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this TreasureClass? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
