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

namespace Lifestoned.DataModel.Shared
{
    [Flags]
    public enum CombatStyle
    {
        Undef               = 0x00000,
        Unarmed             = 0x00001,
        OneHanded           = 0x00002,
        OneHandedAndShield  = 0x00004,
        TwoHanded           = 0x00008,
        Bow                 = 0x00010,
        Crossbow            = 0x00020,
        Sling               = 0x00040,
        ThrownWeapon        = 0x00080,
        DualWield           = 0x00100,
        Magic               = 0x00200,
        Atlatl              = 0x00400,
        ThrownShield        = 0x00800,
        Reserved1           = 0x01000,
        Reserved2           = 0x02000,
        Reserved3           = 0x04000,
        Reserved4           = 0x08000,
        StubbornMagic       = 0x10000,
        StubbornProjectile  = 0x20000,
        StubbornMelee       = 0x40000,
        StubbornMissile     = 0x80000,
        Melee               = Unarmed | OneHanded | OneHandedAndShield | TwoHanded | DualWield, // 271
        Missile             = Bow | Crossbow | Sling | ThrownWeapon | Atlatl | ThrownShield, // 3312
        // Magics           = Magic, // 512
        All                 = 65535
    }
}
