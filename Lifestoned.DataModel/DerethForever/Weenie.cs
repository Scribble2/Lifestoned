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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.DerethForever
{
    /// <summary>
    /// this is a dual purpose class for interacting with the Api as well as serving 
    /// as a model for this web ui
    /// </summary>
    public class Weenie : BaseModel
    {
        public Weenie()
        {
        }

        public string Name
        {
            get
            {
                return StringProperties?.FirstOrDefault(p => p.StringPropertyId == 1)?.Value ?? WeenieClassId.ToString();
            }
        }

        /// <summary>
        /// probably only applies to players
        /// </summary>
        [JsonProperty("contracts")]
        public List<Contract> Contracts { get; set; }

        [JsonProperty("dataObjectId")]
        public uint DataObjectId { get; set; }

        [JsonProperty("weenieClassId")]
        public uint WeenieClassId { get; set; }

        [JsonProperty("currentMotionState")]
        public object CurrentMotionState { get; set; }

        [JsonProperty("palettes")]
        public List<Palette> Palettes { get; set; }

        [JsonProperty("textures")]
        public List<Texture> Textures { get; set; }

        [JsonProperty("animations")]
        public List<Animation> Animations { get; set; }

        [JsonProperty("stringProperties")]
        public List<StringProperty> StringProperties { get; set; } = new List<StringProperty>();

        [JsonProperty("uintProperties")]
        public List<IntProperty> IntProperties { get; set; } = new List<IntProperty>();

        [JsonProperty("uint64Properties")]
        public List<Int64Property> Int64Properties { get; set; } = new List<Int64Property>();

        [JsonProperty("doubleProperties")]
        public List<DoubleProperty> DoubleProperties { get; set; } = new List<DoubleProperty>();

        [JsonProperty("boolProperties")]
        public List<BoolProperty> BoolProperties { get; set; } = new List<BoolProperty>();

        [JsonProperty("didProperties")]
        public List<DataIdProperty> DidProperties { get; set; } = new List<DataIdProperty>();

        [JsonProperty("iidProperties")]
        public List<InstanceIdProperty> IidProperties { get; set; } = new List<InstanceIdProperty>();

        [JsonProperty("spells")]
        public List<Spell> Spells { get; set; } = new List<Spell>();

        [JsonProperty("spellbars")]
        public List<object> Spellbars { get; set; }

        [JsonProperty("inventoryWeenieIds")]
        public List<uint> InventoryWeenieIds { get; set; }

        [JsonProperty("wieldedWeenieIds")]
        public List<uint> WieldedWeenieIds { get; set; }

        [JsonProperty("bookProperties")]
        public List<BookPage> BookProperties { get; set; } = new List<BookPage>();

        [JsonProperty("generators")]
        public List<object> Generators { get; set; }

        [JsonProperty("abilities")]
        public AbilitySet Abilities { get; set; } = new AbilitySet();

        /// <summary>
        /// property here controls whether or not abilities and skills are shown on the weenie editor
        /// </summary>
        [JsonIgnore]
        public bool HasAbilities
        {
            get { return (ItemType & (uint)Shared.ItemType.Creature) > 0; }
        }

        /// <summary>
        /// property here controls whether or not Generator Table is shown on the weenie editor
        /// </summary>
        [JsonIgnore]
        public bool HasGeneratorTable
        {
            get { return GeneratorTable.Count > 0; }
        }

        public bool HasBodyPartList
        {
            get { return BodyParts.Count > 0; }
        }

        [JsonProperty("vitals")]
        public VitalSet Vitals { get; set; } = new VitalSet();

        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; } = new List<Skill>();

        [JsonProperty("positions")]
        public List<Position> Positions { get; set; } = new List<Position>();

        [JsonProperty("emoteTable")]
        public List<EmoteSet> EmoteTable { get; set; } = new List<EmoteSet>();

        [JsonIgnore]
        public EmoteCategory NewEmoteCategory { get; set; }

        [JsonProperty("createList")]
        public List<CreationProfile> CreateList { get; set; } = new List<CreationProfile>();

        [JsonProperty("generatorTable")]
        public List<GeneratorTable> GeneratorTable { get; set; } = new List<GeneratorTable>();

        [JsonProperty("bodyParts")]
        public List<BodyPart> BodyParts { get; set; } = new List<BodyPart>();

        [JsonProperty("lastModified")]
        [Display(Name = "Last Modified Date")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        [Display(Name = "Last Modified By")]
        public string ModifiedBy { get; set; }

        [JsonProperty("changelog")]
        public List<ChangelogEntry> Changelog { get; set; } = new List<ChangelogEntry>();

        [JsonProperty("userChangeSummary")]
        public string UserChangeSummary { get; set; }

        [JsonProperty("replaceLiveObjects")]
        public bool ReplaceLiveObjects { get; set; }

        [JsonProperty("isDone")]
        [Display(Name = "Is Done")]
        public bool IsDone { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonIgnore]
        public int? ItemType
        {
            get { return IntProperties.FirstOrDefault(d => d.IntPropertyId == (int)IntPropertyId.ItemType)?.Value ?? 0; }
        }

        //[JsonIgnore]
        //public int? WeenieType
        //{
        //    get { return IntProperties.FirstOrDefault(d => d.IntPropertyId == (int)IntPropertyId.WeenieType)?.Value ?? 0; }
        //}

        [JsonIgnore]
        public int? UIEffects
        {
            get { return IntProperties.FirstOrDefault(d => d.IntPropertyId == (int)IntPropertyId.UiEffects)?.Value ?? 0; }
        }

        [JsonIgnore]
        public uint? IconId
        {
            get { return DidProperties.FirstOrDefault(d => d.DataIdPropertyId == (int)DidPropertyId.Icon)?.Value; }
        }

        [JsonIgnore]
        public uint? UnderlayId
        {
            get { return DidProperties.FirstOrDefault(d => d.DataIdPropertyId == (int)DidPropertyId.IconUnderlay)?.Value; }
        }

        [JsonIgnore]
        public uint? OverlayId
        {
            get { return DidProperties.FirstOrDefault(d => d.DataIdPropertyId == (int)DidPropertyId.IconOverlay)?.Value; }
        }

        [JsonIgnore]
        public uint? OverlaySecondaryId
        {
            get { return DidProperties.FirstOrDefault(d => d.DataIdPropertyId == (int)DidPropertyId.IconOverlaySecondary)?.Value; }
        }

        [JsonIgnore]
        public WeenieCommands? MvcAction { get; set; }

        [JsonIgnore]
        public string PropertyTab { get; set; }

        [JsonIgnore]
        public IntPropertyId? NewIntPropertyId { get; set; }

        [JsonIgnore]
        public StringPropertyId? NewStringPropertyId { get; set; }

        [JsonIgnore]
        public Int64PropertyId? NewInt64PropertyId { get; set; }

        [JsonIgnore]
        public DoublePropertyId? NewDoublePropertyId { get; set; }

        [JsonIgnore]
        public DidPropertyId? NewDidPropertyId { get; set; }

        [JsonIgnore]
        public IidPropertyId? NewIidPropertyId { get; set; }

        [JsonIgnore]
        public BoolPropertyId? NewBoolPropertyId { get; set; }

        [JsonIgnore]
        public SpellId? NewSpellId { get; set; }

        [JsonIgnore]
        public PositionType? NewPositionType { get; set; }

        [JsonIgnore]
        public SkillId? NewSkillId { get; set; }

        [JsonIgnore]
        public SkillStatus? NewSkillStatus { get; set; }

        [JsonIgnore]
        public Guid? EmoteSetGuid { get; set; }

        [JsonIgnore]
        public Guid? EmoteGuid { get; set; }

        [JsonIgnore]
        public BodyPartType? NewBodyPartType { get; set; }

        /// <summary>
        /// This should be called after any postback and/or before any save.  due to how we can delete mid-row
        /// in the UI, properties are only soft-deleted and need to be physically removed here.
        /// </summary>
        public void CleanDeletedAndEmptyProperties()
        {
            StringProperties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            IntProperties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            Int64Properties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            DoubleProperties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            BoolProperties?.RemoveAll(x => x == null || x.Deleted);
            DidProperties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            IidProperties?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            Spells?.RemoveAll(x => x == null || x.Deleted);
            BookProperties?.RemoveAll(x => x == null || x.Deleted);
            Positions?.RemoveAll(x => x == null || x.Deleted);
            EmoteTable.ForEach(es => es.Emotes.RemoveAll(x => x == null || x.Deleted));
            EmoteTable?.RemoveAll(x => x == null || x.Deleted);
            BodyParts?.RemoveAll(x => x == null || x.Deleted);
            GeneratorTable?.RemoveAll(x => x == null || x.Deleted);
            CreateList?.RemoveAll(x => x == null || x.Deleted);
            Skills.RemoveAll(x => x == null || x.Deleted);

            if (!HasAbilities)
                Abilities = null;
        }
    }
}
