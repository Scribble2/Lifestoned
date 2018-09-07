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
    public enum CreatureType
    {
        [Display(Name      = "000 - Invalid")]
        Invalid            = 0,
        [Display(Name      = "001 - Olthoi")]
        Olthoi             = 1,
        [Display(Name      = "002 - Banderling")]
        Banderling         = 2,
        [Display(Name      = "003 - Drudge")]
        Drudge             = 3,
        [Display(Name      = "004 - Mosswart")]
        Mosswart           = 4,
        [Display(Name      = "005 - Lugian")]
        Lugian             = 5,
        [Display(Name      = "006 - Tumerok")]
        Tumerok            = 6,
        [Display(Name      = "007 - Mite")]
        Mite               = 7,
        [Display(Name      = "008 - Tusker")]
        Tusker             = 8,
        [Display(Name      = "009 - Phyntos Wasp")]
        PhyntosWasp        = 9,
        [Display(Name      = "010 - Rat")]
        Rat                = 10,
        [Display(Name      = "011 - Auroch")]
        Auroch             = 11,
        [Display(Name      = "012 - Cow")]
        Cow                = 12,
        [Display(Name      = "013 - Golem")]
        Golem              = 13,
        [Display(Name      = "014 - Undead")]
        Undead             = 14,
        [Display(Name      = "015 - Gromnie")]
        Gromnie            = 15,
        [Display(Name      = "016 - Reedshark")]
        Reedshark          = 16,
        [Display(Name      = "017 - Armoredillo")]
        Armoredillo        = 17,
        [Display(Name      = "018 - Fae")]
        Fae                = 18,
        [Display(Name      = "019 - Virindi")]
        Virindi            = 19,
        [Display(Name      = "020 - Wisp")]
        Wisp               = 20,
        [Display(Name      = "021 - Knathtead")]
        Knathtead          = 21,
        [Display(Name      = "022 - Shadow")]
        Shadow             = 22,
        [Display(Name      = "023 - Mattekar")]
        Mattekar           = 23,
        [Display(Name      = "024 - Mumiyah")]
        Mumiyah            = 24,
        [Display(Name      = "025 - Rabbit")]
        Rabbit             = 25,
        [Display(Name      = "026 - Sclavus")]
        Sclavus            = 26,
        [Display(Name      = "027 - Shallows Shark")]
        ShallowsShark      = 27,
        [Display(Name      = "028 - Monouga")]
        Monouga            = 28,
        [Display(Name      = "029 - Zefir")]
        Zefir              = 29,
        [Display(Name      = "030 - Skeleton")]
        Skeleton           = 30,
        [Display(Name      = "031 - Human")]
        Human              = 31,
        [Display(Name      = "032 - Shreth")]
        Shreth             = 32,
        [Display(Name      = "033 - Chittick")]
        Chittick           = 33,
        [Display(Name      = "034 - Moarsman")]
        Moarsman           = 34,
        [Display(Name      = "035 - Olthoi Larvae")]
        OlthoiLarvae       = 35,
        [Display(Name      = "036 - Slithis")]
        Slithis            = 36,
        [Display(Name      = "037 - Deru")]
        Deru               = 37,
        [Display(Name      = "038 - Fire Elemental")]
        FireElemental      = 38,
        [Display(Name      = "039 - Snowman")]
        Snowman            = 39,
        [Display(Name      = "040 - Unknown")]
        Unknown            = 40,
        [Display(Name      = "041 - Bunny")]
        Bunny              = 41,
        [Display(Name      = "042 - Lightning Elemental")]
        LightningElemental = 42,
        [Display(Name      = "043 - Rockslide")]
        Rockslide          = 43,
        [Display(Name      = "044 - Grievver")]
        Grievver           = 44,
        [Display(Name      = "045 - Niffis")]
        Niffis             = 45,
        [Display(Name      = "046 - Ursuin")]
        Ursuin             = 46,
        [Display(Name      = "047 - Crystal")]
        Crystal            = 47,
        [Display(Name      = "048 - Hollow Minion")]
        HollowMinion       = 48,
        [Display(Name      = "049 - Scarecrow")]
        Scarecrow          = 49,
        [Display(Name      = "050 - Idol")]
        Idol               = 50,
        [Display(Name      = "051 - Empyrean")]
        Empyrean           = 51,
        [Display(Name      = "052 - Hopeslayer")]
        Hopeslayer         = 52,
        [Display(Name      = "053 - Doll")]
        Doll               = 53,
        [Display(Name      = "054 - Marionette")]
        Marionette         = 54,
        [Display(Name      = "055 - Carenzi")]
        Carenzi            = 55,
        [Display(Name      = "056 - Siraluun")]
        Siraluun           = 56,
        [Display(Name      = "057 - Aun Tumerok")]
        AunTumerok         = 57,
        [Display(Name      = "058 - Hea Tumerok")]
        HeaTumerok         = 58,
        [Display(Name      = "059 - Simulacrum")]
        Simulacrum         = 59,
        [Display(Name      = "060 - Acid Elemental")]
        AcidElemental      = 60,
        [Display(Name      = "061 - Frost Elemental")]
        FrostElemental     = 61,
        [Display(Name      = "062 - Elemental")]
        Elemental          = 62,
        [Display(Name      = "063 - Statue")]
        Statue             = 63,
        [Display(Name      = "064 - Wall")]
        Wall               = 64,
        [Display(Name      = "065 - Altered Human")]
        AlteredHuman       = 65,
        [Display(Name      = "066 - Device")]
        Device             = 66,
        [Display(Name      = "067 - Harbinger")]
        Harbinger          = 67,
        [Display(Name      = "068 - Dark Sarcophagus")]
        DarkSarcophagus    = 68,
        [Display(Name      = "069 - Chicken")]
        Chicken            = 69,
        [Display(Name      = "070 - Gotrok Lugian")]
        GotrokLugian       = 70,
        [Display(Name      = "071 - Margul")]
        Margul             = 71,
        [Display(Name      = "072 - Bleached Rabbit")]
        BleachedRabbit     = 72,
        [Display(Name      = "073 - Nasty Rabbit")]
        NastyRabbit        = 73,
        [Display(Name      = "074 - Grimacing Rabbit")]
        GrimacingRabbit    = 74,
        [Display(Name      = "075 - Burun")]
        Burun              = 75,
        [Display(Name      = "076 - Target")]
        Target             = 76,
        [Display(Name      = "077 - Ghost")]
        Ghost              = 77,
        [Display(Name      = "078 - Fiun")]
        Fiun               = 78,
        [Display(Name      = "079 - Eater")]
        Eater              = 79,
        [Display(Name      = "080 - Penguin")]
        Penguin            = 80,
        [Display(Name      = "081 - Ruschk")]
        Ruschk             = 81,
        [Display(Name      = "082 - Thrungus")]
        Thrungus           = 82,
        [Display(Name      = "083 - Viamontian Knight")]
        ViamontianKnight   = 83,
        [Display(Name      = "084 - Remoran")]
        Remoran            = 84,
        [Display(Name      = "085 - Swarm")]
        Swarm              = 85,
        [Display(Name      = "086 - Moar")]
        Moar               = 86,
        [Display(Name      = "087 - Enchanted Arms")]
        EnchantedArms      = 87,
        [Display(Name      = "088 - Sleech")]
        Sleech             = 88,
        [Display(Name      = "089 - Mukkir")]
        Mukkir             = 89,
        [Display(Name      = "090 - Merwart")]
        Merwart            = 90,
        [Display(Name      = "091 - Food")]
        Food               = 91,
        [Display(Name      = "092 - Paradox Olthoi")]
        ParadoxOlthoi      = 92,
        [Display(Name      = "093 - Harvest")]
        Harvest            = 93,
        [Display(Name      = "094 - Energy")]
        Energy             = 94,
        [Display(Name      = "095 - Apparition")]
        Apparition         = 95,
        [Display(Name      = "096 - Aerbax")]
        Aerbax             = 96,
        [Display(Name      = "097 - Touched")]
        Touched            = 97,
        [Display(Name      = "098 - Blighted Moarsman")]
        BlightedMoarsman   = 98,
        [Display(Name      = "099 - Gear Knight")]
        GearKnight         = 99,
        [Display(Name      = "100 - Gurog")]
        Gurog              = 100,
        [Display(Name      = "101 - Anekshay")]
        Anekshay           = 101,
    }

    public static class CreatureTypeExtensions
    {
        public static string GetDescription(this CreatureType? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this CreatureType? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
