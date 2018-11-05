using System.Linq;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class EmoteAction
    {
        /// <summary>
        /// used by all emote actions
        /// </summary>
        [JsonProperty("type")]
        public uint EmoteActionType { get; set; }

        /// <summary>
        /// used by all emote actions
        /// </summary>
        [JsonIgnore]
        public EmoteType EmoteActionType_Binder
        {
            get { return (EmoteType)EmoteActionType; }
            set { EmoteActionType = (uint)value; }
        }

        /// <summary>
        /// used by all emote actions
        /// </summary>
        [JsonProperty("delay")]
        public float? Delay { get; set; }

        /// <summary>
        /// used by all emote actions
        /// </summary>
        [JsonProperty("extent")]
        public float? Extent { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.DecrementQuest)]
        [EmoteType(EmoteType.IncrementQuest)]
        [EmoteType(EmoteType.SetQuestCompletions)]
        [EmoteType(EmoteType.DecrementMyQuest)]
        [EmoteType(EmoteType.IncrementMyQuest)]
        [EmoteType(EmoteType.SetMyQuestCompletions)]
        [EmoteType(EmoteType.InqPackSpace)]
        [EmoteType(EmoteType.InqQuestBitsOn)]
        [EmoteType(EmoteType.InqQuestBitsOff)]
        [EmoteType(EmoteType.InqMyQuestBitsOn)]
        [EmoteType(EmoteType.InqMyQuestBitsOff)]
        [EmoteType(EmoteType.SetQuestBitsOn)]
        [EmoteType(EmoteType.SetQuestBitsOff)]
        [EmoteType(EmoteType.SetMyQuestBitsOn)]
        [EmoteType(EmoteType.SetMyQuestBitsOff)]
        [EmoteType(EmoteType.SetIntStat)]
        [EmoteType(EmoteType.IncrementIntStat)]
        [EmoteType(EmoteType.DecrementIntStat)]
        [EmoteType(EmoteType.SetBoolStat)]
        [EmoteType(EmoteType.AddCharacterTitle)]
        [EmoteType(EmoteType.AwardTrainingCredits)]
        [EmoteType(EmoteType.InflictVitaePenalty)]
        [EmoteType(EmoteType.RemoveVitaePenalty)]
        [EmoteType(EmoteType.AddContract)]
        [EmoteType(EmoteType.RemoveContract)]
        [EmoteType(EmoteType.AwardSkillXP)]
        [EmoteType(EmoteType.AwardSkillPoints)]
        [EmoteType(EmoteType.SetAltRacialSkills)]
        public uint? Amount { get; set; }

        [JsonProperty("motion", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.Motion)]
        [EmoteType(EmoteType.ForceMotion)]
        public uint? Motion { get; set; }

        [JsonIgnore]
        public MotionCommand? Motion_Binder
        {
            get { return (MotionCommand?)Motion; }
            set { Motion = (uint?)value; }
        }

        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.Act)]
        [EmoteType(EmoteType.Say)]
        [EmoteType(EmoteType.Tell)]
        [EmoteType(EmoteType.TextDirect)]
        [EmoteType(EmoteType.WorldBroadcast)]
        [EmoteType(EmoteType.LocalBroadcast)]
        [EmoteType(EmoteType.DirectBroadcast)]
        [EmoteType(EmoteType.UpdateQuest)]
        [EmoteType(EmoteType.InqQuest)]
        [EmoteType(EmoteType.StampQuest)]
        [EmoteType(EmoteType.StartEvent)]
        [EmoteType(EmoteType.StopEvent)]
        [EmoteType(EmoteType.BLog)]
        [EmoteType(EmoteType.AdminSpam)]
        [EmoteType(EmoteType.EraseQuest)]
        [EmoteType(EmoteType.DecrementQuest)]
        [EmoteType(EmoteType.IncrementQuest)]
        [EmoteType(EmoteType.SetQuestCompletions)]
        [EmoteType(EmoteType.InqEvent)]
        [EmoteType(EmoteType.InqFellowQuest)]
        [EmoteType(EmoteType.UpdateFellowQuest)]
        [EmoteType(EmoteType.StampFellowQuest)]
        [EmoteType(EmoteType.TellFellow)]
        [EmoteType(EmoteType.FellowBroadcast)]
        [EmoteType(EmoteType.Goto)]
        [EmoteType(EmoteType.PopUp)]
        [EmoteType(EmoteType.InqNumCharacterTitles)]
        [EmoteType(EmoteType.UpdateMyQuest)]
        [EmoteType(EmoteType.InqMyQuest)]
        [EmoteType(EmoteType.StampMyQuest)]
        [EmoteType(EmoteType.EraseMyQuest)]
        [EmoteType(EmoteType.DecrementMyQuest)]
        [EmoteType(EmoteType.IncrementMyQuest)]
        [EmoteType(EmoteType.SetMyQuestCompletions)]
        [EmoteType(EmoteType.LocalSignal)]
        [EmoteType(EmoteType.InqPackSpace)]
        [EmoteType(EmoteType.InqQuestBitsOn)]
        [EmoteType(EmoteType.InqQuestBitsOff)]
        [EmoteType(EmoteType.InqMyQuestBitsOn)]
        [EmoteType(EmoteType.InqMyQuestBitsOff)]
        [EmoteType(EmoteType.SetQuestBitsOn)]
        [EmoteType(EmoteType.SetQuestBitsOff)]
        [EmoteType(EmoteType.SetMyQuestBitsOn)]
        [EmoteType(EmoteType.SetMyQuestBitsOff)]
        [EmoteType(EmoteType.InqContractsFull)]
        [EmoteType(EmoteType.InqQuestSolves)]
        [EmoteType(EmoteType.InqFellowNum)]
        [EmoteType(EmoteType.InqNumCharacterTitles)]
        [EmoteType(EmoteType.InqMyQuestSolves)]
        [EmoteType(EmoteType.InqOwnsItems)]
        [EmoteType(EmoteType.InqBoolStat)]
        [EmoteType(EmoteType.InqSkillTrained)]
        [EmoteType(EmoteType.InqSkillSpecialized)]
        [EmoteType(EmoteType.InqStringStat)]
        [EmoteType(EmoteType.InqYesNo)]
        [EmoteType(EmoteType.InqIntStat)]
        [EmoteType(EmoteType.InqAttributeStat)]
        [EmoteType(EmoteType.InqRawAttributeStat)]
        [EmoteType(EmoteType.InqSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqRawSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqSkillStat)]
        [EmoteType(EmoteType.InqRawSkillStat)]
        [EmoteType(EmoteType.InqInt64Stat)]
        [EmoteType(EmoteType.InqFloatStat)]
        public string Message { get; set; }

        [JsonProperty("amount64", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.AwardXP)]
        [EmoteType(EmoteType.AwardNoShareXP)]
        [EmoteType(EmoteType.SpendLuminance)]
        [EmoteType(EmoteType.AwardLuminance)]
        public ulong? Amount64 { get; set; }

        [JsonProperty("heroxp64", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.AwardXP)]
        [EmoteType(EmoteType.AwardNoShareXP)]
        public ulong? HeroXp64 { get; set; }

        [JsonProperty("cprof", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.Give)]
        [EmoteType(EmoteType.TakeItems)]
        [EmoteType(EmoteType.InqOwnsItems)]
        public CreateItem Item { get; set; }

        [JsonProperty("min64", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqInt64Stat)]
        [EmoteType(EmoteType.AwardLevelProportionalXP)]
        public long? Minimum64 { get; set; }

        [JsonProperty("max64", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqInt64Stat)]
        [EmoteType(EmoteType.AwardLevelProportionalXP)]
        public long? Maximum64 { get; set; }

        [JsonProperty("percent", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.SetFloatStat)]
        [EmoteType(EmoteType.AwardLevelProportionalXP)]
        [EmoteType(EmoteType.AwardLevelProportionalSkillXP)]
        public float? Percent { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.AwardLevelProportionalXP)]
        [EmoteType(EmoteType.AwardLevelProportionalSkillXP)]
        public byte? Display_Binder { get; set; }

        [JsonIgnore]
        public bool? Display
        {
            get { return (Display_Binder == null) ? (bool?)null : (Display_Binder.Value == 0 ? false : true); }
            set { Display_Binder = (value == null) ? (byte?)null : (value.Value ? (byte)1 : (byte)0); }
        }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqQuestSolves)]
        [EmoteType(EmoteType.InqFellowNum)]
        [EmoteType(EmoteType.InqNumCharacterTitles)]
        [EmoteType(EmoteType.InqMyQuestSolves)]
        [EmoteType(EmoteType.InqIntStat)]
        [EmoteType(EmoteType.InqAttributeStat)]
        [EmoteType(EmoteType.InqRawAttributeStat)]
        [EmoteType(EmoteType.InqSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqRawSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqSkillStat)]
        [EmoteType(EmoteType.InqRawSkillStat)]
        [EmoteType(EmoteType.AwardLevelProportionalSkillXP)]
        public uint? Max { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqQuestSolves)]
        [EmoteType(EmoteType.InqFellowNum)]
        [EmoteType(EmoteType.InqNumCharacterTitles)]
        [EmoteType(EmoteType.InqMyQuestSolves)]
        [EmoteType(EmoteType.InqIntStat)]
        [EmoteType(EmoteType.InqAttributeStat)]
        [EmoteType(EmoteType.InqRawAttributeStat)]
        [EmoteType(EmoteType.InqSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqRawSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqSkillStat)]
        [EmoteType(EmoteType.InqRawSkillStat)]
        [EmoteType(EmoteType.AwardLevelProportionalSkillXP)]
        public uint? Min { get; set; }

        [JsonProperty("fmax", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqFloatStat)]
        public float? FMax { get; set; }

        [JsonProperty("fmin", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqFloatStat)]
        public float? FMin { get; set; }

        [JsonProperty("stat", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.SetIntStat)]
        [EmoteType(EmoteType.IncrementIntStat)]
        [EmoteType(EmoteType.DecrementIntStat)]
        [EmoteType(EmoteType.SetBoolStat)]
        [EmoteType(EmoteType.SetInt64Stat)]
        [EmoteType(EmoteType.SetFloatStat)]
        [EmoteType(EmoteType.AwardSkillXP)]
        [EmoteType(EmoteType.AwardSkillPoints)]
        [EmoteType(EmoteType.UntrainSkill)]
        [EmoteType(EmoteType.InqBoolStat)]
        [EmoteType(EmoteType.InqSkillTrained)]
        [EmoteType(EmoteType.InqSkillSpecialized)]
        [EmoteType(EmoteType.InqStringStat)]
        [EmoteType(EmoteType.InqYesNo)]
        [EmoteType(EmoteType.InqIntStat)]
        [EmoteType(EmoteType.InqAttributeStat)]
        [EmoteType(EmoteType.InqRawAttributeStat)]
        [EmoteType(EmoteType.InqSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqRawSecondaryAttributeStat)]
        [EmoteType(EmoteType.InqSkillStat)]
        [EmoteType(EmoteType.InqRawSkillStat)]
        [EmoteType(EmoteType.InqInt64Stat)]
        [EmoteType(EmoteType.InqFloatStat)]
        [EmoteType(EmoteType.AwardLevelProportionalSkillXP)]
        public uint? Stat { get; set; }

        [JsonProperty("pscript", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.PhysScript)]
        public uint? PScript { get; set; }

        [JsonIgnore]
        public PhysicsScriptType? PScript_Binder
        {
            get { return PScript != null ? (PhysicsScriptType)PScript : (PhysicsScriptType?)null; }
            set { PScript = (uint?)value; }
        }

        [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.Sound)]
        public uint? Sound { get; set; }

        [JsonProperty("mPosition", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.SetSanctuaryPosition)]
        [EmoteType(EmoteType.TeleportTarget)]
        [EmoteType(EmoteType.TeleportSelf)]
        public Position MPosition { get; set; }

        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.MoveHome)]
        [EmoteType(EmoteType.Move)]
        [EmoteType(EmoteType.Turn)]
        [EmoteType(EmoteType.MoveToPos)]
        public Frame Frame { get; set; }

        [JsonProperty("spellid", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.CastSpell)]
        [EmoteType(EmoteType.CastSpellInstant)]
        [EmoteType(EmoteType.TeachSpell)]
        [EmoteType(EmoteType.PetCastSpellOnOwner)]
        public uint? SpellId { get; set; }

        [JsonProperty("teststring", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.InqStringStat)]
        [EmoteType(EmoteType.InqYesNo)]
        public string TestString { get; set; }

        [JsonProperty("wealth_rating", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.CreateTreasure)]
        public uint? WealthRating { get; set; }

        [JsonIgnore]
        public WealthRating? WealthRating_Binder
        {
            get { return (WealthRating?)WealthRating; }
            set { WealthRating = (uint?)value; }
        }

        [JsonProperty("treasure_class", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.CreateTreasure)]
        public uint? TreasureClass { get; set; }

        [JsonIgnore]
        public TreasureClass? TreasureClass_Binder
        {
            get { return (TreasureClass?)TreasureClass; }
            set { TreasureClass = (uint?)value; }
        }

        [JsonProperty("treasure_type", NullValueHandling = NullValueHandling.Ignore)]
        [EmoteType(EmoteType.CreateTreasure)]
        public int? TreasureType { get; set; }

        [JsonIgnore]
        public int? SortOrder { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        /// <summary>
        /// checks the EmoteType attributes of the requested property to determine whether or not
        /// it should be shown
        /// </summary>
        public static bool IsPropertyVisible(string propertyName, EmoteAction emote)
        {
            var property = typeof(EmoteAction).GetProperty(propertyName);
            var attribs = property.GetCustomAttributes(typeof(EmoteTypeAttribute), false).Cast<EmoteTypeAttribute>().ToList();

            if (attribs == null || attribs.Count < 1)
                return true;

            // because the lists are long and could get unwieldy, we'll allow for multiple on the same property
            return attribs.Any(a => a.TypeList.Contains(emote.EmoteActionType_Binder));
        }
    }
}
