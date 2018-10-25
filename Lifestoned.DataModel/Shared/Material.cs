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
    public enum Material : uint
    {
        Undef         = 0x00000000,
        Ceramic       = 0x00000001,
        Porcelain     = 0x00000002,
        Linen         = 0x00000004,
        Satin         = 0x00000005,
        Silk          = 0x00000006,
        Velvet        = 0x00000007,
        Wool          = 0x00000008,
        Agate         = 0x0000000A,
        Amber         = 0x0000000B,
        Amethyst      = 0x0000000C,
        Aquamarine    = 0x0000000D,
        Azurite       = 0x0000000E,
        [Display(Name = "Black Garnet")] BlackGarnet = 0x0000000F,
        [Display(Name = "Black Opal")] BlackOpal = 0x00000010,
        Bloodstone    = 0x00000011,
        Carnelian     = 0x00000012,
        Citrine       = 0x00000013,
        Diamond       = 0x00000014,
        Emerald       = 0x00000015,
        [Display(Name = "Fire Opal")] FireOpal = 0x00000016,
        [Display(Name = "Green Garnet")] GreenGarnet = 0x00000017,
        [Display(Name = "Green Jade")] GreenJade = 0x00000018,
        Hematite      = 0x00000019,
        [Display(Name = "Imperial Topaz")] ImperialTopaz = 0x0000001A,
        Jet           = 0x0000001B,
        [Display(Name = "Lapis Lazuli")] LapisLazuli = 0x0000001C,
        [Display(Name = "Lavender Jade")] LavenderJade = 0x0000001D,
        Malachite     = 0x0000001E,
        Moonstone     = 0x0000001F,
        Onyx          = 0x00000020,
        Opal          = 0x00000021,
        Peridot       = 0x00000022,
        [Display(Name = "Red Garnet")] RedGarnet = 0x00000023,
        [Display(Name = "Red Jade")] RedJade = 0x00000024,
        [Display(Name = "Rose Quartz")] RoseQuartz = 0x00000025,
        Ruby          = 0x00000026,
        Sapphire      = 0x00000027,
        [Display(Name = "Smokey Quartz")] SmokeyQuartz = 0x00000028,
        Sunstone      = 0x00000029,
        [Display(Name = "Tiger Eye")] TigerEye = 0x0000002A,
        Tourmaline    = 0x0000002B,
        Turquoise     = 0x0000002C,
        [Display(Name = "White Jade")] WhiteJade = 0x0000002D,
        [Display(Name = "White Quartz")] WhiteQuartz = 0x0000002E,
        [Display(Name = "White Sapphire")] WhiteSapphire = 0x0000002F,
        [Display(Name = "Yellow Garnet")] YellowGarnet = 0x00000030,
        [Display(Name = "Yellow Topaz")] YellowTopaz = 0x00000031,
        Zircon        = 0x00000032,
        Ivory         = 0x00000033,
        Leather       = 0x00000034,
        [Display(Name = "Armoredillo Hide")] ArmoredilloHide = 0x00000035,
        [Display(Name = "Gromnie Hide")] GromnieHide = 0x00000036,
        [Display(Name = "Reed Shark Hide")] ReedSharkHide = 0x00000037,
        Brass         = 0x00000039,
        Bronze        = 0x0000003A,
        Copper        = 0x0000003B,
        Gold          = 0x0000003C,
        Iron          = 0x0000003D,
        Pyreal        = 0x0000003E,
        Silver        = 0x0000003F,
        Steel         = 0x00000040,
        Alabaster     = 0x00000042,
        Granite       = 0x00000043,
        Marble        = 0x00000044,
        Obsidian      = 0x00000045,
        Sandstone     = 0x00000046,
        Serpentine    = 0x00000047,
        Ebony         = 0x00000049,
        Mahogany      = 0x0000004A,
        Oak           = 0x0000004B,
        Pine          = 0x0000004C,
        Teak          = 0x0000004D
    }
}
