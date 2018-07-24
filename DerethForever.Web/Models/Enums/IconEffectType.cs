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
namespace DerethForever.Web.Models.Enums
{
    public enum IconEffectType : uint
    {
        Undef           = 0x0000,
        Magical         = 0x0001,
        Poisoned        = 0x0002,
        BoostHealth     = 0x0004,
        BoostMana       = 0x0008,
        BoostStamina    = 0x0010,
        Fire            = 0x0020,
        Lightning       = 0x0040,
        Frost           = 0x0080,
        Acid            = 0x0100,
        Bludgeoning     = 0x0200,
        Slashing        = 0x0400,
        Piercing        = 0x0800,
        Nether          = 0x1000,
        Default         = 0x0021,
    }
}
