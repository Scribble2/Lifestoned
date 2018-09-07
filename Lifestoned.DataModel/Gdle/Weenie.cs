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
using System.Reflection;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.Gdle
{
    public class Weenie : BaseModel
    {
        [JsonProperty("wcid")]
        public uint WeenieId { get; set; }

        [JsonProperty("weenieType")]
        public int WeenieTypeId { get; set; }

        [JsonProperty("attributes")]
        public AttributeSet Attributes { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("pageDataList")]
        public Book Book { get; set; }

        [JsonProperty("boolStats")]
        public List<BoolStat> BoolStats { get; set; } = new List<BoolStat>();

        [JsonProperty("intStats")]
        public List<IntStat> IntStats { get; set; } = new List<IntStat>();

        [JsonProperty("didStats")]
        public List<DidStat> DidStats { get; set; } = new List<DidStat>();

        [JsonProperty("iidStats")]
        public List<IidStat> IidStats { get; set; } = new List<IidStat>();

        [JsonProperty("floatStats")]
        public List<FloatStat> FloatStats { get; set; } = new List<FloatStat>();

        [JsonProperty("int64Stats")]
        public List<Int64Stat> Int64Stats { get; set; } = new List<Int64Stat>();

        [JsonProperty("stringStats")]
        public List<StringStat> StringStats { get; set; } = new List<StringStat>();

        [JsonProperty("createList")]
        public List<CreateItem> CreateList { get; set; }

        [JsonProperty("skills")]
        public List<SkillListing> Skills { get; set; }

        [JsonProperty("emoteTable")]
        public List<EmoteCategoryListing> EmoteTable { get; set; }

        [JsonProperty("spellbook")]
        public List<SpellbookEntry> Spells { get; set; }

        [JsonProperty("posStats")]
        public List<PositionListing> Positions { get; set; }

        [JsonProperty("generatorTable")]
        public List<GeneratorTable> GeneratorTable { get; set; }

        [JsonIgnore]
        public string Name
        {
            get
            {
                return StringStats?.FirstOrDefault(p => p.Key == 1)?.Value ?? WeenieId.ToString();
            }
        }

        [JsonIgnore]
        public int? ItemType
        {
            get { return IntStats.FirstOrDefault(d => d.Key == (int)IntPropertyId.ItemType)?.Value ?? 0; }
        }

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

        [JsonIgnore]
        public bool HasBodyPartList
        {
            get { return (Body?.BodyParts.Count() ?? 0) > 0; }
        }
        
        [JsonIgnore]
        public int? WeenieType
        {
            get { return IntStats.FirstOrDefault(d => d.Key == (int)IntPropertyId.WeenieType)?.Value ?? 0; }
        }

        [JsonIgnore]
        public int? UIEffects
        {
            get { return IntStats.FirstOrDefault(d => d.Key == (int)IntPropertyId.UiEffects)?.Value ?? 0; }
        }

        [JsonIgnore]
        public uint? IconId
        {
            get { return DidStats.FirstOrDefault(d => d.Key == (int)DidPropertyId.Icon)?.Value; }
        }

        [JsonIgnore]
        public uint? UnderlayId
        {
            get { return DidStats.FirstOrDefault(d => d.Key == (int)DidPropertyId.IconUnderlay)?.Value; }
        }

        [JsonIgnore]
        public uint? OverlayId
        {
            get { return DidStats.FirstOrDefault(d => d.Key == (int)DidPropertyId.IconOverlay)?.Value; }
        }

        [JsonIgnore]
        public uint? OverlaySecondaryId
        {
            get { return DidStats.FirstOrDefault(d => d.Key == (int)DidPropertyId.IconOverlaySecondary)?.Value; }
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
        public BodyPartType? NewBodyPartType { get; set; }

        [JsonIgnore]
        public EmoteCategory NewEmoteCategory { get; set; }

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
        
        [JsonProperty("isDone")]
        [Display(Name = "Is Done")]
        public bool IsDone { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// This should be called after any postback and/or before any save.  due to how we can delete mid-row
        /// in the UI, properties are only soft-deleted and need to be physically removed here.
        /// </summary>
        public void CleanDeletedAndEmptyProperties()
        {
            StringStats?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            IntStats?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            Int64Stats?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            FloatStats?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            BoolStats?.RemoveAll(x => x == null || x.Deleted);
            DidStats?.RemoveAll(x => x == null || x.Deleted || x.Value == null);
            Spells?.RemoveAll(x => x == null || x.Deleted);
            Book?.Pages.RemoveAll(x => x == null || x.Deleted);
            Positions?.RemoveAll(x => x == null || x.Deleted);
            EmoteTable.ForEach(es => es.Emotes.RemoveAll(x => x == null || x.Deleted));
            EmoteTable?.RemoveAll(x => x == null || x.Deleted);
            Body?.BodyParts?.RemoveAll(x => x == null || x.Deleted);
            GeneratorTable?.RemoveAll(x => x == null || x.Deleted);
            CreateList?.RemoveAll(x => x == null || x.Deleted);
            Skills.RemoveAll(x => x == null || x.Deleted);

            if (!HasAbilities)
                Attributes = null;
        }

        //public Weenie.Weenie ConvertToWeenie(out List<string> messages)
        //{
        //    messages = new List<string>();
        //    Weenie.Weenie w = new Weenie.Weenie
        //    {
        //        DataObjectId = WeenieId,
        //        WeenieClassId = WeenieId
        //    };

        //    bool intWeenieTypeFound = false;
        //    IntStats.ForEach(stat =>
        //    {
        //        if (stat.Key == (int)IntPropertyId.WeenieType)
        //        {
        //            intWeenieTypeFound = true;
        //        }

        //        w.IntProperties.Add(new Shared.IntProperty()
        //        {
        //            IntPropertyId = stat.Key,
        //            Value = stat.Value
        //        });
        //    });

        //    if (!intWeenieTypeFound)
        //    {
        //        w.IntProperties.Add(new Shared.IntProperty()
        //        {
        //            IntPropertyId = (int)IntPropertyId.WeenieType,
        //            Value = WeenieTypeId
        //        });

        //    }

        //    Int64Stats?.ForEach(stat =>
        //    {
        //        w.Int64Properties.Add(new Shared.Int64Property()
        //        {
        //            Int64PropertyId = stat.Key,
        //            Value = stat.Value
        //        });
        //    });

        //    FloatStats?.ForEach(stat =>
        //    {
        //        w.DoubleProperties.Add(new Shared.DoubleProperty()
        //        {
        //            DoublePropertyId = stat.Key,
        //            Value = stat.Value
        //        });
        //    });

        //    DidStats?.ForEach(stat =>
        //    {
        //        w.DidProperties.Add(new Shared.DataIdProperty()
        //        {
        //            DataIdPropertyId = stat.Key,
        //            Value = stat.Value
        //        });
        //    });

        //    BoolStats?.ForEach(stat =>
        //    {
        //        w.BoolProperties.Add(new Shared.BoolProperty()
        //        {
        //            BoolPropertyId = stat.Key,
        //            Value = stat.BoolValue
        //        });
        //    });

        //    StringStats?.ForEach(stat =>
        //    {
        //        w.StringProperties.Add(new Shared.StringProperty()
        //        {
        //            StringPropertyId = stat.Key,
        //            Value = stat.Value
        //        });
        //    });

        //    Book?.Pages.ForEach(page =>
        //    {
        //        w.BookProperties.Add(new Shared.BookPage()
        //        {
        //            AuthorAccount = page.AuthorAccount,
        //            AuthorId = page.AuthorId,
        //            AuthorName = page.AuthorName,
        //            IgnoreAuthor = page.IgnoreAuthor ?? false,
        //            Page = 1 + (uint)Book.Pages.IndexOf(page),
        //            PageText = page.PageText
        //        });
        //    });

        //    Skills?.ForEach(skill =>
        //    {
        //        w.Skills.Add(new Shared.Skill()
        //        {
        //            SkillId = skill.SkillId,
        //            Ranks = skill.Skill.Ranks,
        //            ExperienceSpent = skill.Skill.XpInvested,
        //            Status = skill.Skill.TrainedLevel,
        //            BaseValue = 0
        //        });
        //    });

        //    Spells?.ForEach(spell =>
        //    {
        //        w.Spells.Add(new Shared.Spell()
        //        {
        //            SpellId = spell.SpellId,
        //            Probability = spell.Stats.CastingChance
        //        });
        //    });

        //    Positions?.ForEach(position =>
        //    {
        //        w.Positions.Add(new Shared.Position()
        //        {
        //            PositionType = position.PositionType,
        //            X = position.Position.Frame.Position.X,
        //            Y = position.Position.Frame.Position.Y,
        //            Z = position.Position.Frame.Position.Z,
        //            QW = position.Position.Frame.Rotations.W,
        //            QX = position.Position.Frame.Rotations.X,
        //            QY = position.Position.Frame.Rotations.Y,
        //            QZ = position.Position.Frame.Rotations.Z,
        //        });
        //    });

        //    GeneratorTable?.ForEach(entry =>
        //    {
        //        Shared.GeneratorTable gt = new Shared.GeneratorTable
        //        {
        //            Frame = new Shared.Frame()
        //        };
        //        gt.Frame.Origin = new Shared.Origin();
        //        gt.Frame.Angles = new Shared.Angles();

        //        PropertyCopier<GeneratorTable, Shared.GeneratorTable>.Copy(entry, gt);
        //        gt.Frame.Angles.W = entry.Frame.Rotations.W;
        //        gt.Frame.Angles.X = entry.Frame.Rotations.X;
        //        gt.Frame.Angles.Y = entry.Frame.Rotations.Y;
        //        gt.Frame.Angles.Z = entry.Frame.Rotations.Z;
        //        gt.Frame.Origin.X = entry.Frame.Position.X;
        //        gt.Frame.Origin.Y = entry.Frame.Position.Y;
        //        gt.Frame.Origin.Z = entry.Frame.Position.Z;

        //        w.GeneratorTable.Add(gt);
        //    });

        //    uint emoteSetCounter = 0;
        //    if (EmoteTable != null)
        //        emoteSetCounter = (uint)EmoteTable?.Count;

        //    uint emoteCounter = 0;
        //    uint holdCategory = 0;

        //    EmoteTable?.ForEach(category =>
        //    {
        //        if (category.EmoteCategoryId != holdCategory)
        //        {
        //            holdCategory = (uint)category.EmoteCategoryId;

        //            if (holdCategory != 0)
        //                emoteSetCounter--;
        //        }

        //        category.Emotes.ForEach(e =>
        //        {
        //            var es = new Shared.EmoteSet()
        //            {
        //                EmoteSetGuid = Guid.NewGuid(),
        //                ClassId = e.ClassId,
        //                EmoteCategoryId = e.Category,
        //                MaxHealth = e.MaxHealth,
        //                MinHealth = e.MinHealth,
        //                Probability = e.Probability,
        //                Quest = e.Quest,
        //                Style = e.Style,
        //                SubStyle = e.SubStyle,
        //                SortOrder = emoteSetCounter,
        //                VendorType = e.VendorType
        //            };

        //            emoteCounter = 0;
        //            e.Emotes.ForEach(ea =>
        //            {
        //                es.Emotes.Add(new Shared.Emote()
        //                {
        //                    Amount = ea.Amount,
        //                    Amount64 = ea.Amount64,
        //                    CreationProfile = ea?.Item?.Convert(),
        //                    Delay = ea.Delay ?? 0f,
        //                    Deleted = false,
        //                    Display = ea.Display,
        //                    EmoteTypeId = ea.EmoteActionType,
        //                    EmoteGuid = Guid.NewGuid(),
        //                    EmoteSetGuid = es.EmoteSetGuid,
        //                    Extent = ea.Extent ?? 0f,
        //                    HeroXp64 = ea.HeroXp64,
        //                    Maximum = ea.Max,
        //                    Maximum64 = ea.Maximum64,
        //                    MaximumFloat = ea.FMax,
        //                    Message = ea.Message,
        //                    Minimum = ea.Min,
        //                    Minimum64 = ea.Minimum64,
        //                    MinimumFloat = ea.FMin,
        //                    Motion = (MotionCommand?)ea.Motion,
        //                    Percent = ea.Percent,
        //                    PhysicsScript = (PhysicsScriptType?)ea.PScript,
        //                    PositionLandBlockId = ea.MPosition?.LandCellId,
        //                    RotationW = ea.MPosition?.Frame.Rotations.W,
        //                    RotationX = ea.MPosition?.Frame.Rotations.X,
        //                    RotationY = ea.MPosition?.Frame.Rotations.Y,
        //                    RotationZ = ea.MPosition?.Frame.Rotations.Z,
        //                    PositionX = ea.MPosition?.Frame.Position.X,
        //                    PositionY = ea.MPosition?.Frame.Position.Y,
        //                    PositionZ = ea.MPosition?.Frame.Position.Z,
        //                    Sound = ea.Sound,
        //                    SpellId = ea.SpellId,
        //                    Stat = ea.Stat,
        //                    TestString = ea.TestString,
        //                    TreasureClass = (TreasureClass?)ea.TreasureClass,
        //                    TreasureType = (uint?)ea.TreasureType,
        //                    SortOrder = emoteCounter,
        //                    WealthRating = (WealthRating?)ea.WealthRating
        //                });
        //                emoteCounter++;
        //            });
        //            w.EmoteTable.Add(es);
        //        });
        //    });

        //    CreateList?.ForEach(ci =>
        //    {
        //        w.CreateList.Add(ci.Convert());
        //    });

        //    if (w.HasAbilities)
        //    {
        //        w.Abilities.Strength = Attributes.Strength.Convert(AbilityId.Strength);
        //        w.Abilities.Endurance = Attributes.Endurance.Convert(AbilityId.Endurance);
        //        w.Abilities.Coordination = Attributes.Coordination.Convert(AbilityId.Coordination);
        //        w.Abilities.Quickness = Attributes.Quickness.Convert(AbilityId.Quickness);
        //        w.Abilities.Focus = Attributes.Focus.Convert(AbilityId.Focus);
        //        w.Abilities.Self = Attributes.Self.Convert(AbilityId.Self);

        //        w.Vitals.Health = Attributes.Health.Convert(AbilityId.Health);
        //        w.Vitals.Stamina = Attributes.Stamina.Convert(AbilityId.Stamina);
        //        w.Vitals.Mana = Attributes.Mana.Convert(AbilityId.Mana);
        //    }

        //    Body?.BodyParts?.ForEach(bp =>
        //    {
        //        var part = new Shared.BodyPart()
        //        {
        //            BodyHeight = bp.BodyPart.BH,
        //            BodyPartType = (BodyPartType)bp.Key,
        //            Damage = bp.BodyPart.DVal,
        //            DamageType = (DamageType)bp.BodyPart.DType,
        //            DamageVariance = bp.BodyPart.DVar
        //        };

        //        if (bp.BodyPart.ArmorValues != null)
        //        {
        //            part.ArmorValues.Base = bp.BodyPart.ArmorValues.BaseArmor;
        //            part.ArmorValues.Acid = bp.BodyPart.ArmorValues.ArmorVsAcid;
        //            part.ArmorValues.Bludgeon = bp.BodyPart.ArmorValues.ArmorVsBludgeon;
        //            part.ArmorValues.Cold = bp.BodyPart.ArmorValues.ArmorVsCold;
        //            part.ArmorValues.Electric = bp.BodyPart.ArmorValues.ArmorVsElectric;
        //            part.ArmorValues.Fire = bp.BodyPart.ArmorValues.ArmorVsFire;
        //            part.ArmorValues.Nether = bp.BodyPart.ArmorValues.ArmorVsNether;
        //            part.ArmorValues.Pierce = bp.BodyPart.ArmorValues.ArmorVsPierce;
        //            part.ArmorValues.Slash = bp.BodyPart.ArmorValues.ArmorVsSlash;
        //        }

        //        if (bp.BodyPart.SD != null)
        //        {
        //            part.TargetingData.HighLeftBack = bp.BodyPart.SD.HLB;
        //            part.TargetingData.HighLeftFront = bp.BodyPart.SD.HLF;
        //            part.TargetingData.HighRightBack = bp.BodyPart.SD.HRB;
        //            part.TargetingData.HighRightFront = bp.BodyPart.SD.HRF;
        //            part.TargetingData.LowLeftBack = bp.BodyPart.SD.LLB;
        //            part.TargetingData.LowLeftFront = bp.BodyPart.SD.LLF;
        //            part.TargetingData.LowRightBack = bp.BodyPart.SD.LRB;
        //            part.TargetingData.LowRightFront = bp.BodyPart.SD.LRF;
        //            part.TargetingData.MidLeftBack = bp.BodyPart.SD.MLB;
        //            part.TargetingData.MidLeftFront = bp.BodyPart.SD.MLF;
        //            part.TargetingData.MidRightBack = bp.BodyPart.SD.MRB;
        //            part.TargetingData.MidRightFront = bp.BodyPart.SD.MRF;
        //        }

        //        w.BodyParts.Add(part);
        //    });

        //    return w;
        //}

        public static Weenie ConvertFromWeenie(DerethForever.Weenie dfWeenie)
        {
            Weenie pwn = new Weenie
            {
                WeenieId = dfWeenie.WeenieClassId,
                WeenieTypeId = dfWeenie.IntProperties.First(i => i.IntPropertyId == (int)IntPropertyId.WeenieType).Value
                .Value
            };

            if (dfWeenie.IntProperties?.Count > 0)
                pwn.IntStats = new List<IntStat>();

            dfWeenie.IntProperties?.Where(ip => ip.Value != null).ToList().ForEach(ip =>
            {
                pwn.IntStats.Add(new IntStat()
                {
                    Key = ip.IntPropertyId,
                    Value = ip.Value.Value
                });
            });

            if (dfWeenie.Int64Properties?.Count > 0)
                pwn.Int64Stats = new List<Int64Stat>();

            dfWeenie.Int64Properties?.Where(ip => ip.Value != null).ToList().ForEach(ip =>
            {
                pwn.Int64Stats.Add(new Int64Stat()
                {
                    Key = ip.Int64PropertyId,
                    Value = ip.Value.Value
                });
            });

            if (dfWeenie.DoubleProperties?.Count > 0)
                pwn.FloatStats = new List<FloatStat>();

            dfWeenie.DoubleProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                pwn.FloatStats.Add(new FloatStat()
                {
                    Key = dp.DoublePropertyId,
                    Value = (float)dp.Value.Value
                });
            });

            if (dfWeenie.BoolProperties?.Count > 0)
                pwn.BoolStats = new List<BoolStat>();

            dfWeenie.BoolProperties?.ForEach(bp =>
            {
                pwn.BoolStats.Add(new BoolStat()
                {
                    Key = bp.BoolPropertyId,
                    BoolValue = bp.Value
                });
            });

            if (dfWeenie.DidProperties?.Count > 0)
                pwn.DidStats = new List<DidStat>();

            dfWeenie.DidProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                pwn.DidStats.Add(new DidStat()
                {
                    Key = dp.DataIdPropertyId,
                    Value = dp.Value.Value
                });
            });

            if (dfWeenie.IidProperties?.Count > 0)
                pwn.IidStats = new List<IidStat>();

            dfWeenie.IidProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                pwn.IidStats.Add(new IidStat()
                {
                    Key = dp.IidPropertyId,
                    Value = dp.Value.Value
                });
            });

            if (dfWeenie.StringProperties?.Count > 0)
                pwn.StringStats = new List<StringStat>();

            dfWeenie.StringProperties?.ForEach(sp =>
            {
                pwn.StringStats.Add(new StringStat()
                {
                    Key = sp.StringPropertyId,
                    Value = sp.Value
                });
            });

            if (dfWeenie.BookProperties.Count > 0)
            {
                pwn.Book = new Book
                {
                    Pages = new List<Page>(),

                    MaxCharactersPerPage = 1000
                };

                dfWeenie.BookProperties.ForEach(bp =>
                {
                    pwn.Book.Pages.Add(new Page()
                    {
                        AuthorAccount = bp.AuthorAccount,
                        AuthorId = bp.AuthorId,
                        AuthorName = bp.AuthorName,
                        IgnoreAuthor = bp.IgnoreAuthor,
                        PageText = bp.PageText.Replace("\r\n", "\n").Replace("\r\n\r\n", "\n") // This is looking for both \r\n and \r\n\r\n that happen to show up when an upload is made. If the upload has \n\n it is creating \r\n\r\n so this looks for both and replaces them with \n
                    });
                });
                pwn.Book.MaxNumberPages = pwn.Book.Pages.Count; // Thwargle fixed the maxNumPages to count pages woo woo
            }

            if (dfWeenie.HasAbilities)
            {
                pwn.Attributes = new AttributeSet
                {
                    Strength = Attribute.Convert(dfWeenie.Abilities.Strength),
                    Endurance = Attribute.Convert(dfWeenie.Abilities.Endurance),
                    Coordination = Attribute.Convert(dfWeenie.Abilities.Coordination),
                    Quickness = Attribute.Convert(dfWeenie.Abilities.Quickness),
                    Focus = Attribute.Convert(dfWeenie.Abilities.Focus),
                    Self = Attribute.Convert(dfWeenie.Abilities.Self),

                    Health = Vital.Convert(dfWeenie.Vitals.Health),
                    Stamina = Vital.Convert(dfWeenie.Vitals.Stamina),
                    Mana = Vital.Convert(dfWeenie.Vitals.Mana)
                };


                if (dfWeenie.Skills?.Count > 0)
                    pwn.Skills = new List<SkillListing>();

                // also applies to skills
                dfWeenie.Skills.ForEach(s =>
                {
                    pwn.Skills.Add(new SkillListing()
                    {
                        SkillId = s.SkillId,
                        Skill = new Skill()
                        {
                            Ranks = s.Ranks,
                            TrainedLevel = s.Status,
                            XpInvested = (uint?)s.ExperienceSpent ?? 0,
                            ResistanceOfLastCheck = 0,
                            LevelFromPp = 0,
                            LastUsed = 0.0f
                        }
                    });
                });
            }

            if (dfWeenie.Positions?.Count > 0)
                pwn.Positions = new List<PositionListing>();

            dfWeenie.Positions?.ForEach(p =>
            {
                pwn.Positions.Add(new PositionListing()
                {
                    PositionType = p.PositionType,
                    Position = new Position()
                    {
                        Frame = new Frame()
                        {
                            Position = new XYZ()
                            {
                                X = p.X,
                                Y = p.Y,
                                Z = p.Z
                            },
                            Rotations = new Quaternion()
                            {
                                W = p.QW,
                                X = p.QX,
                                Y = p.QY,
                                Z = p.QZ
                            }
                        },
                        LandCellId = p.Landblock
                    }
                });
            });

            if (dfWeenie.Spells?.Count > 0)
                pwn.Spells = new List<SpellbookEntry>();

            dfWeenie.Spells?.ForEach(s =>
            {
                pwn.Spells.Add(new SpellbookEntry()
                {
                    SpellId = s.SpellId,
                    Stats = new SpellCastingStats() { CastingChance = s.Probability }
                });
            });

            if (dfWeenie.CreateList?.Count > 0)
                pwn.CreateList = new List<CreateItem>();

            dfWeenie.CreateList?.ForEach(cl =>
            {
                pwn.CreateList.Add(new CreateItem()
                {
                    Destination = cl.Destination,
                    Palette = cl.Palette,
                    Shade = cl.Shade,
                    StackSize = cl.StackSize,
                    TryToBond = cl.TryToBond != null && (bool)cl.TryToBond ? (byte)1 : (byte)0,
                    WeenieClassId = cl.WeenieClassId
                });
            });

            if (dfWeenie.GeneratorTable?.Count > 0)
                pwn.GeneratorTable = new List<GeneratorTable>();

            dfWeenie.GeneratorTable?.ForEach(gt =>
            {
                GeneratorTable ngt = new GeneratorTable()
                {
                    Delay = gt.Delay,
                    InitCreate = gt.InitCreate,
                    MaxNumber = gt.MaxNumber,
                    ObjectCell = gt.ObjectCell,
                    PaletteId = gt.PaletteId,
                    Probability = gt.Probability,
                    Shade = gt.Shade,
                    Slot = gt.Slot,
                    StackSize = gt.StackSize,
                    WeenieClassId = gt.WeenieClassId,
                    WhenCreate = gt.WhenCreate,
                    WhereCreate = gt.WhereCreate
                };
                ngt.Frame = new Frame
                {
                    Position = new XYZ(),
                    Rotations = new Quaternion
                    {
                        W = gt.Frame.Angles.W,
                        X = gt.Frame.Angles.X,
                        Y = gt.Frame.Angles.Y,
                        Z = gt.Frame.Angles.Z
                    }
                };
                ngt.Frame.Position.X = gt.Frame.Origin.X;
                ngt.Frame.Position.Y = gt.Frame.Origin.Y;
                ngt.Frame.Position.X = gt.Frame.Origin.X;

                pwn.GeneratorTable.Add(ngt);
            });

            if (dfWeenie.EmoteTable?.Count > 0)
            {
                pwn.EmoteTable = new List<EmoteCategoryListing>();

                foreach (var es in dfWeenie.EmoteTable)
                {
                    if (!pwn.EmoteTable.Any(et => et.EmoteCategoryId == (int)es.EmoteCategoryId))
                        pwn.EmoteTable.Add(new EmoteCategoryListing()
                        {
                            EmoteCategoryId = (int)es.EmoteCategoryId,
                            Emotes = new List<Emote>()
                        });

                    EmoteCategoryListing ecl =
                        pwn.EmoteTable.First(et => et.EmoteCategoryId == (int)es.EmoteCategoryId);

                    var pwnEmote = new Emote()
                    {
                        ClassId = es.ClassId,
                        Category = es.EmoteCategoryId,
                        MaxHealth = es.MaxHealth,
                        MinHealth = es.MinHealth,
                        Probability = es.Probability,
                        Quest = es.Quest,
                        Style = es.Style,
                        SubStyle = es.SubStyle,
                        VendorType = es.VendorType,
                        Emotes = new List<EmoteAction>()
                    };

                    es.Emotes.ForEach(dfEmote =>
                    {
                        var ea = new EmoteAction()
                        {
                            Amount = dfEmote.Amount,
                            Amount64 = dfEmote.Amount64,
                            Delay = dfEmote.Delay,
                            Display = dfEmote.Display,
                            EmoteActionType = dfEmote.EmoteTypeId,
                            Extent = dfEmote.Extent,
                            FMax = dfEmote.MaximumFloat,
                            FMin = dfEmote.MinimumFloat,
                            HeroXp64 = dfEmote.HeroXp64,
                            Max = dfEmote.Maximum,
                            Maximum64 = dfEmote.Maximum64,
                            Message = dfEmote.Message,
                            Min = dfEmote.Minimum,
                            Minimum64 = dfEmote.Minimum64,
                            Motion = dfEmote.MotionId,
                            Percent = (float?)dfEmote.Percent,
                            PScript = dfEmote.PhysicsScriptId,
                            Sound = dfEmote.Sound,
                            SpellId = dfEmote.SpellId,
                            Stat = dfEmote.Stat,
                            TestString = dfEmote.TestString,
                            TreasureClass = dfEmote.TreasureClassId,
                            TreasureType = (int?)dfEmote.TreasureType,
                            WealthRating = dfEmote.WealthRatingId,
                        };

                        //if (dfEmote.Message == null)
                        //{
                        //    ea.Message = "";
                        //}

                        if (dfEmote.PositionLandBlockId != null)
                        {
                            ea.MPosition = new Position();
                        }

                        if (dfEmote.PositionX != null)
                        {
                            ea.MPosition.Frame = new Frame()
                            {
                                Position = new XYZ()
                                {
                                    X = dfEmote.PositionX.Value,
                                    Y = dfEmote.PositionY.Value,
                                    Z = dfEmote.PositionZ.Value
                                },

                                Rotations = new Quaternion()
                                {
                                    W = dfEmote.RotationW.Value,
                                    X = dfEmote.RotationX.Value,
                                    Y = dfEmote.RotationY.Value,
                                    Z = dfEmote.RotationZ.Value
                                }
                            };
                        }

                        if (dfEmote.CreationProfile != null &&
                            DerethForever.Emote.IsPropertyVisible("CreationProfile", dfEmote.EmoteType))
                        {
                            ea.Item = new CreateItem()
                            {
                                Destination = dfEmote.CreationProfile.Destination,
                                Palette = dfEmote.CreationProfile.Palette,
                                Shade = dfEmote.CreationProfile.Shade,
                                StackSize = dfEmote.CreationProfile.StackSize,
                                TryToBond = dfEmote.CreationProfile.TryToBond != null && (bool)dfEmote.CreationProfile.TryToBond ? (byte)1 : (byte?)0,
                                WeenieClassId = dfEmote.CreationProfile.WeenieClassId
                            };
                        }

                        pwnEmote.Emotes.Add(ea);
                    });

                    ecl.Emotes.Add(pwnEmote);

                    // previous code ensures the "ecl" is already added to pwn.EmoteTable
                }
            }

            if (dfWeenie.BodyParts?.Count > 0)
            {
                pwn.Body = new Body
                {
                    BodyParts = new List<BodyPartListing>()
                };
            }

            dfWeenie.BodyParts?.ForEach(bp =>
            {
                pwn.Body.BodyParts.Add(new BodyPartListing()
                {
                    Key = (int)bp.BodyPartType,
                    BodyPart = new BodyPart()
                    {
                        BH = bp.BodyHeight,
                        DType = (int)bp.DamageType,
                        DVal = bp.Damage,
                        DVar = bp.DamageVariance,
                        ArmorValues = new ArmorValues()
                        {
                            ArmorVsAcid = bp.ArmorValues.Acid,
                            ArmorVsBludgeon = bp.ArmorValues.Bludgeon,
                            ArmorVsCold = bp.ArmorValues.Cold,
                            ArmorVsElectric = bp.ArmorValues.Electric,
                            ArmorVsFire = bp.ArmorValues.Fire,
                            ArmorVsNether = bp.ArmorValues.Nether,
                            ArmorVsPierce = bp.ArmorValues.Pierce,
                            ArmorVsSlash = bp.ArmorValues.Slash,
                            BaseArmor = bp.ArmorValues.Base
                        },
                        SD = new Zones()
                        {
                            HLB = bp.TargetingData.HighLeftBack,
                            HLF = bp.TargetingData.HighLeftFront,
                            HRB = bp.TargetingData.HighRightBack,
                            HRF = bp.TargetingData.HighRightFront,
                            LLB = bp.TargetingData.LowLeftBack,
                            LLF = bp.TargetingData.LowLeftFront,
                            LRB = bp.TargetingData.LowRightBack,
                            LRF = bp.TargetingData.LowRightFront,
                            MLB = bp.TargetingData.MidLeftBack,
                            MLF = bp.TargetingData.MidLeftFront,
                            MRB = bp.TargetingData.MidRightBack,
                            MRF = bp.TargetingData.MidRightFront
                        }
                    }
                });
            });
            return pwn;
        }

        public class PropertyCopier<TParent, TChild> where TParent : class where TChild : class
        {
            public static void Copy(TParent parent, TChild child)
            {
                PropertyInfo[] parentProperties = parent.GetType().GetProperties();
                PropertyInfo[] childProperties = child.GetType().GetProperties();
                foreach (PropertyInfo parentProperty in parentProperties)
                {
                    foreach (PropertyInfo childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name &&
                            parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }
            }
        }
    }
}
