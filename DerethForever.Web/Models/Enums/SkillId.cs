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
    public enum SkillId
    {
        Axe,                 /* Retired */
        Bow,                 /* Retired */
        Crossbow,            /* Retired */
        Dagger,              /* Retired */
        Mace,                /* Retired */

        [Display(Name = "Melee Defense")]
        MeleeDefense,

        [Display(Name = "Missile Defense")]
        MissileDefense,

        Sling,               /* Retired */
        Spear,               /* Retired */
        Staff,               /* Retired */
        Sword,               /* Retired */
        ThrownWeapon,        /* Retired */
        UnarmedCombat,       /* Retired */

        [Display(Name = "Arcane Lore")]
        ArcaneLore,

        [Display(Name = "Magic Defense")]
        MagicDefense,

        [Display(Name = "Mana Conversion")]
        ManaConversion,

        Spellcraft,          /* Unimplemented */

        [Display(Name = "Item Tinkering")]
        ItemTinkering,

        [Display(Name = "Assess Person")]
        AssessPerson,

        [Display(Name = "Deception")]
        Deception,

        [Display(Name = "Healing")]
        Healing,

        [Display(Name = "Jump")]
        Jump,

        [Display(Name = "Lockpick")]
        Lockpick,

        [Display(Name = "Run")]
        Run,

        Awareness,           /* Unimplemented */
        ArmsAndArmorRepair,  /* Unimplemented */

        [Display(Name = "Assess Creature")]
        AssessCreature,

        [Display(Name = "Weapon Tinkering")]
        WeaponTinkering,

        [Display(Name = "Armor Tinkering")]
        ArmorTinkering,

        [Display(Name = "Magic Item Tinkering")]
        MagicItemTinkering,

        [Display(Name = "Creature Enchantment")]
        CreatureEnchantment,

        [Display(Name = "Item Enchantment")]
        ItemEnchantment,

        [Display(Name = "Life Magic")]
        LifeMagic,

        [Display(Name = "War Magic")]
        WarMagic,

        [Display(Name = "Leadership")]
        Leadership,

        [Display(Name = "Loyalty")]
        Loyalty,

        [Display(Name = "Fletching")]
        Fletching,

        [Display(Name = "Alchemy")]
        Alchemy,

        [Display(Name = "Cooking")]
        Cooking,

        [Display(Name = "Salvaging")]
        Salvaging,

        [Display(Name = "Two Handed Combat")]
        TwoHandedCombat,

        Gearcraft,           /* Retired */

        [Display(Name = "Void Magic")]
        VoidMagic,

        [Display(Name = "Heavy Weapons")]
        HeavyWeapons,

        [Display(Name = "Light Weapons")]
        LightWeapons,

        [Display(Name = "Finesse Weapons")]
        FinesseWeapons,

        [Display(Name = "Missile Weapons")]
        MissileWeapons,

        [Display(Name = "Shield")]
        Shield,

        [Display(Name = "Dual Wield")]
        DualWield,

        [Display(Name = "Recklessness")]
        Recklessness,

        [Display(Name = "Sneak Attack")]
        SneakAttack,

        [Display(Name = "Dirty Fighting")]
        DirtyFighting,

        Challenge,          /* Unimplemented */

        [Display(Name = "Summoning")]
        Summoning
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
