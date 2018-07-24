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
    public enum WeenieType : uint
    {
        [Display(Name           = "000 - Undef")]
        Undef                   = 0,
        [Display(Name           = "001 - Generic")]
        Generic                 = 1,
        [Display(Name           = "002 - Clothing")]
        Clothing                = 2,
        [Display(Name           = "003 - Missile Launcher")]
        MissileLauncher         = 3,
        [Display(Name           = "004 - Missile")]
        Missile                 = 4,
        [Display(Name           = "005 - Ammunition")]
        Ammunition              = 5,
        [Display(Name           = "006 - MeleeWeapon")]
        MeleeWeapon             = 6,
        [Display(Name           = "007 - Portal")]
        Portal                  = 7,
        [Display(Name           = "008 - Book")]
        Book                    = 8,
        [Display(Name           = "009 - Coin")]
        Coin                    = 9,
        [Display(Name           = "010 - Creature")]
        Creature                = 10,
        [Display(Name           = "011 - Admin")]
        Admin                   = 11,
        [Display(Name           = "012 - Vendor")]
        Vendor                  = 12,
        [Display(Name           = "013 - HotSpot")]
        HotSpot                 = 13,
        [Display(Name           = "014 - Corpse")]
        Corpse                  = 14,
        [Display(Name           = "015 - Cow")]
        Cow                     = 15,
        [Display(Name           = "016 - AI")]
        AI                      = 16,
        [Display(Name           = "017 - Machine")]
        Machine                 = 17,
        [Display(Name           = "018 - Food")]
        Food                    = 18,
        [Display(Name           = "019 - Door")]
        Door                    = 19,
        [Display(Name           = "020 - Chest")]
        Chest                   = 20,
        [Display(Name           = "021 - Container")]
        Container               = 21,
        [Display(Name           = "022 - Key")]
        Key                     = 22,
        [Display(Name           = "023 - Lock pick")]
        Lockpick                = 23,
        [Display(Name           = "024 - Pressure Plate")]
        PressurePlate           = 24,
        [Display(Name           = "025 - Life Stone")]
        LifeStone               = 25,
        [Display(Name           = "026 - Switch")]
        Switch                  = 26,
        [Display(Name           = "027 - PK Modifier")]
        PKModifier              = 27,
        [Display(Name           = "028 - Healer")]
        Healer                  = 28,
        [Display(Name           = "029 - LightSource")]
        LightSource             = 29,
        [Display(Name           = "030 - Allegiance")]
        Allegiance              = 30,
        [Display(Name           = "031 - UNKNOWN__GUESSEDNAME32")]
        UNKNOWN__GUESSEDNAME32  = 31,
        [Display(Name           = "032 - SpellComponent")]
        SpellComponent          = 32,
        [Display(Name           = "033 - ProjectileSpell")]
        ProjectileSpell         = 33,
        [Display(Name           = "034 - Scroll")]
        Scroll                  = 34,
        [Display(Name           = "035 - Caster")]
        Caster                  = 35,
        [Display(Name           = "036 - Channel")]
        Channel                 = 36,
        [Display(Name           = "037 - Mana Stone")]
        ManaStone               = 37,
        [Display(Name           = "038 - Gem")]
        Gem                     = 38,
        [Display(Name           = "039 - Advocate Fane")]
        AdvocateFane            = 39,
        [Display(Name           = "040 - AdvocateItem")]
        AdvocateItem            = 40,
        [Display(Name           = "041 - Sentinel")]
        Sentinel                = 41,
        [Display(Name           = "042 - GSpell Economy")]
        GSpellEconomy           = 42,
        [Display(Name           = "043 - LSpell Economy")]
        LSpellEconomy           = 43,
        [Display(Name           = "044 - Craft Tool")]
        CraftTool               = 44,
        [Display(Name           = "045 - LScore Keeper")]
        LScoreKeeper            = 45,
        [Display(Name           = "046 - GScore Keeper")]
        GScoreKeeper            = 46,
        [Display(Name           = "047 - GScore Gatherer")]
        GScoreGatherer          = 47,
        [Display(Name           = "048 - Score Book")]
        ScoreBook               = 48,
        [Display(Name           = "049 - Event Coordinator")]
        EventCoordinator        = 49,
        [Display(Name           = "050 - Entity")]
        Entity                  = 50,
        [Display(Name           = "051 - Stackable")]
        Stackable               = 51,
        [Display(Name           = "052 - HUD")]
        HUD                     = 52,
        [Display(Name           = "053 - House")]
        House                   = 53,
        [Display(Name           = "054 - Deed")]
        Deed                    = 54,
        [Display(Name           = "055 - SlumLord")]
        SlumLord                = 55,
        [Display(Name           = "056 - Hook")]
        Hook                    = 56,
        [Display(Name           = "057 - Storage")]
        Storage                 = 57,
        [Display(Name           = "058 - Boot Spot")]
        BootSpot                = 58,
        [Display(Name           = "059 - House Portal")]
        HousePortal             = 59,
        [Display(Name           = "060 - Game")]
        Game                    = 60,
        [Display(Name           = "061 - GamePiece")]
        GamePiece               = 61,
        [Display(Name           = "062 - Skill Alteration Device")]
        SkillAlterationDevice   = 62,
        [Display(Name           = "063 - Attribute Transfer Device")]
        AttributeTransferDevice = 63,
        [Display(Name           = "064 - Hooker")]
        Hooker                  = 64,
        [Display(Name           = "065 - Allegiance Bind stone")]
        AllegianceBindstone     = 65,
        [Display(Name           = "066 - In Game Stat Keeper")]
        InGameStatKeeper        = 66,
        [Display(Name           = "067 - Augmentation Device")]
        AugmentationDevice      = 67,
        [Display(Name           = "068 - Social Manager")]
        SocialManager           = 68,
        [Display(Name           = "069 - Pet")]
        Pet                     = 69,
        [Display(Name           = "070 - Pet Device")]
        PetDevice               = 70,
        [Display(Name           = "071 - Combat Pet")]
        CombatPet               = 71
    }
}
