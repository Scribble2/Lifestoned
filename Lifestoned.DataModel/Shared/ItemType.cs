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
    public enum ItemType : uint
    {
        [Display(Name = "0 - Undefined")]
        None                       = 0x00000000,

        [Display(Name = "1 - Melee Weapon")]
        MeleeWeapon                = 0x00000001,

        [Display(Name = "2 - Armor")]
        Armor                      = 0x00000002,

        [Display(Name = "4 - Clothing")]
        Clothing                   = 0x00000004,

        [Display(Name = "8 - Jewelry")]
        Jewelry                    = 0x00000008,

        [Display(Name = "16 - Creature")]
        Creature                   = 0x00000010,

        [Display(Name = "32 - Food")]
        Food                       = 0x00000020,

        [Display(Name = "64 - Money")]
        Money                      = 0x00000040,

        [Display(Name = "128 - Misc")]
        Misc                       = 0x00000080,

        [Display(Name = "256 - Missile Weapon")]
        MissileWeapon              = 0x00000100,

        [Display(Name = "512 - Container")]
        Container                  = 0x00000200,

        [Display(Name = "1024 - Useless")]
        Useless                    = 0x00000400,

        [Display(Name = "2048 - Gem")]
        Gem                        = 0x00000800,

        [Display(Name = "4096 - Spell Components")]
        SpellComponents            = 0x00001000,

        [Display(Name = "8192 - Writable")]
        Writable                   = 0x00002000,

        [Display(Name = "16384 - Key")]
        Key                        = 0x00004000,

        [Display(Name = "32768 - Caster")]
        Caster                     = 0x00008000,

        [Display(Name = "65536 - Portal")]
        Portal                     = 0x00010000,

        [Display(Name = "131072 - Lockable")]
        Lockable                   = 0x00020000,

        [Display(Name = "262144 - Promissory Note")]
        PromissoryNote             = 0x00040000,

        [Display(Name = "524288 - Mana Stone")]
        ManaStone                  = 0x00080000,

        [Display(Name = "1048576 - Service")]
        Service                    = 0x00100000,

        [Display(Name = "2097152 - Magic Wield-able")]
        MagicWieldable             = 0x00200000,

        [Display(Name = "4194304 - Cooking")]
        CraftCookingBase           = 0x00400000,

        [Display(Name = "8388608 - Alchemy")]
        CraftAlchemyBase           = 0x00800000,

        [Display(Name = "16777216 - Fletching")]
        CraftFletchingBase = 0x01000000,

        [Display(Name = "33554432 - Cooking Intermediate")]
        CraftCookingIntermediate         = 0x02000000,

        [Display(Name = "67108864 - Alchemy Intermediate")]
        CraftAlchemyIntermediate   = 0x04000000,

        [Display(Name = "134217728 - Fletching Intermediate")]
        CraftFletchingIntermediate = 0x08000000,

        [Display(Name = "268435456 - Lifestone")]
        LifeStone                  = 0x10000000,

        [Display(Name = "536870912 - Tinkering Tool")]
        TinkeringTool              = 0x20000000,

        [Display(Name = "1073741824 - Tinkering Material")]
        TinkeringMaterial          = 0x40000000,

        [Display(Name = "-2147483648 - Game-board")]
        Gameboard                  = 0x80000000,

        [Display(Name = "0x80000021 - DO NOT USE")]
        Default                    = 0x80000021,

        [Display(Name = "0x03000000 - DO NOT USE")]
        NotUsed                    = 0x03000000
    }
}
