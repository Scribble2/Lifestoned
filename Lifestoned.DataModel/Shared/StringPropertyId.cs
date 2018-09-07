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
    public enum StringPropertyId
    {
        [Display(Name = "00 - Undefined")]
        Undef = 0,

        [Display(Name = "01 - Name")]
        Name = 1,

        [Display(Name = "02 - Title")]
        Title = 2,

        [Display(Name = "03 - Sex")]
        Sex = 3,

        [Display(Name = "04 - Heritage Group")]
        HeritageGroup = 4,

        [Display(Name = "05 - Template")]
        Template = 5,

        [Display(Name = "06 - Attacker Name")]
        AttackersName = 6,

        [Display(Name = "07 - Inscription")]
        Inscription = 7,

        [Display(Name = "08 - Scribe Name")]
        ScribeName = 8,

        [Display(Name = "09 - Vendor's Name")]
        VendorsName = 9,

        [Display(Name = "10 - Fellowship")]
        Fellowship = 10,

        [Display(Name = "11 - Monarch's Name")]
        MonarchsName = 11,

        [Display(Name = "12 - Lock Code")]
        LockCode = 12,

        [Display(Name = "13 - Key Code")]
        KeyCode = 13,

        [Display(Name = "14 - Use")]
        Use = 14,

        [Display(Name = "15 - Short Description")]
        ShortDesc = 15,

        [Display(Name = "16 - Long Description")]
        LongDesc = 16,

        [Display(Name = "17 - Activation Talk")]
        ActivationTalk = 17,

        [Display(Name = "18 - Use Message")]
        UseMessage = 18,

        [Display(Name = "19 - Item Heritage Group Restriction")]
        ItemHeritageGroupRestriction = 19,

        [Display(Name = "20 - Pluaral Name")]
        PluralName = 20,

        [Display(Name = "21 - Monarch's Title")]
        MonarchsTitle = 21,

        [Display(Name = "22 - Activation Failure")]
        ActivationFailure = 22,

        [Display(Name = "23 - Scribe Account")]
        ScribeAccount = 23,

        [Display(Name = "24 - Town Name")]
        TownName = 24,

        [Display(Name = "25 - Craftsman Name")]
        CraftsmanName = 25,

        [Display(Name = "26 - Use Pk Server Error")]
        UsePkServerError = 26,

        [Display(Name = "27 - Score Cached Text")]
        ScoreCachedText = 27,

        [Display(Name = "28 - Score Default Entry Format")]
        ScoreDefaultEntryFormat = 28,

        [Display(Name = "29 - Score First Entry Format")]
        ScoreFirstEntryFormat = 29,

        [Display(Name = "30 - Score Last Entry Format")]
        ScoreLastEntryFormat = 30,

        [Display(Name = "31 - Score Only Entry Format")]
        ScoreOnlyEntryFormat = 31,

        [Display(Name = "32 - Score No Entry")]
        ScoreNoEntry = 32,

        [Display(Name = "33 - Quest")]
        Quest = 33,

        [Display(Name = "34 - Generator Event")]
        GeneratorEvent = 34,

        [Display(Name = "35 - Patron's Title")]
        PatronsTitle = 35,

        [Display(Name = "36 - House Owner Name")]
        HouseOwnerName = 36,

        [Display(Name = "37 - Quest Restriction")]
        QuestRestriction = 37,

        [Display(Name = "38 - Appraisal Portal Destination")]
        AppraisalPortalDestination = 38,

        [Display(Name = "39 - Tinker Name")]
        TinkerName = 39,

        [Display(Name = "40 - Imbuer Name")]
        ImbuerName = 40,

        [Display(Name = "41 - House Owner Account")]
        HouseOwnerAccount = 41,

        [Display(Name = "42 - Display Name")]
        DisplayName = 42,

        [Display(Name = "43 - Date of Birth")]
        DateOfBirth = 43,

        [Display(Name = "44 - Third Party Api")]
        ThirdPartyApi = 44,

        [Display(Name = "45 - Kill Quest")]
        KillQuest = 45,

        [Display(Name = "46 - AFK")]
        Afk = 46,

        [Display(Name = "47 - Allegiance Name")]
        AllegianceName = 47,

        [Display(Name = "48 - Augmentation Add Quest")]
        AugmentationAddQuest = 48,

        [Display(Name = "49 - Kill Quest 2")]
        KillQuest2 = 49,

        [Display(Name = "50 - Kill Quest 3")]
        KillQuest3 = 50,

        [Display(Name = "51 - Use Sends Signal")]
        UseSendsSignal = 51,

        [Display(Name = "52 - Gear Plating Name")]
        GearPlatingName = 52
    }

    public static class PropertyStringExtensions
    {
        public static string GetDescription(this StringPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this StringPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
