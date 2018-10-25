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
    public enum ClothingPriority
    {
        [Display(Name    = "000 - Undefined")]
        Undefined        = 0,
        [Display(Name    = "001 - Aqua Blue")]
        AquaBlue         = 1,
        [Display(Name    = "002 - Blue")]
        Blue             = 2,
        [Display(Name    = "003 - Blue Purple")]
        BluePurple       = 3,
        [Display(Name    = "004 - Brown")]
        Brown            = 4,
        [Display(Name    = "005 - Dark Blue")]
        DarkBlue         = 5,
        [Display(Name    = "006 - Deep Brown")]
        DeepBrown        = 6,
        [Display(Name    = "007 - Deep Green")]
        DeepGreen        = 7,
        [Display(Name    = "008 - Green")]
        Green            = 8,
        [Display(Name    = "009 - Grey")]
        Grey             = 9,
        [Display(Name    = "010 - Light Blue")]
        LightBlue        = 10,
        [Display(Name    = "011 - Maroon")]
        Maroon           = 11,
        [Display(Name    = "012 - Navy")]
        Navy             = 12,
        [Display(Name    = "013 - Purple")]
        Purple           = 13,
        [Display(Name    = "014 - Red")]
        Red              = 14,
        [Display(Name    = "015 - Red Purple")]
        RedPurple        = 15,
        [Display(Name    = "016 - Rose")]
        Rose             = 16,
        [Display(Name    = "017 - Yellow")]
        Yellow           = 17,
        [Display(Name    = "018 - Yellow Brown")]
        YellowBrown      = 18,
        [Display(Name    = "019 - Copper")]
        Copper           = 19,
        [Display(Name    = "020 - Silver")]
        Silver           = 20,
        [Display(Name    = "021 - Gold")]
        Gold             = 21,
        [Display(Name    = "022 - Aqua")]
        Aqua             = 22,
        [Display(Name    = "023 - Dark Aqua Metal")]
        DarkAquaMetal    = 23,
        [Display(Name    = "024 - Dark Blue Metal")]
        DarkBlueMetal    = 24,
        [Display(Name    = "025 - Dark Copper Metal")]
        DarkCopperMetal  = 25,
        [Display(Name    = "026 - Dark Gold Metal")]
        DarkGoldMetal    = 26,
        [Display(Name    = "027 - Dark Green Metal")]
        DarkGreenMetal   = 27,
        [Display(Name    = "028 - Dark Purple Metal")]
        DarkPurpleMetal  = 28,
        [Display(Name    = "029 - Dark Red Metal")]
        DarkRedMetal     = 29,
        [Display(Name    = "030 - Dark Silver Metal")]
        DarkSilverMetal  = 30,
        [Display(Name    = "031 - Light Aqua Metal")]
        LightAquaMetal   = 31,
        [Display(Name    = "032 - Light Blue Metal")]
        LightBlueMetal   = 32,
        [Display(Name    = "033 - Light Copper Metal")]
        LightCopperMetal = 33,
        [Display(Name    = "034 - Light Gold Metal")]
        LightGoldMetal   = 34,
        [Display(Name    = "035 - Light Green Metal")]
        LightGreenMetal  = 35,
        [Display(Name    = "036 - Light Purple Metal")]
        LightPurpleMetal = 36,
        [Display(Name    = "037 - Light Red Metal")]
        LightRedMetal    = 37,
        [Display(Name    = "038 - Light Silver Metal")]
        LightSilverMetal = 38,
        [Display(Name    = "039 - Black")]
        Black            = 39,
        [Display(Name    = "040 - Bronze")]
        Bronze           = 40,
        [Display(Name    = "041 - Sandy Yellow")]
        SandyYellow      = 41,
        [Display(Name    = "042 - Dark Brown")]
        DarkBrown        = 42,
        [Display(Name    = "043 - Light Brown")]
        LightBrown       = 43,
        [Display(Name    = "044 - Tan Red")]
        TanRed           = 44,
        [Display(Name    = "045 - Pale Green")]
        PaleGreen        = 45,
        [Display(Name    = "046 - Tan")]
        Tan              = 46,
        [Display(Name    = "047 - Pasty Yellow")]
        PastyYellow      = 47,
        [Display(Name    = "048 - Snowy White")]
        SnowyWhite       = 48,
        [Display(Name    = "049 - Ruddy Yellow")]
        RuddyYellow      = 49,
        [Display(Name    = "050 - Ruddier Yellow")]
        RuddierYellow    = 50,
        [Display(Name    = "051 - Mid Grey")]
        MidGrey          = 51,
        [Display(Name    = "052 - Dark Grey")]
        DarkGrey         = 52,
        [Display(Name    = "053 - Blue Dull Silver")]
        BlueDullSilver   = 53,
        [Display(Name    = "054 - Yellow Pale Silver")]
        YellowPaleSilver = 54,
        [Display(Name    = "055 - Brown Blue Dark")]
        BrownBlueDark    = 55,
        [Display(Name    = "056 - Brown Blue Med")]
        BrownBlueMed     = 56,
        [Display(Name    = "057 - Green Silver")]
        GreenSilver      = 57,
        [Display(Name    = "058 - Brown Green")]
        BrownGreen       = 58,
        [Display(Name    = "059 - Yellow Green")]
        YellowGreen      = 59,
        [Display(Name    = "060 - Pale Purple")]
        PalePurple       = 60,
        [Display(Name    = "061 - White")]
        White            = 61,
        [Display(Name    = "062 - Red Brown")]
        RedBrown         = 62,
        [Display(Name    = "063 - Green Brown")]
        GreenBrown       = 63,
        [Display(Name    = "064 - Orange Brown")]
        OrangeBrown      = 64,
        [Display(Name    = "065 - Pale Green Brown")]
        PaleGreenBrown   = 65,
        [Display(Name    = "066 - Pale Orange")]
        PaleOrange       = 66,
        [Display(Name    = "067 - Green Slime")]
        GreenSlime       = 67,
        [Display(Name    = "068 - Blue Slime")]
        BlueSlime        = 68,
        [Display(Name    = "069 - Yellow Slime")]
        YellowSlime      = 69,
        [Display(Name    = "070 - Purple Slime")]
        PurpleSlime      = 70,
        [Display(Name    = "071 - Dull Red")]
        DullRed          = 71,
        [Display(Name    = "072 - Grey White")]
        GreyWhite        = 72,
        [Display(Name    = "073 - Medium Grey")]
        MediumGrey       = 73,
        [Display(Name    = "074 - Dull Green")]
        DullGreen        = 74,
        [Display(Name    = "075 - Olive Green")]
        Olivegreen       = 75,
        [Display(Name    = "076 - Orange")]
        Orange           = 76,
        [Display(Name    = "077 - Blue Green")]
        BlueGreen        = 77,
        [Display(Name    = "078 - Olive")]
        Olive            = 78,
        [Display(Name    = "079 - Lead")]
        Lead             = 79,
        [Display(Name    = "080 - Iron")]
        Iron             = 80,
        [Display(Name    = "081 - Lite Green")]
        LiteGreen        = 81,
        [Display(Name    = "082 - Pink Purple")]
        PinkPurple       = 82,
        [Display(Name    = "083 - Amber")]
        Amber            = 83,
        [Display(Name    = "084 - Dye Dark Green")]
        DyeDarkGreen     = 84,
        [Display(Name    = "085 - Dye Dark Red")]
        DyeDarkRed       = 85,
        [Display(Name    = "086 - Dye Dark Yellow")]
        DyeDarkYellow    = 86,
        [Display(Name    = "087 - Dye Botched")]
        DyeBotched       = 87,
        [Display(Name    = "088 - Dye Winter Blue")]
        DyeWinterBlue    = 88,
        [Display(Name    = "089 - Dye Winter Green")]
        DyeWinterGreen   = 89,
        [Display(Name    = "090 - Dye Winter Silver")]
        DyeWinterSilver  = 90,
        [Display(Name    = "091 - Dye Spring Blue")]
        DyeSpringBlue    = 91,
        [Display(Name    = "092 - Dye Spring Purple")]
        DyeSpringPurple  = 92,
        [Display(Name    = "093 - Dye Spring Black")]
        DyeSpringBlack   = 93,
    }

    public static class ClothingPriorityExtensions
    {
        public static string GetDescription(this ClothingPriority? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this ClothingPriority? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
