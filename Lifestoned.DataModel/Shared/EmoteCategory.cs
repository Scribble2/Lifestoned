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
    public enum EmoteCategory
    {
        [Display(Name = "0 - Invalid")]
        Invalid                   = 0,
        [Display(Name = "1 - Refuse")]
        Refuse                    = 1,
        [Display(Name = "2 - Vendor")]
        Vendor                    = 2,
        [Display(Name = "3 - Death")]
        Death                     = 3,
        [Display(Name = "4 - Portal")]
        Portal                    = 4,
        [Display(Name = "5 - HeartBeat")]
        HeartBeat                 = 5,
        [Display(Name = "6 - Give")]
        Give                      = 6,
        [Display(Name = "7 - Use")]
        Use                       = 7,
        [Display(Name = "8 - Activation")]
        Activation                = 8,
        [Display(Name = "9 - Generation")]
        Generation                = 9,
        [Display(Name = "10 - Pick Up")]
        PickUp                    = 10,
        [Display(Name = "11 - Drop")]
        Drop                      = 11,
        [Display(Name = "12 - Quest Success")]
        QuestSuccess              = 12,
        [Display(Name = "13 - Quest Failure")]
        QuestFailure              = 13,
        [Display(Name = "14 - Taunt")]
        Taunt                     = 14,
        [Display(Name = "15 - Wounded Taunt")]
        WoundedTaunt              = 15,
        [Display(Name = "16 - Kill Taunt")]
        KillTaunt                 = 16,
        [Display(Name = "17 - New Enemy")]
        NewEnemy                  = 17,
        [Display(Name = "18 - Scream")]
        Scream                    = 18,
        [Display(Name = "19 - Homesick")]
        Homesick                  = 19,
        [Display(Name = "20 - Receive Critical")]
        ReceiveCritical           = 20,
        [Display(Name = "21 - Resist Spell")]
        ResistSpell               = 21,
        [Display(Name = "22 - Test Success")]
        TestSuccess               = 22,
        [Display(Name = "23 - Test Failure")]
        TestFailure               = 23,
        [Display(Name = "24 - Hear Chat")]
        HearChat                  = 24,
        [Display(Name = "25 - Wield")]
        Wield                     = 25,
        [Display(Name = "26 - Unwield")]
        UnWield                   = 26,
        [Display(Name = "27 - Event Success")]
        EventSuccess              = 27,
        [Display(Name = "28 - Event Failure")]
        EventFailure              = 28,
        [Display(Name = "29 - Test No Quality")]
        TestNoQuality             = 29,
        [Display(Name = "30 - Quest No Fellowship")]
        QuestNoFellow             = 30,
        [Display(Name = "31 - Test No Fellowship")]
        TestNoFellow              = 31,
        [Display(Name = "32 - Goto Set")]
        GotoSet                   = 32,
        [Display(Name = "33 - Num Fellows Success")]
        NumFellowsSuccess         = 33,
        [Display(Name = "34 - Num Fellows Failure")]
        NumFellowsFailure         = 34,
        [Display(Name = "35 - Num Character Titles Success")]
        NumCharacterTitlesSuccess = 35,
        [Display(Name = "36 - Num Character Titles Failure")]
        NumCharacterTitlesFailure = 36,
        [Display(Name = "37 - Receive Local Signal")]
        ReceiveLocalSignal        = 37,
        [Display(Name = "38 - Receive Talk Direct")]
        ReceiveTalkDirect         = 38
    }

    public static class EmoteCategoryExtensions
    {
        public static string GetDescription(this EmoteCategory prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString() ?? "";
        }

        public static string GetName(this EmoteCategory prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString() ?? "";
        }
    }
}
