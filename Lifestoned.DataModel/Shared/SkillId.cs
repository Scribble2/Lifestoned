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
    public enum SkillId
    {
        [Display(Name = "Axe (DO NOT USE)")]
        Axe = 0x1,                 /* Retired */

        [Display(Name = "Bow (DO NOT USE)")]
        Bow = 0x2,                 /* Retired */

        [Display(Name = "Crossbow (DO NOT USE)")]
        Crossbow = 0x3,            /* Retired */

        [Display(Name = "Dagger (DO NOT USE)")]
        Dagger = 0x4,              /* Retired */

        [Display(Name = "Mace (DO NOT USE)")]
        Mace = 0x5,                /* Retired */
        
        [Display(Name = "Melee Defense")]
        MeleeDefense = 0x6,

        [Display(Name = "Missile Defense")]
        MissileDefense = 0x7,

        [Display(Name = "Sling (DO NOT USE)")]
        Sling = 0x8,               /* Retired */

        [Display(Name = "Spear (DO NOT USE)")]
        Spear = 0x9,               /* Retired */

        [Display(Name = "Staff (DO NOT USE)")]
        Staff = 0xA,               /* Retired */

        [Display(Name = "Sword (DO NOT USE)")]
        Sword = 0xB,               /* Retired */

        [Display(Name = "Thrown Weapon (DO NOT USE)")]
        ThrownWeapon = 0xC,        /* Retired */

        [Display(Name = "Unarmed Combat (DO NOT USE)")]
        UnarmedCombat = 0xD,       /* Retired */

        [Display(Name = "Arcane Lore")]
        ArcaneLore = 0xE,

        [Display(Name = "Magic Defense")]
        MagicDefense = 0xF,

        [Display(Name = "Mana Conversion")]
        ManaConversion = 0x10,

        [Display(Name = "Spellcraft (DO NOT USE)")]
        Spellcraft = 0x11,          /* Unimplemented */

        [Display(Name = "Item Tinkering")]
        ItemTinkering = 0x12,

        [Display(Name = "Assess Person")]
        AssessPerson = 0x13,

        [Display(Name = "Deception")]
        Deception = 0x14,

        [Display(Name = "Healing")]
        Healing = 0x15,

        [Display(Name = "Jump")]
        Jump = 0x16,

        [Display(Name = "Lockpick")]
        Lockpick = 0x17,

        [Display(Name = "Run")]
        Run = 0x18,

        [Display(Name = "Awareness (DO NOT USE)")]
        Awareness = 0x19,           /* Unimplemented */

        [Display(Name = "Arms and Armor Repair (DO NOT USE)")]
        ArmsAndArmorRepair = 0x1A,  /* Unimplemented */

        [Display(Name = "Assess Creature")]
        AssessCreature = 0x1B,

        [Display(Name = "Weapon Tinkering")]
        WeaponTinkering = 0x1C,

        [Display(Name = "Armor Tinkering")]
        ArmorTinkering = 0x1D,

        [Display(Name = "Magic Item Tinkering")]
        MagicItemTinkering = 0x1E,

        [Display(Name = "Creature Enchantment")]
        CreatureEnchantment = 0x1F,

        [Display(Name = "Item Enchantment")]
        ItemEnchantment = 0x20,

        [Display(Name = "Life Magic")]
        LifeMagic = 0x21,

        [Display(Name = "War Magic")]
        WarMagic = 0x22,

        [Display(Name = "Leadership")]
        Leadership = 0x23,

        [Display(Name = "Loyalty")]
        Loyalty = 0x24,

        [Display(Name = "Fletching")]
        Fletching = 0x25,

        [Display(Name = "Alchemy")]
        Alchemy = 0x26,

        [Display(Name = "Cooking")]
        Cooking = 0x27,

        [Display(Name = "Salvaging")]
        Salvaging = 0x28,

        [Display(Name = "Two Handed Combat")]
        TwoHandedCombat = 0x29,

        [Display(Name = "Gear Craft (DO NOT USE)")]
        Gearcraft = 0x1A,           /* Retired */

        [Display(Name = "Void Magic")]
        VoidMagic = 0x2B,

        [Display(Name = "Heavy Weapons")]
        HeavyWeapons = 0x2C,

        [Display(Name = "Light Weapons")]
        LightWeapons = 0x2D,

        [Display(Name = "Finesse Weapons")]
        FinesseWeapons = 0x2E,

        [Display(Name = "Missile Weapons")]
        MissileWeapons = 0x2F,

        [Display(Name = "Shield")]
        Shield = 0x30,

        [Display(Name = "Dual Wield")]
        DualWield = 0x31,

        [Display(Name = "Recklessness")]
        Recklessness = 0x32,

        [Display(Name = "Sneak Attack")]
        SneakAttack = 0x33,

        [Display(Name = "Dirty Fighting")]
        DirtyFighting = 0x34,

        [Display(Name = "Challenge (DO NOT USE)")]
        Challenge = 0x35,          /* Unimplemented */

        [Display(Name = "Summoning")]
        Summoning = 0x36
    }

    public static class SkillIdExtensions
    {
        public static string GetDescription(this SkillId? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this SkillId? prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
