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
    public enum BoolPropertyId
    {
        [Display(Name                    = "000  -  Undef")]
        Undef                            = 0,
        [Display(Name                    = "001  -  Stuck")]
        Stuck                            = 1,
        [Display(Name                    = "002  -  Open")]
        Open                             = 2,
        [Display(Name                    = "003  -  Locked")]
        Locked                           = 3,
        [Display(Name                    = "004  -  Rot Proof")]
        RotProof                         = 4,
        [Display(Name                    = "005  -  Allegiance Update Request")]
        AllegianceUpdateRequest          = 5,
        [Display(Name                    = "006  -  Ai Uses Mana")]
        AiUsesMana                       = 6,
        [Display(Name                    = "007  -  Ai Use Human Magic Animations")]
        AiUseHumanMagicAnimations        = 7,
        [Display(Name                    = "008  -  Allow Give")]
        AllowGive                        = 8,
        [Display(Name                    = "009  -  Currently Attacking")]
        CurrentlyAttacking               = 9,
        [Display(Name                    = "010  -  Attacker Ai")]
        AttackerAi                       = 10,
        [Display(Name                    = "011  -  Ignore Collisions")]
        IgnoreCollisions                 = 11,
        [Display(Name                    = "012  -  Report Collisions")]
        ReportCollisions                 = 12,
        [Display(Name                    = "013  -  Ethereal")]
        Ethereal                         = 13,
        [Display(Name                    = "014  -  Gravity Status")]
        GravityStatus                    = 14,
        [Display(Name                    = "015  -  Lights Status")]
        LightsStatus                     = 15,
        [Display(Name                    = "016  -  Scripted Collision")]
        ScriptedCollision                = 16,
        [Display(Name                    = "017  -  Inelastic")]
        Inelastic                        = 17,
        [Display(Name                    = "018  -  Visibility")]
        Visibility                       = 18,
        [Display(Name                    = "019  -  Attackable")]
        Attackable                       = 19,
        [Display(Name                    = "020  -  Safe Spell Components")]
        SafeSpellComponents              = 20,
        [Display(Name                    = "021  -  Advocate State")]
        AdvocateState                    = 21,
        [Display(Name                    = "022  -  Inscribable")]
        Inscribable                      = 22,
        [Display(Name                    = "023  -  Destroy On Sell")]
        DestroyOnSell                    = 23,
        [Display(Name                    = "024  -  Ui Hidden")]
        UiHidden                         = 24,
        [Display(Name                    = "025  -  Ignore House Barriers")]
        IgnoreHouseBarriers              = 25,
        [Display(Name                    = "026  -  Hidden Admin")]
        HiddenAdmin                      = 26,
        [Display(Name                    = "027  -  Pk Wounder")]
        PkWounder                        = 27,
        [Display(Name                    = "028  -  Pk Killer")]
        PkKiller                         = 28,
        [Display(Name                    = "029  -  No Corpse")]
        NoCorpse                         = 29,
        [Display(Name                    = "030  -  Under Lifestone Protection")]
        UnderLifestoneProtection         = 30,
        [Display(Name                    = "031  -  Item Mana Update Pending")]
        ItemManaUpdatePending            = 31,
        [Display(Name                    = "032  -  Generator Status")]
        GeneratorStatus                  = 32,
        [Display(Name                    = "033  -  Reset Message Pending")]
        ResetMessagePending              = 33,
        [Display(Name                    = "034  -  Default Open")]
        DefaultOpen                      = 34,
        [Display(Name                    = "035  -  Default Locked")]
        DefaultLocked                    = 35,
        [Display(Name                    = "036  -  Default On")]
        DefaultOn                        = 36,
        [Display(Name                    = "037  -  Open For Business")]
        OpenForBusiness                  = 37,
        [Display(Name                    = "038  -  Is Frozen")]
        IsFrozen                         = 38,
        [Display(Name                    = "039  -  Deal Magical Items")]
        DealMagicalItems                 = 39,
        [Display(Name                    = "040  -  Log off I'm Dead")]
        LogoffImDead                     = 40,
        [Display(Name                    = "041  -  Report Collisions As Environment")]
        ReportCollisionsAsEnvironment    = 41,
        [Display(Name                    = "042  -  Allow Edge Slide")]
        AllowEdgeSlide                   = 42,
        [Display(Name                    = "043  -  Advocate Quest")]
        AdvocateQuest                    = 43,
        [Display(Name                    = "044  -  Is Admin")]
        IsAdmin                          = 44,
        [Display(Name                    = "045  -  Is Arch")]
        IsArch                           = 45,
        [Display(Name                    = "046  -  Is Sentinel")]
        IsSentinel                       = 46,
        [Display(Name                    = "047  -  Is Advocate")]
        IsAdvocate                       = 47,
        [Display(Name                    = "048  -  Currently Powering Up")]
        CurrentlyPoweringUp              = 48,
        [Display(Name                    = "049  -  Generator Entered World")]
        GeneratorEnteredWorld            = 49,
        [Display(Name                    = "050  -  Never Fail Casting")]
        NeverFailCasting                 = 50,
        [Display(Name                    = "051  -  Vendor Service")]
        VendorService                    = 51,
        [Display(Name                    = "052  -  Ai Immobile")]
        AiImmobile                       = 52,
        [Display(Name                    = "053  -  Damaged By Collisions")]
        DamagedByCollisions              = 53,
        [Display(Name                    = "054  -  Is Dynamic")]
        IsDynamic                        = 54,
        [Display(Name                    = "055  -  Is Hot")]
        IsHot                            = 55,
        [Display(Name                    = "056  -  Is Affecting")]
        IsAffecting                      = 56,
        [Display(Name                    = "057  -  Affects Ais")]
        AffectsAis                       = 57,
        [Display(Name                    = "058  -  Spell Queue Active")]
        SpellQueueActive                 = 58,
        [Display(Name                    = "059  -  Generator Disabled")]
        GeneratorDisabled                = 59,
        [Display(Name                    = "060  -  Is Accepting Tells")]
        IsAcceptingTells                 = 60,
        [Display(Name                    = "061  -  Logging Channel")]
        LoggingChannel                   = 61,
        [Display(Name                    = "062  -  Opens Any Lock")]
        OpensAnyLock                     = 62,
        [Display(Name                    = "063  -  Unlimited Use")]
        UnlimitedUse                     = 63,
        [Display(Name                    = "064  -  Generated Treasure Item")]
        GeneratedTreasureItem            = 64,
        [Display(Name                    = "065  -  Ignore Magic Resist")]
        IgnoreMagicResist                = 65,
        [Display(Name                    = "066  -  Ignore Magic Armor")]
        IgnoreMagicArmor                 = 66,
        [Display(Name                    = "067  -  Ai Allow Trade")]
        AiAllowTrade                     = 67,
        [Display(Name                    = "068  -  Spell Components Required")]
        SpellComponentsRequired          = 68,
        [Display(Name                    = "069  -  Is Sellable")]
        IsSellable                       = 69,
        [Display(Name                    = "070  -  Ignore Shields By Skill")]
        IgnoreShieldsBySkill             = 70,
        [Display(Name                    = "071  -  No Draw")]
        NoDraw                           = 71,
        [Display(Name                    = "072  -  Activation Untargeted")]
        ActivationUntargeted             = 72,
        [Display(Name                    = "073  -  House Has Gotten Priority Boot Pos")]
        HouseHasGottenPriorityBootPos    = 73,
        [Display(Name                    = "074  -  Generator Automatic Destruction")]
        GeneratorAutomaticDestruction    = 74,
        [Display(Name                    = "075  -  House Hooks Visible")]
        HouseHooksVisible                = 75,
        [Display(Name                    = "076  -  House Requires Monarch")]
        HouseRequiresMonarch             = 76,
        [Display(Name                    = "077  -  House Hooks Enabled")]
        HouseHooksEnabled                = 77,
        [Display(Name                    = "078  -  House Notified Hud Of Hook Count")]
        HouseNotifiedHudOfHookCount      = 78,
        [Display(Name                    = "079  -  Ai Accept Everything")]
        AiAcceptEverything               = 79,
        [Display(Name                    = "080  -  Ignore Portal Restrictions")]
        IgnorePortalRestrictions         = 80,
        [Display(Name                    = "081  -  Requires Backpack Slot")]
        RequiresBackpackSlot             = 81,
        [Display(Name                    = "082  -  Dont Turn Or Move When Giving")]
        DontTurnOrMoveWhenGiving         = 82,
        [Display(Name                    = "083  -  NPC Looks Like Object")]
        NpcLooksLikeObject               = 83,
        [Display(Name                    = "084  -  Ignore Clo Icons")]
        IgnoreCloIcons                   = 84,
        [Display(Name                    = "085  -  Appraisal Has Allowed Wielder")]
        AppraisalHasAllowedWielder       = 85,
        [Display(Name                    = "086  -  Chest Regen On Close")]
        ChestRegenOnClose                = 86,
        [Display(Name                    = "087  -  Log off In Mini-game")]
        LogoffInMinigame                 = 87,
        [Display(Name                    = "088  -  Portal Show Destination")]
        PortalShowDestination            = 88,
        [Display(Name                    = "089  -  Portal Ignores Pk Attack Timer")]
        PortalIgnoresPkAttackTimer       = 89,
        [Display(Name                    = "090  -  NPC Interacts Silently")]
        NpcInteractsSilently             = 90,
        [Display(Name                    = "091  -  Retained")]
        Retained                         = 91,
        [Display(Name                    = "092  -  Ignore Author")]
        IgnoreAuthor                     = 92,
        [Display(Name                    = "093  -  Limbo")]
        Limbo                            = 93,
        [Display(Name                    = "094  -  Appraisal Has Allowed Activator")]
        AppraisalHasAllowedActivator     = 94,
        [Display(Name                    = "095  -  Existed Before Allegiance Xp Changes")]
        ExistedBeforeAllegianceXpChanges = 95,
        [Display(Name                    = "096  -  Is Deaf")]
        IsDeaf                           = 96,
        [Display(Name                    = "097  -  Is Psr")]
        IsPsr                            = 97,
        [Display(Name                    = "098  -  Invincible")]
        Invincible                       = 98,
        [Display(Name                    = "099  -  Ivoryable")]
        Ivoryable                        = 99,
        [Display(Name                    = "100  -  Dyable")]
        Dyable                           = 100,
        [Display(Name                    = "101  -  Can Generate Rare")]
        CanGenerateRare                  = 101,
        [Display(Name                    = "102  -  Corpse Generated Rare")]
        CorpseGeneratedRare              = 102,
        [Display(Name                    = "103  -  Non Projectile Magic Immune")]
        NonProjectileMagicImmune         = 103,
        [Display(Name                    = "104  -  Actd Received Items")]
        ActdReceivedItems                = 104,
        [Display(Name                    = "105  -  Unknown 1 0 5")]
        Unknown105                       = 105,
        [Display(Name                    = "106  -  First Enter World Done")]
        FirstEnterWorldDone              = 106,
        [Display(Name                    = "107  -  Recalls Disabled")]
        RecallsDisabled                  = 107,
        [Display(Name                    = "108  -  Rare Uses Timer")]
        RareUsesTimer                    = 108,
        [Display(Name                    = "109  -  Actd Preorder Received Items")]
        ActdPreorderReceivedItems        = 109,
        [Display(Name                    = "110  -  Afk")]
        Afk                              = 110,
        [Display(Name                    = "111  -  Is Gagged")]
        IsGagged                         = 111,
        [Display(Name                    = "112  -  Proc Spell Self Targeted")]
        ProcSpellSelfTargeted            = 112,
        [Display(Name                    = "113  -  Is Allegiance Gagged")]
        IsAllegianceGagged               = 113,
        [Display(Name                    = "114  -  Equipment Set Trigger Piece")]
        EquipmentSetTriggerPiece         = 114,
        [Display(Name                    = "115  -  Uninscribe")]
        Uninscribe                       = 115,
        [Display(Name                    = "116  -  Wield On Use")]
        WieldOnUse                       = 116,
        [Display(Name                    = "117  -  Chest Cleared When Closed")]
        ChestClearedWhenClosed           = 117,
        [Display(Name                    = "118  -  Never Attack")]
        NeverAttack                      = 118,
        [Display(Name                    = "119  -  Suppress Generate Effect")]
        SuppressGenerateEffect           = 119,
        [Display(Name                    = "120  -  Treasure Corpse")]
        TreasureCorpse                   = 120,
        [Display(Name                    = "121  -  Equipment Set Add Level")]
        EquipmentSetAddLevel             = 121,
        [Display(Name                    = "122  -  Barber Active")]
        BarberActive                     = 122,
        [Display(Name                    = "123  -  Top Layer Priority")]
        TopLayerPriority                 = 123,
        [Display(Name                    = "124  -  No Held Item Shown")]
        NoHeldItemShown                  = 124,
        [Display(Name                    = "125  -  Login At Lifestone")]
        LoginAtLifestone                 = 125,
        [Display(Name                    = "126  -  Olthoi Pk")]
        OlthoiPk                         = 126,
        [Display(Name                    = "127  -  Account 1 5 Days")]
        Account15Days                    = 127,
        [Display(Name                    = "128  -  Had No Vitae")]
        HadNoVitae                       = 128,
        [Display(Name                    = "129  -  No Olthoi Talk")]
        NoOlthoiTalk                     = 129,
        [Display(Name                    = "130  -  Auto Wield Left")]
        AutowieldLeft                    = 130,
        [Display(Name                    = "9001  -  DO NOT USE")]
        IsDeleted                        = 9001
    }

    public static class PropertyBoolExtensions
    {
        public static string GetDescription(this BoolPropertyId prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this BoolPropertyId prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop.ToString();
        }
    }
}
