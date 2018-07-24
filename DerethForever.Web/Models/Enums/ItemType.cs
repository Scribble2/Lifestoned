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
    public enum ItemType : uint
    {
        [Display(Name = "0x00000000 - None")]
        None                       = 0x00000000,

        [Display(Name = "0x00000001 - Melee Weapon")]
        MeleeWeapon                = 0x00000001,

        [Display(Name = "0x00000002 - Armor")]
        Armor                      = 0x00000002,

        [Display(Name = "0x00000004 - Clothing")]
        Clothing                   = 0x00000004,

        [Display(Name = "0x00000008 - Jewelry")]
        Jewelry                    = 0x00000008,

        [Display(Name = "0x00000010 - Creature")]
        Creature                   = 0x00000010,

        [Display(Name = "0x00000020 - Food")]
        Food                       = 0x00000020,

        [Display(Name = "0x00000040 - Money")]
        Money                      = 0x00000040,

        [Display(Name = "0x00000080 - Misc")]
        Misc                       = 0x00000080,

        [Display(Name = "0x00000100 - Missile Weapon")]
        MissileWeapon              = 0x00000100,

        [Display(Name = "0x00000200 - Container")]
        Container                  = 0x00000200,

        [Display(Name = "0x00000400 - Useless")]
        Useless                    = 0x00000400,

        [Display(Name = "0x00000800 - Gem")]
        Gem                        = 0x00000800,

        [Display(Name = "0x00001000 - Spell Components")]
        SpellComponents            = 0x00001000,

        [Display(Name = "0x00002000 - Writable")]
        Writable                   = 0x00002000,

        [Display(Name = "0x00004000 - Key")]
        Key                        = 0x00004000,

        [Display(Name = "0x00008000 - Caster")]
        Caster                     = 0x00008000,

        [Display(Name = "0x00010000 - Portal")]
        Portal                     = 0x00010000,

        [Display(Name = "0x00020000 - Lockable")]
        Lockable                   = 0x00020000,

        [Display(Name = "0x00040000 - Promissory Note")]
        PromissoryNote             = 0x00040000,

        [Display(Name = "0x00080000 - Mana Stone")]
        ManaStone                  = 0x00080000,

        [Display(Name = "0x00100000 - Service")]
        Service                    = 0x00100000,

        [Display(Name = "0x00200000 - Magic Wield-able")]
        MagicWieldable             = 0x00200000,

        [Display(Name = "0x00400000 - Cooking")]
        CraftCookingBase           = 0x00400000,

        [Display(Name = "0x00800000 - Alchemy")]
        CraftAlchemyBase           = 0x00800000,

        // never occurred in pcaps
        [Display(Name = "0x02000000 - Fletching")]
        CraftFletchingBase         = 0x02000000,

        [Display(Name = "0x04000000 - Alchemy Intermediate")]
        CraftAlchemyIntermediate   = 0x04000000,

        [Display(Name = "0x08000000 - Fletching Intermediate")]
        CraftFletchingIntermediate = 0x08000000,

        [Display(Name = "0x10000000 - Lifestone")]
        LifeStone                  = 0x10000000,

        [Display(Name = "0x20000000 - Tinkering Tool")]
        TinkeringTool              = 0x20000000,

        [Display(Name = "0x40000000 - Tinkering Material")]
        TinkeringMaterial          = 0x40000000,

        [Display(Name = "0x80000000 - Game-board")]
        Gameboard                  = 0x80000000,

        [Display(Name = "0x80000021 - DO NOT USE")]
        Default                    = 0x80000021,

        [Display(Name = "0x03000000 - DO NOT USE")]
        NotUsed                    = 0x03000000
    }
}
