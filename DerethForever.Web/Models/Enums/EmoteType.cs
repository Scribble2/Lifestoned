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
    public enum EmoteType
    {
        [Display(Name                 = "000 - Invalid")]
        Invalid                       = 0,
        [Display(Name                 = "000 - Invalid Vendor")]
        InvalidVendor                 = 0,
        [Display(Name                 = "001 - Act")]
        Act                           = 1,
        [Display(Name                 = "002 - Award XP")]
        AwardXP                       = 2,
        [Display(Name                 = "003 - Give")]
        Give                          = 3,
        [Display(Name                 = "004 - Move Home")]
        MoveHome                      = 4,
        [Display(Name                 = "005 - Motion")]
        Motion                        = 5,
        [Display(Name                 = "006 - Move")]
        Move                          = 6,
        [Display(Name                 = "007 - Physics Script")]
        PhysScript                    = 7,
        [Display(Name                 = "008 - Say")]
        Say                           = 8,
        [Display(Name                 = "009 - Sound")]
        Sound                         = 9,
        [Display(Name                 = "010 - Tell")]
        Tell                          = 10,
        [Display(Name                 = "011 - Turn")]
        Turn                          = 11,
        [Display(Name                 = "012 - Turn To Target")]
        TurnToTarget                  = 12,
        [Display(Name                 = "013 - Text Direct")]
        TextDirect                    = 13,
        [Display(Name                 = "014 - Cast Spell")]
        CastSpell                     = 14,
        [Display(Name                 = "015 - Activate")]
        Activate                      = 15,
        [Display(Name                 = "016 - World Broadcast")]
        WorldBroadcast                = 16,
        [Display(Name                 = "017 - Local Broadcast")]
        LocalBroadcast                = 17,
        [Display(Name                 = "018 - Direct Broadcast")]
        DirectBroadcast               = 18,
        [Display(Name                 = "019 - Cast Spell Instant")]
        CastSpellInstant              = 19,
        [Display(Name                 = "020 - Update Quest")]
        UpdateQuest                   = 20,
        [Display(Name                 = "021 - Inquire Quest")]
        InqQuest                      = 21,
        [Display(Name                 = "022 - Stamp Quest")]
        StampQuest                    = 22,
        [Display(Name                 = "023 - Start Event")]
        StartEvent                    = 23,
        [Display(Name                 = "024 - Stop Event")]
        StopEvent                     = 24,
        [Display(Name                 = "025 - BLog")]
        BLog                          = 25,
        [Display(Name                 = "026 - Admin Spam")]
        AdminSpam                     = 26,
        [Display(Name                 = "027 - Teach Spell")]
        TeachSpell                    = 27,
        [Display(Name                 = "028 - Award Skill XP")]
        AwardSkillXP                  = 28,
        [Display(Name                 = "029 - Award Skill Points")]
        AwardSkillPoints              = 29,
        [Display(Name                 = "030 - Inquirer Quest Solves")]
        InqQuestSolves                = 30,
        [Display(Name                 = "031 - Erase Quest")]
        EraseQuest                    = 31,
        [Display(Name                 = "032 - Decrement Quest")]
        DecrementQuest                = 32,
        [Display(Name                 = "033 - Increment Quest")]
        IncrementQuest                = 33,
        [Display(Name                 = "034 - Add Character Title")]
        AddCharacterTitle             = 34,
        [Display(Name                 = "035 - Inquirer Boolean Stat")]
        InqBoolStat                   = 35,
        [Display(Name                 = "036 - Inquire Integer Stat")]
        InqIntStat                    = 36,
        [Display(Name                 = "037 - Inquire Float Stat")]
        InqFloatStat                  = 37,
        [Display(Name                 = "038 - Inquire String Stat")]
        InqStringStat                 = 38,
        [Display(Name                 = "039 - Inquire Attribute Stat")]
        InqAttributeStat              = 39,
        [Display(Name                 = "040 - Inquire Raw Attribute Stat")]
        InqRawAttributeStat           = 40,
        [Display(Name                 = "041 - Inquire Secondary Attribute Stat")]
        InqSecondaryAttributeStat     = 41,
        [Display(Name                 = "042 - Inquire Raw Secondary Attribute Stat")]
        InqRawSecondaryAttributeStat  = 42,
        [Display(Name                 = "043 - Inquire Skill Stat")]
        InqSkillStat                  = 43,
        [Display(Name                 = "044 - Inquire Raw Skill Stat")]
        InqRawSkillStat               = 44,
        [Display(Name                 = "045 - Inquire Skill Trained")]
        InqSkillTrained               = 45,
        [Display(Name                 = "046 - Inquire Skill Specialized")]
        InqSkillSpecialized           = 46,
        [Display(Name                 = "047 - Award Training Credits")]
        AwardTrainingCredits          = 47,
        [Display(Name                 = "048 - Inflict Vitae Penalty")]
        InflictVitaePenalty           = 48,
        [Display(Name                 = "049 - Award Level Proportional XP")]
        AwardLevelProportionalXP      = 49,
        [Display(Name                 = "050 - Award Level Proportional Skill XP")]
        AwardLevelProportionalSkillXP = 50,
        [Display(Name                 = "051 - Inquire Event")]
        InqEvent                      = 51,
        [Display(Name                 = "052 - Force Motion")]
        ForceMotion                   = 52,
        [Display(Name                 = "053 - Set Integer Stat")]
        SetIntStat                    = 53,
        [Display(Name                 = "054 - Increment Integer Stat")]
        IncrementIntStat              = 54,
        [Display(Name                 = "055 - Decrement Integer Stat")]
        DecrementIntStat              = 55,
        [Display(Name                 = "056 - Create Treasure")]
        CreateTreasure                = 56,
        [Display(Name                 = "057 - Reset Home Position")]
        ResetHomePosition             = 57,
        [Display(Name                 = "058 - Inquire Fellow Quest")]
        InqFellowQuest                = 58,
        [Display(Name                 = "059 - Inquire Fellow Number")]
        InqFellowNum                  = 59,
        [Display(Name                 = "060 - Update Fellow Quest")]
        UpdateFellowQuest             = 60,
        [Display(Name                 = "061 - Stamp Fellow Quest")]
        StampFellowQuest              = 61,
        [Display(Name                 = "062 - Award No Share XP")]
        AwardNoShareXP                = 62,
        [Display(Name                 = "063 - Set Sanctuary Position")]
        SetSanctuaryPosition          = 63,
        [Display(Name                 = "064 - Tell Fellow")]
        TellFellow                    = 64,
        [Display(Name                 = "065 - Fellow Broadcast")]
        FellowBroadcast               = 65,
        [Display(Name                 = "066 - Lock Fellow")]
        LockFellow                    = 66,
        [Display(Name                 = "067 - Goto")]
        Goto                          = 67,
        [Display(Name                 = "068 - PopUp")]
        PopUp                         = 68,
        [Display(Name                 = "069 - Set Boolean Stat")]
        SetBoolStat                   = 69,
        [Display(Name                 = "070 - Set Quest Completions")]
        SetQuestCompletions           = 70,
        [Display(Name                 = "071 - Inquire Number Character Titles")]
        InqNumCharacterTitles         = 71,
        [Display(Name                 = "072 - Generate")]
        Generate                      = 72,
        [Display(Name                 = "073 - Pet Cast Spell On Owner")]
        PetCastSpellOnOwner           = 73,
        [Display(Name                 = "074 - Take Items")]
        TakeItems                     = 74,
        [Display(Name                 = "075 - Inquire Yes or No")]
        InqYesNo                      = 75,
        [Display(Name                 = "076 - Inquire Owns Items")]
        InqOwnsItems                  = 76,
        [Display(Name                 = "077 - Delete Self")]
        DeleteSelf                    = 77,
        [Display(Name                 = "078 - Kill Self")]
        KillSelf                      = 78,
        [Display(Name                 = "079 - Update My Quest")]
        UpdateMyQuest                 = 79,
        [Display(Name                 = "080 - Inquire My Quest")]
        InqMyQuest                    = 80,
        [Display(Name                 = "081 - Stamp My Quest")]
        StampMyQuest                  = 81,
        [Display(Name                 = "082 - Inquire My Quest Solves")]
        InqMyQuestSolves              = 82,
        [Display(Name                 = "083 - Erase My Quest")]
        EraseMyQuest                  = 83,
        [Display(Name                 = "084 - Decrement My Quest")]
        DecrementMyQuest              = 84,
        [Display(Name                 = "085 - Increment My Quest")]
        IncrementMyQuest              = 85,
        [Display(Name                 = "086 - Set My Quest Completions")]
        SetMyQuestCompletions         = 86,
        [Display(Name                 = "087 - Move To Position")]
        MoveToPos                     = 87,
        [Display(Name                 = "088 - Local Signal")]
        LocalSignal                   = 88,
        [Display(Name                 = "089 - Inquire Pack Space")]
        InqPackSpace                  = 89,
        [Display(Name                 = "090 - Remove Vitae Penalty")]
        RemoveVitaePenalty            = 90,
        [Display(Name                 = "091 - Set Eye Texture")]
        SetEyeTexture                 = 91,
        [Display(Name                 = "092 - Set Eye Palette")]
        SetEyePalette                 = 92,
        [Display(Name                 = "093 - Set Nose Texture")]
        SetNoseTexture                = 93,
        [Display(Name                 = "094 - Set Nose Palette")]
        SetNosePalette                = 94,
        [Display(Name                 = "095 - Set Mouth Texture")]
        SetMouthTexture               = 95,
        [Display(Name                 = "096 - Set Mouth Palette")]
        SetMouthPalette               = 96,
        [Display(Name                 = "097 - Set Head Object")]
        SetHeadObject                 = 97,
        [Display(Name                 = "098 - Set Head Palette")]
        SetHeadPalette                = 98,
        [Display(Name                 = "099 - Teleport Target")]
        TeleportTarget                = 99,
        [Display(Name                 = "100 - Teleport Self")]
        TeleportSelf                  = 100,
        [Display(Name                 = "101 - Start Barber")]
        StartBarber                   = 101,
        [Display(Name                 = "102 - Inquire Quest Bits On")]
        InqQuestBitsOn                = 102,
        [Display(Name                 = "103 - Inquire Quest Bits Off")]
        InqQuestBitsOff               = 103,
        [Display(Name                 = "104 - Inquire My Quest Bits On")]
        InqMyQuestBitsOn              = 104,
        [Display(Name                 = "105 - Inquire My Quest Bits Off")]
        InqMyQuestBitsOff             = 105,
        [Display(Name                 = "106 - Set Quest Bits On")]
        SetQuestBitsOn                = 106,
        [Display(Name                 = "107 - Set Quest Bits Off")]
        SetQuestBitsOff               = 107,
        [Display(Name                 = "108 - Set MyQuest Bits On")]
        SetMyQuestBitsOn              = 108,
        [Display(Name                 = "109 - Set My Quest Bits Off")]
        SetMyQuestBitsOff             = 109,
        [Display(Name                 = "110 - Untrain Skill")]
        UntrainSkill                  = 110,
        [Display(Name                 = "111 - Set Alt Racial Skills")]
        SetAltRacialSkills            = 111,
        [Display(Name                 = "112 - Spend Luminance")]
        SpendLuminance                = 112,
        [Display(Name                 = "113 - Award Luminance")]
        AwardLuminance                = 113,
        [Display(Name                 = "114 - Inquire Integer 64 Stat")]
        InqInt64Stat                  = 114,
        [Display(Name                 = "115 - SetInteger 64 Stat")]
        SetInt64Stat                  = 115,
        [Display(Name                 = "116 - Open Me")]
        OpenMe                        = 116,
        [Display(Name                 = "117 - Close Me")]
        CloseMe                       = 117,
        [Display(Name                 = "118 - Set Float Stat")]
        SetFloatStat                  = 118,
        [Display(Name                 = "119 - Add Contract")]
        AddContract                   = 119,
        [Display(Name                 = "120 - Remove Contract")]
        RemoveContract                = 120,
        [Display(Name                 = "121 - Inquire Contracts Full")]
        InqContractsFull              = 121
    }

    public static class EmoteTypeExtensions
    {
        public static string GetDescription(this EmoteType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString() ?? "";
        }

        public static string GetName(this EmoteType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString() ?? "";
        }
    }
}
