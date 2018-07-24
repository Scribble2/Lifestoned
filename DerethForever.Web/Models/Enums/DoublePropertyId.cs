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
    public enum DoublePropertyId
    {
        [Display(Name                  = "000 - Undef")]
        Undef                          = 0,
        [Display(Name                  = "001 - Heartbeat Interval")]
        HeartbeatInterval              = 1,
        [Display(Name                  = "002 - Heartbeat Timestamp")]
        HeartbeatTimestamp             = 2,
        [Display(Name                  = "003 - Health Rate")]
        HealthRate                     = 3,
        [Display(Name                  = "004 - Stamina Rate")]
        StaminaRate                    = 4,
        [Display(Name                  = "005 - Mana Rate")]
        ManaRate                       = 5,
        [Display(Name                  = "006 - Health Upon Resurrection")]
        HealthUponResurrection         = 6,
        [Display(Name                  = "007 - Stamina Upon Resurrection")]
        StaminaUponResurrection        = 7,
        [Display(Name                  = "008 - Mana Upon Resurrection")]
        ManaUponResurrection           = 8,
        [Display(Name                  = "009 - Start Time")]
        StartTime                      = 9,
        [Display(Name                  = "010 - Stop Time")]
        StopTime                       = 10,
        [Display(Name                  = "011 - Reset Interval")]
        ResetInterval                  = 11,
        [Display(Name                  = "012 - Shade")]
        Shade                          = 12,
        [Display(Name                  = "013 - Armor Mod Vs Slash")]
        ArmorModVsSlash                = 13,
        [Display(Name                  = "014 - Armor Mod Vs Pierce")]
        ArmorModVsPierce               = 14,
        [Display(Name                  = "015 - Armor Mod Vs Bludgeon")]
        ArmorModVsBludgeon             = 15,
        [Display(Name                  = "016 - Armor Mod Vs Cold")]
        ArmorModVsCold                 = 16,
        [Display(Name                  = "017 - Armor Mod Vs Fire")]
        ArmorModVsFire                 = 17,
        [Display(Name                  = "018 - Armor Mod Vs Acid")]
        ArmorModVsAcid                 = 18,
        [Display(Name                  = "019 - Armor Mod Vs Electric")]
        ArmorModVsElectric             = 19,
        [Display(Name                  = "020 - Combat Speed")]
        CombatSpeed                    = 20,
        [Display(Name                  = "021 - Weapon Length")]
        WeaponLength                   = 21,
        [Display(Name                  = "022 - Damage Variance")]
        DamageVariance                 = 22,
        [Display(Name                  = "023 - Current Power Mod")]
        CurrentPowerMod                = 23,
        [Display(Name                  = "024 - Accuracy Mod")]
        AccuracyMod                    = 24,
        [Display(Name                  = "025 - Strength Mod")]
        StrengthMod                    = 25,
        [Display(Name                  = "026 - Maximum Velocity")]
        MaximumVelocity                = 26,
        [Display(Name                  = "027 - Rotation Speed")]
        RotationSpeed                  = 27,
        [Display(Name                  = "028 - Motion Timestamp")]
        MotionTimestamp                = 28,
        [Display(Name                  = "029 - Weapon Defense")]
        WeaponDefense                  = 29,
        [Display(Name                  = "030 - Wimpy Level")]
        WimpyLevel                     = 30,
        [Display(Name                  = "031 - Visual Awareness Range")]
        VisualAwarenessRange           = 31,
        [Display(Name                  = "032 - Aural Awareness Range")]
        AuralAwarenessRange            = 32,
        [Display(Name                  = "033 - Perception Level")]
        PerceptionLevel                = 33,
        [Display(Name                  = "034 - Powerup Time")]
        PowerupTime                    = 34,
        [Display(Name                  = "035 - Max Charge Distance")]
        MaxChargeDistance              = 35,
        [Display(Name                  = "036 - Charge Speed")]
        ChargeSpeed                    = 36,
        [Display(Name                  = "037 - Buy Price")]
        BuyPrice                       = 37,
        [Display(Name                  = "038 - Sell Price")]
        SellPrice                      = 38,
        [Display(Name                  = "039 - Default Scale")]
        DefaultScale                   = 39,
        [Display(Name                  = "040 - Lockpick Mod")]
        LockpickMod                    = 40,
        [Display(Name                  = "041 - Regeneration Interval")]
        RegenerationInterval           = 41,
        [Display(Name                  = "042 - Regeneration Timestamp")]
        RegenerationTimestamp          = 42,
        [Display(Name                  = "043 - Generator Radius")]
        GeneratorRadius                = 43,
        [Display(Name                  = "044 - Time To Rot")]
        TimeToRot                      = 44,
        [Display(Name                  = "045 - Death Timestamp")]
        DeathTimestamp                 = 45,
        [Display(Name                  = "046 - Pk Timestamp")]
        PkTimestamp                    = 46,
        [Display(Name                  = "047 - Victim Timestamp")]
        VictimTimestamp                = 47,
        [Display(Name                  = "048 - Login Timestamp")]
        LoginTimestamp                 = 48,
        [Display(Name                  = "049 - Creation Timestamp")]
        CreationTimestamp              = 49,
        [Display(Name                  = "050 - Minimum Time Since Pk")]
        MinimumTimeSincePk             = 50,
        [Display(Name                  = "051 - Deprecated Housekeeping Priority")]
        DeprecatedHousekeepingPriority = 51,
        [Display(Name                  = "052 - Abuse Logging Timestamp")]
        AbuseLoggingTimestamp          = 52,
        [Display(Name                  = "053 - Last Portal Teleport Timestamp")]
        LastPortalTeleportTimestamp    = 53,
        [Display(Name                  = "054 - Use Radius")]
        UseRadius                      = 54,
        [Display(Name                  = "055 - Home Radius")]
        HomeRadius                     = 55,
        [Display(Name                  = "056 - Released Timestamp")]
        ReleasedTimestamp              = 56,
        [Display(Name                  = "057 - Min Home Radius")]
        MinHomeRadius                  = 57,
        [Display(Name                  = "058 - Facing")]
        Facing                         = 58,
        [Display(Name                  = "059 - Reset Timestamp")]
        ResetTimestamp                 = 59,
        [Display(Name                  = "060 - Logoff Timestamp")]
        LogoffTimestamp                = 60,
        [Display(Name                  = "061 - Econ Recovery Interval")]
        EconRecoveryInterval           = 61,
        [Display(Name                  = "062 - Weapon Offense")]
        WeaponOffense                  = 62,
        [Display(Name                  = "063 - Damage Mod")]
        DamageMod                      = 63,
        [Display(Name                  = "064 - Resist Slash")]
        ResistSlash                    = 64,
        [Display(Name                  = "065 - Resist Pierce")]
        ResistPierce                   = 65,
        [Display(Name                  = "066 - Resist Bludgeon")]
        ResistBludgeon                 = 66,
        [Display(Name                  = "067 - Resist Fire")]
        ResistFire                     = 67,
        [Display(Name                  = "068 - Resist Cold")]
        ResistCold                     = 68,
        [Display(Name                  = "069 - Resist Acid")]
        ResistAcid                     = 69,
        [Display(Name                  = "070 - Resist Electric")]
        ResistElectric                 = 70,
        [Display(Name                  = "071 - Resist Health Boost")]
        ResistHealthBoost              = 71,
        [Display(Name                  = "072 - Resist Stamina Drain")]
        ResistStaminaDrain             = 72,
        [Display(Name                  = "073 - Resist Stamina Boost")]
        ResistStaminaBoost             = 73,
        [Display(Name                  = "074 - Resist Mana Drain")]
        ResistManaDrain                = 74,
        [Display(Name                  = "075 - Resist Mana Boost")]
        ResistManaBoost                = 75,
        [Display(Name                  = "076 - Translucency")]
        Translucency                   = 76,
        [Display(Name                  = "077 - Physics Script Intensity")]
        PhysicsScriptIntensity         = 77,
        [Display(Name                  = "078 - Friction")]
        Friction                       = 78,
        [Display(Name                  = "079 - Elasticity")]
        Elasticity                     = 79,
        [Display(Name                  = "080 - Ai Use Magic Delay")]
        AiUseMagicDelay                = 80,
        [Display(Name                  = "081 - Item Min Spellcraft Mod")]
        ItemMinSpellcraftMod           = 81,
        [Display(Name                  = "082 - Item Max Spellcraft Mod")]
        ItemMaxSpellcraftMod           = 82,
        [Display(Name                  = "083 - Item Rank Probability")]
        ItemRankProbability            = 83,
        [Display(Name                  = "084 - Shade 2")]
        Shade2                         = 84,
        [Display(Name                  = "085 - Shade 3")]
        Shade3                         = 85,
        [Display(Name                  = "086 - Shade 4")]
        Shade4                         = 86,
        [Display(Name                  = "087 - Item Efficiency")]
        ItemEfficiency                 = 87,
        [Display(Name                  = "088 - Item Mana Update Timestamp")]
        ItemManaUpdateTimestamp        = 88,
        [Display(Name                  = "089 - Spell Gesture Speed Mod")]
        SpellGestureSpeedMod           = 89,
        [Display(Name                  = "090 - Spell Stance Speed Mod")]
        SpellStanceSpeedMod            = 90,
        [Display(Name                  = "091 - Allegiance Appraisal Timestamp")]
        AllegianceAppraisalTimestamp   = 91,
        [Display(Name                  = "092 - Power Level")]
        PowerLevel                     = 92,
        [Display(Name                  = "093 - Accuracy Level")]
        AccuracyLevel                  = 93,
        [Display(Name                  = "094 - Attack Angle")]
        AttackAngle                    = 94,
        [Display(Name                  = "095 - Attack Timestamp")]
        AttackTimestamp                = 95,
        [Display(Name                  = "096 - Checkpoint Timestamp")]
        CheckpointTimestamp            = 96,
        [Display(Name                  = "097 - Sold Timestamp")]
        SoldTimestamp                  = 97,
        [Display(Name                  = "098 - Use Timestamp")]
        UseTimestamp                   = 98,
        [Display(Name                  = "099 - Use Lock Timestamp")]
        UseLockTimestamp               = 99,
        [Display(Name                  = "100 - Healkit Mod")]
        HealkitMod                     = 100,
        [Display(Name                  = "101 - Frozen Timestamp")]
        FrozenTimestamp                = 101,
        [Display(Name                  = "102 - Health Rate Mod")]
        HealthRateMod                  = 102,
        [Display(Name                  = "103 - Allegiance Swear Timestamp")]
        AllegianceSwearTimestamp       = 103,
        [Display(Name                  = "104 - Obvious Radar Range")]
        ObviousRadarRange              = 104,
        [Display(Name                  = "105 - Hotspot Cycle Time")]
        HotspotCycleTime               = 105,
        [Display(Name                  = "106 - Hotspot Cycle Time Variance")]
        HotspotCycleTimeVariance       = 106,
        [Display(Name                  = "107 - Spam Timestamp")]
        SpamTimestamp                  = 107,
        [Display(Name                  = "108 - Spam Rate")]
        SpamRate                       = 108,
        [Display(Name                  = "109 - Bond Wielded Treasure")]
        BondWieldedTreasure            = 109,
        [Display(Name                  = "110 - Bulk Mod")]
        BulkMod                        = 110,
        [Display(Name                  = "111 - Size Mod")]
        SizeMod                        = 111,
        [Display(Name                  = "112 - Gag Timestamp")]
        GagTimestamp                   = 112,
        [Display(Name                  = "113 - Generator Update Timestamp")]
        GeneratorUpdateTimestamp       = 113,
        [Display(Name                  = "114 - Death Spam Timestamp")]
        DeathSpamTimestamp             = 114,
        [Display(Name                  = "115 - Death Spam Rate")]
        DeathSpamRate                  = 115,
        [Display(Name                  = "116 - Wild Attack Probability")]
        WildAttackProbability          = 116,
        [Display(Name                  = "117 - Focused Probability")]
        FocusedProbability             = 117,
        [Display(Name                  = "118 - Crash And Turn Probability")]
        CrashAndTurnProbability        = 118,
        [Display(Name                  = "119 - Crash And Turn Radius")]
        CrashAndTurnRadius             = 119,
        [Display(Name                  = "120 - Crash And Turn Bias")]
        CrashAndTurnBias               = 120,
        [Display(Name                  = "121 - Generator Initial Delay")]
        GeneratorInitialDelay          = 121,
        [Display(Name                  = "122 - Ai Acquire Health")]
        AiAcquireHealth                = 122,
        [Display(Name                  = "123 - Ai Acquire Stamina")]
        AiAcquireStamina               = 123,
        [Display(Name                  = "124 - Ai Acquire Mana")]
        AiAcquireMana                  = 124,

        /// <summary>
        /// this had a default of "1" - leaving comment to investigate potential options for defaulting these things (125)
        /// </summary>
        [Display(Name                  = "125 - Resist Health Drain")]
        ResistHealthDrain              = 125,
        [Display(Name                  = "126 - Lifestone Protection Timestamp")]
        LifestoneProtectionTimestamp   = 126,
        [Display(Name                  = "127 - Ai Counteract Enchantment")]
        AiCounteractEnchantment        = 127,
        [Display(Name                  = "128 - Ai Dispel Enchantment")]
        AiDispelEnchantment            = 128,
        [Display(Name                  = "129 - Trade Timestamp")]
        TradeTimestamp                 = 129,
        [Display(Name                  = "130 - Ai Targeted Detection Radius")]
        AiTargetedDetectionRadius      = 130,
        [Display(Name                  = "131 - Emote Priority")]
        EmotePriority                  = 131,
        [Display(Name                  = "132 - Last Teleport Start Timestamp")]
        LastTeleportStartTimestamp     = 132,
        [Display(Name                  = "133 - Event Spam Timestamp")]
        EventSpamTimestamp             = 133,
        [Display(Name                  = "134 - Event Spam Rate")]
        EventSpamRate                  = 134,
        [Display(Name                  = "135 - Inventory Offset")]
        InventoryOffset                = 135,
        [Display(Name                  = "136 - Critical Multiplier")]
        CriticalMultiplier             = 136,
        [Display(Name                  = "137 - Mana Stone Destroy Chance")]
        ManaStoneDestroyChance         = 137,
        [Display(Name                  = "138 - Slayer Damage Bonus")]
        SlayerDamageBonus              = 138,
        [Display(Name                  = "139 - Allegiance Info Spam Timestamp")]
        AllegianceInfoSpamTimestamp    = 139,
        [Display(Name                  = "140 - Allegiance Info Spam Rate")]
        AllegianceInfoSpamRate         = 140,
        [Display(Name                  = "141 - Next Spellcast Timestamp")]
        NextSpellcastTimestamp         = 141,
        [Display(Name                  = "142 - Appraisal Requested Timestamp")]
        AppraisalRequestedTimestamp    = 142,
        [Display(Name                  = "143 - Appraisal Heartbeat Due Timestamp")]
        AppraisalHeartbeatDueTimestamp = 143,
        [Display(Name                  = "144 - Mana Conversion Mod")]
        ManaConversionMod              = 144,
        [Display(Name                  = "145 - Last Pk Attack Timestamp")]
        LastPkAttackTimestamp          = 145,
        [Display(Name                  = "146 - Fellowship Update Timestamp")]
        FellowshipUpdateTimestamp      = 146,
        [Display(Name                  = "147 - Critical Frequency")]
        CriticalFrequency              = 147,
        [Display(Name                  = "148 - Limbo Start Timestamp")]
        LimboStartTimestamp            = 148,
        [Display(Name                  = "149 - Weapon Missile Defense")]
        WeaponMissileDefense           = 149,
        [Display(Name                  = "150 - Weapon Magic Defense")]
        WeaponMagicDefense             = 150,
        [Display(Name                  = "151 - Ignore Shield")]
        IgnoreShield                   = 151,
        [Display(Name                  = "152 - Elemental Damage Mod")]
        ElementalDamageMod             = 152,
        [Display(Name                  = "153 - Start Missile Attack Timestamp")]
        StartMissileAttackTimestamp    = 153,
        [Display(Name                  = "154 - Last Rare Used Timestamp")]
        LastRareUsedTimestamp          = 154,
        [Display(Name                  = "155 - Ignore Armor")]
        IgnoreArmor                    = 155,
        [Display(Name                  = "156 - Proc Spell Rate")]
        ProcSpellRate                  = 156,
        [Display(Name                  = "157 - Resistance Modifier")]
        ResistanceModifier             = 157,
        [Display(Name                  = "158 - Allegiance Gag Timestamp")]
        AllegianceGagTimestamp         = 158,
        [Display(Name                  = "159 - Absorb Magic Damage")]
        AbsorbMagicDamage              = 159,
        [Display(Name                  = "160 - Cached Max Absorb Magic Damage")]
        CachedMaxAbsorbMagicDamage     = 160,
        [Display(Name                  = "161 - Gag Duration")]
        GagDuration                    = 161,
        [Display(Name                  = "162 - Allegiance Gag Duration")]
        AllegianceGagDuration          = 162,
        [Display(Name                  = "163 - Global Xp Mod")]
        GlobalXpMod                    = 163,
        [Display(Name                  = "164 - Healing Modifier")]
        HealingModifier                = 164,
        [Display(Name                  = "165 - Armor Mod Vs Nether")]
        ArmorModVsNether               = 165,
        [Display(Name                  = "166 - Resist Nether")]
        ResistNether                   = 166,
        [Display(Name                  = "167 - Cool Down Duration")]
        CooldownDuration               = 167,
        [Display(Name                  = "168 - Weapon Aura Offense")]
        WeaponAuraOffense              = 168,
        [Display(Name                  = "169 - Weapon Aura Defense")]
        WeaponAuraDefense              = 169,
        [Display(Name                  = "170 - Weapon Aura Elemental")]
        WeaponAuraElemental            = 170,
        [Display(Name                  = "171 - Weapon Aura Mana Conversion")]
        WeaponAuraManaConv             = 171
    }

    public static class PropertyDoubleExtensions
    {
        public static string GetDescription(this DoublePropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this DoublePropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
