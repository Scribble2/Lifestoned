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
    public enum PhysicsScriptType
    {
        [Display(Name               = "000 - Invalid")]
        Invalid                     = 0,
        [Display(Name               = "001 - Test 1")]
        Test1                       = 1,
        [Display(Name               = "002 - Test 2")]
        Test2                       = 2,
        [Display(Name               = "003 - Test 3")]
        Test3                       = 3,
        [Display(Name               = "004 - Launch")]
        Launch                      = 4,
        [Display(Name               = "005 - Explode")]
        Explode                     = 5,
        [Display(Name               = "006 - Attribute Up Red")]
        AttribUpRed                 = 6,
        [Display(Name               = "007 - AttributeDown Red")]
        AttribDownRed               = 7,
        [Display(Name               = "008 - AttributeUp Orange")]
        AttribUpOrange              = 8,
        [Display(Name               = "009 - AttributeDown Orange")]
        AttribDownOrange            = 9,
        [Display(Name               = "010 - AttributeUp Yellow")]
        AttribUpYellow              = 10,
        [Display(Name               = "011 - AttributeDown Yellow")]
        AttribDownYellow            = 11,
        [Display(Name               = "012 - AttributeUp Green")]
        AttribUpGreen               = 12,
        [Display(Name               = "013 - AttributeDown Green")]
        AttribDownGreen             = 13,
        [Display(Name               = "014 - AttributeUp Blue")]
        AttribUpBlue                = 14,
        [Display(Name               = "015 - AttributeDown Blue")]
        AttribDownBlue              = 15,
        [Display(Name               = "016 - AttributeUp Purple")]
        AttribUpPurple              = 16,
        [Display(Name               = "017 - AttributeDown Purple")]
        AttribDownPurple            = 17,
        [Display(Name               = "018 - Skill Up Red")]
        SkillUpRed                  = 18,
        [Display(Name               = "019 - Skill Down Red")]
        SkillDownRed                = 19,
        [Display(Name               = "020 - Skill Up Orange")]
        SkillUpOrange               = 20,
        [Display(Name               = "021 - Skill Down Orange")]
        SkillDownOrange             = 21,
        [Display(Name               = "022 - Skill Up Yellow")]
        SkillUpYellow               = 22,
        [Display(Name               = "023 - Skill Down Yellow")]
        SkillDownYellow             = 23,
        [Display(Name               = "024 - Skill Up Green")]
        SkillUpGreen                = 24,
        [Display(Name               = "025 - Skill Down Green")]
        SkillDownGreen              = 25,
        [Display(Name               = "026 - Skill Up Blue")]
        SkillUpBlue                 = 26,
        [Display(Name               = "027 - Skill Down Blue")]
        SkillDownBlue               = 27,
        [Display(Name               = "028 - Skill Up Purple")]
        SkillUpPurple               = 28,
        [Display(Name               = "029 - Skill Down Purple")]
        SkillDownPurple             = 29,
        [Display(Name               = "030 - Skill Down Black")]
        SkillDownBlack              = 30,
        [Display(Name               = "031 - Health Up Red")]
        HealthUpRed                 = 31,
        [Display(Name               = "032 - Health Down Red")]
        HealthDownRed               = 32,
        [Display(Name               = "033 - Health Up Blue")]
        HealthUpBlue                = 33,
        [Display(Name               = "034 - Health Down Blue")]
        HealthDownBlue              = 34,
        [Display(Name               = "035 - Health Up Yellow")]
        HealthUpYellow              = 35,
        [Display(Name               = "036 - Health Down Yellow")]
        HealthDownYellow            = 36,
        [Display(Name               = "037 - Regen Up Red")]
        RegenUpRed                  = 37,
        [Display(Name               = "038 - Regen Down R Ed")]
        RegenDownREd                = 38,
        [Display(Name               = "039 - Regen Up Blue")]
        RegenUpBlue                 = 39,
        [Display(Name               = "040 - Regen Down Blue")]
        RegenDownBlue               = 40,
        [Display(Name               = "041 - Regen Up Yellow")]
        RegenUpYellow               = 41,
        [Display(Name               = "042 - Regen Down Yellow")]
        RegenDownYellow             = 42,
        [Display(Name               = "043 - Shield Up Red")]
        ShieldUpRed                 = 43,
        [Display(Name               = "044 - Shield Down Red")]
        ShieldDownRed               = 44,
        [Display(Name               = "045 - Shield Up Orange")]
        ShieldUpOrange              = 45,
        [Display(Name               = "046 - Shield Down Orange")]
        ShieldDownOrange            = 46,
        [Display(Name               = "047 - Shield Up Yellow")]
        ShieldUpYellow              = 47,
        [Display(Name               = "048 - Shield Down Yellow")]
        ShieldDownYellow            = 48,
        [Display(Name               = "049 - Shield Up Green")]
        ShieldUpGreen               = 49,
        [Display(Name               = "050 - Shield Down Green")]
        ShieldDownGreen             = 50,
        [Display(Name               = "051 - Shield Up Blue")]
        ShieldUpBlue                = 51,
        [Display(Name               = "052 - Shield Down Blue")]
        ShieldDownBlue              = 52,
        [Display(Name               = "053 - Shield Up Purple")]
        ShieldUpPurple              = 53,
        [Display(Name               = "054 - Shield Down Purple")]
        ShieldDownPurple            = 54,
        [Display(Name               = "055 - Shield Up Grey")]
        ShieldUpGrey                = 55,
        [Display(Name               = "056 - Shield Down Grey")]
        ShieldDownGrey              = 56,
        [Display(Name               = "057 - Enchant Up Red")]
        EnchantUpRed                = 57,
        [Display(Name               = "058 - Enchant Down Red")]
        EnchantDownRed              = 58,
        [Display(Name               = "059 - Enchant Up Orange")]
        EnchantUpOrange             = 59,
        [Display(Name               = "060 - Enchant Down Orange")]
        EnchantDownOrange           = 60,
        [Display(Name               = "061 - Enchant Up Yellow")]
        EnchantUpYellow             = 61,
        [Display(Name               = "062 - Enchant Down Yellow")]
        EnchantDownYellow           = 62,
        [Display(Name               = "063 - Enchant Up Green")]
        EnchantUpGreen              = 63,
        [Display(Name               = "064 - Enchant Down Green")]
        EnchantDownGreen            = 64,
        [Display(Name               = "065 - Enchant Up Blue")]
        EnchantUpBlue               = 65,
        [Display(Name               = "066 - Enchant Down Blue")]
        EnchantDownBlue             = 66,
        [Display(Name               = "067 - Enchant Up Purple")]
        EnchantUpPurple             = 67,
        [Display(Name               = "068 - Enchant Down Purple")]
        EnchantDownPurple           = 68,
        [Display(Name               = "069 - Vitae Up White")]
        VitaeUpWhite                = 69,
        [Display(Name               = "070 - Vitae Down Black")]
        VitaeDownBlack              = 70,
        [Display(Name               = "071 - Vision Up White")]
        VisionUpWhite               = 71,
        [Display(Name               = "072 - Vision Down Black")]
        VisionDownBlack             = 72,
        [Display(Name               = "073 - Swap Health Red To Yellow")]
        SwapHealthRedToYellow       = 73,
        [Display(Name               = "074 - Swap Health Red To Blue")]
        SwapHealthRedToBlue         = 74,
        [Display(Name               = "075 - Swap Health Yellow To Red")]
        SwapHealthYellowToRed       = 75,
        [Display(Name               = "076 - Swap Health Yellow To Blue")]
        SwapHealthYellowToBlue      = 76,
        [Display(Name               = "077 - Swap Health Blue To Red")]
        SwapHealthBlueToRed         = 77,
        [Display(Name               = "078 - Swap Health Blue To Yellow")]
        SwapHealthBlueToYellow      = 78,
        [Display(Name               = "079 - Trans Up White")]
        TransUpWhite                = 79,
        [Display(Name               = "080 - Trans Down Black")]
        TransDownBlack              = 80,
        [Display(Name               = "081 - Fizzle")]
        Fizzle                      = 81,
        [Display(Name               = "082 - Portal Entry")]
        PortalEntry                 = 82,
        [Display(Name               = "083 - Portal Exit")]
        PortalExit                  = 83,
        [Display(Name               = "084 - Breathe Flame")]
        BreatheFlame                = 84,
        [Display(Name               = "085 - Breathe Frost")]
        BreatheFrost                = 85,
        [Display(Name               = "086 - Breathe Acid")]
        BreatheAcid                 = 86,
        [Display(Name               = "087 - Breathe Lightning")]
        BreatheLightning            = 87,
        [Display(Name               = "088 - Create")]
        Create                      = 88,
        [Display(Name               = "089 - Destroy")]
        Destroy                     = 89,
        [Display(Name               = "090 - Projectile Collision")]
        ProjectileCollision         = 90,
        [Display(Name               = "091 - Splatter Low Left Back")]
        SplatterLowLeftBack         = 91,
        [Display(Name               = "092 - Splatter Low Left Front")]
        SplatterLowLeftFront        = 92,
        [Display(Name               = "093 - Splatter Low Right Back")]
        SplatterLowRightBack        = 93,
        [Display(Name               = "094 - Splatter Low Right Front")]
        SplatterLowRightFront       = 94,
        [Display(Name               = "095 - Splatter Mid Left Back")]
        SplatterMidLeftBack         = 95,
        [Display(Name               = "096 - Splatter Mid Left Front")]
        SplatterMidLeftFront        = 96,
        [Display(Name               = "097 - Splatter Mid Right Back")]
        SplatterMidRightBack        = 97,
        [Display(Name               = "098 - Splatter Mid Right Front")]
        SplatterMidRightFront       = 98,
        [Display(Name               = "099 - Splatter Up Left Back")]
        SplatterUpLeftBack          = 99,
        [Display(Name               = "100 - Splatter Up Left Front")]
        SplatterUpLeftFront         = 100,
        [Display(Name               = "101 - Splatter Up Right Back")]
        SplatterUpRightBack         = 101,
        [Display(Name               = "102 - Splatter Up Right Front")]
        SplatterUpRightFront        = 102,
        [Display(Name               = "103 - Spark Low Left Back")]
        SparkLowLeftBack            = 103,
        [Display(Name               = "104 - Spark Low Left Front")]
        SparkLowLeftFront           = 104,
        [Display(Name               = "105 - Spark Low Right Back")]
        SparkLowRightBack           = 105,
        [Display(Name               = "106 - Spark Low Right Front")]
        SparkLowRightFront          = 106,
        [Display(Name               = "107 - Spark Mid Left Back")]
        SparkMidLeftBack            = 107,
        [Display(Name               = "108 - Spark Mid Left Front")]
        SparkMidLeftFront           = 108,
        [Display(Name               = "109 - Spark Mid Right Back")]
        SparkMidRightBack           = 109,
        [Display(Name               = "110 - Spark Mid Right Front")]
        SparkMidRightFront          = 110,
        [Display(Name               = "111 - Spark Up Left Back")]
        SparkUpLeftBack             = 111,
        [Display(Name               = "112 - Spark Up Left Front")]
        SparkUpLeftFront            = 112,
        [Display(Name               = "113 - Spark Up Right Back")]
        SparkUpRightBack            = 113,
        [Display(Name               = "114 - Spark Up Right Front")]
        SparkUpRightFront           = 114,
        [Display(Name               = "115 - Portal Storm")]
        PortalStorm                 = 115,
        [Display(Name               = "116 - Hide")]
        Hide                        = 116,
        [Display(Name               = "117 - Unhide")]
        UnHide                      = 117,
        [Display(Name               = "118 - Hidden")]
        Hidden                      = 118,
        [Display(Name               = "119 - Disappear Destroy")]
        DisappearDestroy            = 119,
        [Display(Name               = "120 - Special State 1")]
        SpecialState1               = 120,
        [Display(Name               = "121 - Special State 2")]
        SpecialState2               = 121,
        [Display(Name               = "122 - Special State 3")]
        SpecialState3               = 122,
        [Display(Name               = "123 - Special State 4")]
        SpecialState4               = 123,
        [Display(Name               = "124 - Special State 5")]
        SpecialState5               = 124,
        [Display(Name               = "125 - Special State 6")]
        SpecialState6               = 125,
        [Display(Name               = "126 - Special State 7")]
        SpecialState7               = 126,
        [Display(Name               = "127 - Special State 8")]
        SpecialState8               = 127,
        [Display(Name               = "128 - Special State 9")]
        SpecialState9               = 128,
        [Display(Name               = "129 - Special State 0")]
        SpecialState0               = 129,
        [Display(Name               = "130 - Special State Red")]
        SpecialStateRed             = 130,
        [Display(Name               = "131 - Special State Orange")]
        SpecialStateOrange          = 131,
        [Display(Name               = "132 - Special State Yellow")]
        SpecialStateYellow          = 132,
        [Display(Name               = "133 - Special State Green")]
        SpecialStateGreen           = 133,
        [Display(Name               = "134 - Special State Blue")]
        SpecialStateBlue            = 134,
        [Display(Name               = "135 - Special State Purple")]
        SpecialStatePurple          = 135,
        [Display(Name               = "136 - Special State White")]
        SpecialStateWhite           = 136,
        [Display(Name               = "137 - Special State Black")]
        SpecialStateBlack           = 137,
        [Display(Name               = "138 - Level Up")]
        LevelUp                     = 138,
        [Display(Name               = "139 - Enchant Up Grey")]
        EnchantUpGrey               = 139,
        [Display(Name               = "140 - Enchant Down Grey")]
        EnchantDownGrey             = 140,
        [Display(Name               = "141 - Wedding Bliss")]
        WeddingBliss                = 141,
        [Display(Name               = "142 - Enchant Up White")]
        EnchantUpWhite              = 142,
        [Display(Name               = "143 - Enchant Down White")]
        EnchantDownWhite            = 143,
        [Display(Name               = "144 - Camping Mastery")]
        CampingMastery              = 144,
        [Display(Name               = "145 - Camping Ineptitude")]
        CampingIneptitude           = 145,
        [Display(Name               = "146 - Dispel Life")]
        DispelLife                  = 146,
        [Display(Name               = "147 - Dispel Creature")]
        DispelCreature              = 147,
        [Display(Name               = "148 - Dispel All")]
        DispelAll                   = 148,
        [Display(Name               = "149 - Bunny Smite")]
        BunnySmite                  = 149,
        [Display(Name               = "150 - Bael Zharon Smite")]
        BaelZharonSmite             = 150,
        [Display(Name               = "151 - Wedding Steele")]
        WeddingSteele               = 151,
        [Display(Name               = "152 - Restriction Effect Blue")]
        RestrictionEffectBlue       = 152,
        [Display(Name               = "153 - Restriction Effect Green")]
        RestrictionEffectGreen      = 153,
        [Display(Name               = "154 - Restriction Effect Gold")]
        RestrictionEffectGold       = 154,
        [Display(Name               = "155 - Layingof Hands")]
        LayingofHands               = 155,
        [Display(Name               = "156 - Augmentation Use Attribute")]
        AugmentationUseAttribute    = 156,
        [Display(Name               = "157 - Augmentation Use Skill")]
        AugmentationUseSkill        = 157,
        [Display(Name               = "158 - Augmentation Use Resistances")]
        AugmentationUseResistances  = 158,
        [Display(Name               = "159 - Augmentation Use Other")]
        AugmentationUseOther        = 159,
        [Display(Name               = "160 - Black Madness")]
        BlackMadness                = 160,
        [Display(Name               = "161 - Aetheria Level Up")]
        AetheriaLevelUp             = 161,
        [Display(Name               = "162 - Aetheria Surge Destruction")]
        AetheriaSurgeDestruction    = 162,
        [Display(Name               = "163 - Aetheria Surge Protection")]
        AetheriaSurgeProtection     = 163,
        [Display(Name               = "164 - Aetheria Surge Regeneration")]
        AetheriaSurgeRegeneration   = 164,
        [Display(Name               = "165 - Aetheria Surge Affliction")]
        AetheriaSurgeAffliction     = 165,
        [Display(Name               = "166 - Aetheria Surge Festering")]
        AetheriaSurgeFestering      = 166,
        [Display(Name               = "167 - Health Down Void")]
        HealthDownVoid              = 167,
        [Display(Name               = "168 - Regen Down Void")]
        RegenDownVoid               = 168,
        [Display(Name               = "169 - Skill Down Void")]
        SkillDownVoid               = 169,
        [Display(Name               = "170 - Dirty Fighting Heal Debuff")]
        DirtyFightingHealDebuff     = 170,
        [Display(Name               = "171 - Dirty Fighting Attack Debuff")]
        DirtyFightingAttackDebuff   = 171,
        [Display(Name               = "172 - Dirty Fighting Defense Debuff")]
        DirtyFightingDefenseDebuff  = 172,
        [Display(Name               = "173 - Dirty Fighting Damage Over Time")]
        DirtyFightingDamageOverTime = 173
    }

    public static class PhysicsScriptTypeExtensions
    {
        public static string GetDescription(this PhysicsScriptType prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this PhysicsScriptType prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop.ToString();
        }
    }
}
