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

        [JsonIgnore]
        public uint WeenieClassId
        {
            get { return WeenieId; }
            set { WeenieId = value; }
        }

        [JsonProperty("weenieType")]
        public int WeenieTypeId { get; set; }

        [JsonIgnore]
        public WeenieType WeenieType_Binder
        {
            get { return (WeenieType)WeenieTypeId; }
            set { WeenieTypeId = (int)value; }
        }

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

        #region Shortcut properties without standard backers

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
            get { return GeneratorTable?.Count > 0; }
        }

        [JsonIgnore]
        public bool HasBodyPartList
        {
            get { return (Body?.BodyParts.Count() ?? 0) > 0; }
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

        #endregion

        #region unpersisted MVC helper properties

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

		[JsonIgnore]
		public int? EmoteSetGuid { get; set; }

        #endregion

        #region Meta data properties

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

        #endregion

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
            Book?.Pages?.RemoveAll(x => x == null || x.Deleted);
            Positions?.RemoveAll(x => x == null || x.Deleted);
            EmoteTable?.ForEach(es => es?.Emotes?.RemoveAll(x => x == null || x.Deleted));
            EmoteTable?.RemoveAll(x => x == null || x.Deleted);
            Body?.BodyParts?.RemoveAll(x => x == null || x.Deleted);
            GeneratorTable?.RemoveAll(x => x == null || x.Deleted);
            CreateList?.RemoveAll(x => x == null || x.Deleted);
            Skills?.RemoveAll(x => x == null || x.Deleted);

            // this property's existence causes all sorts of problems.  needs to go away.
            IntStats?.RemoveAll(x => x.Key == 9007);

            if (!HasAbilities)
                Attributes = null;
        }
        
        public static Weenie ConvertFromWeenie(DerethForever.Weenie df)
        {
            Weenie gdle = new Weenie
            {
                WeenieId = df.WeenieClassId,
                WeenieTypeId = df.IntProperties.First(i => i.IntPropertyId == 9007).Value.Value,
                IsDone = df.IsDone,
                Comments = df.Comments,
                UserChangeSummary = df.UserChangeSummary,
                Changelog = df.Changelog?.ToList(), // force a copy
                ModifiedBy = df.ModifiedBy,
                LastModified = df.LastModified
            };

            if (df.IntProperties?.Count > 0)
                gdle.IntStats = new List<IntStat>();

            df.IntProperties?.Where(ip => ip.Value != null).ToList().ForEach(ip =>
            {
                gdle.IntStats.Add(new IntStat()
                {
                    Key = ip.IntPropertyId,
                    Value = ip.Value.Value
                });
            });

            if (df.Int64Properties?.Count > 0)
                gdle.Int64Stats = new List<Int64Stat>();

            df.Int64Properties?.Where(ip => ip.Value != null).ToList().ForEach(ip =>
            {
                gdle.Int64Stats.Add(new Int64Stat()
                {
                    Key = ip.Int64PropertyId,
                    Value = ip.Value.Value
                });
            });

            if (df.DoubleProperties?.Count > 0)
                gdle.FloatStats = new List<FloatStat>();

            df.DoubleProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                gdle.FloatStats.Add(new FloatStat()
                {
                    Key = dp.DoublePropertyId,
                    Value = (float)dp.Value.Value
                });
            });

            if (df.BoolProperties?.Count > 0)
                gdle.BoolStats = new List<BoolStat>();

            df.BoolProperties?.ForEach(bp =>
            {
                gdle.BoolStats.Add(new BoolStat()
                {
                    Key = bp.BoolPropertyId,
                    BoolValue = bp.Value
                });
            });

            if (df.DidProperties?.Count > 0)
                gdle.DidStats = new List<DidStat>();

            df.DidProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                gdle.DidStats.Add(new DidStat()
                {
                    Key = dp.DataIdPropertyId,
                    Value = dp.Value.Value
                });
            });

            if (df.IidProperties?.Count > 0)
                gdle.IidStats = new List<IidStat>();

            df.IidProperties?.Where(dp => dp.Value != null).ToList().ForEach(dp =>
            {
                gdle.IidStats.Add(new IidStat()
                {
                    Key = dp.IidPropertyId,
                    Value = dp.Value.Value
                });
            });

            if (df.StringProperties?.Count > 0)
                gdle.StringStats = new List<StringStat>();

            df.StringProperties?.ForEach(sp =>
            {
                gdle.StringStats.Add(new StringStat()
                {
                    Key = sp.StringPropertyId,
                    Value = sp.Value
                });
            });

            if (df.BookProperties.Count > 0)
            {
                gdle.Book = new Book
                {
                    Pages = new List<Page>(),

                    MaxCharactersPerPage = 1000
                };

                df.BookProperties.ForEach(bp =>
                {
                    gdle.Book.Pages.Add(new Page()
                    {
                        AuthorAccount = bp.AuthorAccount,
                        AuthorId = bp.AuthorId,
                        AuthorName = bp.AuthorName,
                        IgnoreAuthor = bp.IgnoreAuthor,
                        PageText = bp.PageText.Replace("\r\n", "\n").Replace("\r\n\r\n", "\n") // This is looking for both \r\n and \r\n\r\n that happen to show up when an upload is made. If the upload has \n\n it is creating \r\n\r\n so this looks for both and replaces them with \n
                    });
                });
                gdle.Book.MaxNumberPages = gdle.Book.Pages.Count; // Thwargle fixed the maxNumPages to count pages woo woo
            }

            if (df.HasAbilities)
            {
                gdle.Attributes = new AttributeSet
                {
                    Strength = Attribute.Convert(df.Abilities.Strength),
                    Endurance = Attribute.Convert(df.Abilities.Endurance),
                    Coordination = Attribute.Convert(df.Abilities.Coordination),
                    Quickness = Attribute.Convert(df.Abilities.Quickness),
                    Focus = Attribute.Convert(df.Abilities.Focus),
                    Self = Attribute.Convert(df.Abilities.Self),

                    Health = Vital.Convert(df.Vitals.Health),
                    Stamina = Vital.Convert(df.Vitals.Stamina),
                    Mana = Vital.Convert(df.Vitals.Mana)
                };


                if (df.Skills?.Count > 0)
                    gdle.Skills = new List<SkillListing>();

                // also applies to skills
                df.Skills.ForEach(s =>
                {
                    gdle.Skills.Add(new SkillListing()
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

            if (df.Positions?.Count > 0)
                gdle.Positions = new List<PositionListing>();

            df.Positions?.ForEach(p =>
            {
                gdle.Positions.Add(new PositionListing()
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

            if (df.Spells?.Count > 0)
                gdle.Spells = new List<SpellbookEntry>();

            df.Spells?.ForEach(s =>
            {
                gdle.Spells.Add(new SpellbookEntry()
                {
                    SpellId = s.SpellId,
                    Stats = new SpellCastingStats() { CastingChance = s.Probability }
                });
            });

            if (df.CreateList?.Count > 0)
                gdle.CreateList = new List<CreateItem>();

            df.CreateList?.ForEach(cl =>
            {
                gdle.CreateList.Add(new CreateItem()
                {
                    Destination = cl.Destination,
                    Palette = cl.Palette,
                    Shade = cl.Shade,
                    StackSize = cl.StackSize,
                    TryToBond = cl.TryToBond != null && (bool)cl.TryToBond ? (byte)1 : (byte)0,
                    WeenieClassId = cl.WeenieClassId
                });
            });

            if (df.GeneratorTable?.Count > 0)
                gdle.GeneratorTable = new List<GeneratorTable>();

            df.GeneratorTable?.ForEach(gt =>
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

                gdle.GeneratorTable.Add(ngt);
            });

            if (df.EmoteTable?.Count > 0)
            {
                gdle.EmoteTable = new List<EmoteCategoryListing>();

                foreach (var es in df.EmoteTable)
                {
                    if (!gdle.EmoteTable.Any(et => et.EmoteCategoryId == (int)es.EmoteCategoryId))
                        gdle.EmoteTable.Add(new EmoteCategoryListing()
                        {
                            EmoteCategoryId = (int)es.EmoteCategoryId,
                            Emotes = new List<Emote>()
                        });

                    EmoteCategoryListing ecl =
                        gdle.EmoteTable.First(et => et.EmoteCategoryId == (int)es.EmoteCategoryId);

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
                        Actions = new List<EmoteAction>()
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
                            ea.MPosition = new Position();
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

                        pwnEmote.Actions.Add(ea);
                    });

                    ecl.Emotes.Add(pwnEmote);

                    // previous code ensures the "ecl" is already added to pwn.EmoteTable
                }
            }

            if (df.BodyParts?.Count > 0)
            {
                gdle.Body = new Body
                {
                    BodyParts = new List<BodyPartListing>()
                };
            }

            df.BodyParts?.ForEach(bp =>
            {
                gdle.Body.BodyParts.Add(new BodyPartListing()
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
            return gdle;
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
