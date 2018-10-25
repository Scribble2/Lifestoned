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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace Lifestoned.DataModel.DerethForever
{
    public class Emote
    {
        /// <summary>
        /// Table field Primary Key
        /// </summary>
        [JsonProperty("emoteGuid")]
        public Guid? EmoteGuid { get; set; }

        /// <summary>
        /// guid of the emote set
        /// </summary>
        [JsonProperty("emoteSetGuid")]
        public Guid? EmoteSetGuid { get; set; }

        /// <summary>
        /// Emote Type Id - these are found in the code emotetype.cs
        /// </summary>
        [JsonProperty("emoteTypeId")]
        public uint EmoteTypeId { get; set; }

        [JsonIgnore]
        [Display(Name = "Emote Type")]
        public EmoteType EmoteType
        {
            get { return (EmoteType)EmoteTypeId; }
            set { EmoteTypeId = (uint)value; }
        }

        [JsonProperty("delay")]
        [Display(Name = "Delay")]
        public float Delay { get; set; }

        [JsonProperty("extent")]
        [Display(Name = "Extent")]
        public float Extent { get; set; }

        [JsonProperty("message")]
        [Display(Name = "Message")]
        [EmoteType(new uint[] { 0x01, 0x08, 0x0A, 0x0D, 0x10, 0x11, 0x12, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1E, 0x1F, 0x20, 0x21,
                                0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x33, 0x3A, 0x3B, 0x3C, 0x3D, 0x40,
                                0x41, 0x4C, 0x43, 0x44, 0x46, 0x47, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x58, 0x59, 0x66, 0x67,
                                0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x72, 0x79 })]
        public string Message { get; set; }

        [JsonProperty("amount")]
        [Display(Name = "Amount")]
        [EmoteType(new uint[] { 0x1C, 0x1D, 0x20, 0x21, 0x22, 0x2F, 0x30, 0x35, 0x36, 0x37, 0x45, 0x46, 0x48, 0x5A, 0x54, 0x55, 0x56, 0x59, 0x66,
                                0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6F, 0x77, 0x78 })]
        public uint? Amount { get; set; }

        [JsonProperty("stat")]
        [Display(Name = "Stat")]
        [EmoteType(new uint[] { 0x1C, 0x1D, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x32, 0x35, 0x36, 0x37,
                                0x45, 0x4B, 0x6E, 0x72, 0x73, 0x76 })]
        public uint? Stat { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x31)
        ///   ( / 0x32)
        ///   ( / 0x76)
        /// </summary>
        [JsonProperty("percent")]
        [Display(Name = "Percent")]
        [EmoteType(new uint[] { 0x31, 0x32, 0x76 })]
        public double? Percent { get; set; }

        [JsonProperty("minimum")]
        [Display(Name = "Minimum")]
        [EmoteType(new uint[] { 0x1E, 0x24, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x32, 0x3B, 0x47, 0x52 })]
        public uint? Minimum { get; set; }

        [JsonProperty("maximum")]
        [Display(Name = "Maximum")]
        [EmoteType(new uint[] { 0x1E, 0x24, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x32, 0x3B, 0x47, 0x52 })]
        public uint? Maximum { get; set; }

        [JsonProperty("amount64")]
        [Display(Name = "Amount 64")]
        [EmoteType(new uint[] { 0x02, 0x3E, 0x70, 0x71 })]
        public ulong? Amount64 { get; set; }

        [JsonProperty("heroXp64")]
        [Display(Name = "Hero XP 64")]
        [EmoteType(new uint[] { 0x02, 0x3E })]
        public ulong? HeroXp64 { get; set; }

        /// <summary>
        /// this object is misleading.  it only exists for the purposes of json (de)serialization.  the data
        /// is saved via the CP_* properties even though the CreationProfile class's properties are also
        /// decorated.  those properties are used when the creation profile exists as a property entity.
        ///
        /// Emote Types:
        ///   Give (3 / 0x03)
        ///   InqOwnsItems (76 / 0x4C)
        ///   TakeItems (74 / 0x4A)
        /// </summary>
        [JsonProperty("item")]
        [Display(Name = "Creation Profile")]
        [EmoteType(new uint[] { 0x03, 0x4A, 0x4C })]
        public CreationProfile CreationProfile { get; set; } = new CreationProfile();

        /// <summary>
        /// Values over 8 are invalid
        /// Emote Types:
        ///   CreateTreasure (56 / 0x38)
        /// </summary>
        [JsonProperty("wealthRating")]
        public uint? WealthRatingId { get; set; }

        [JsonIgnore]
        [Display(Name = "Wealth Rating")]
        [EmoteType(new uint[] { 0x38 })]
        public WealthRating? WealthRating
        {
            get { return (WealthRating?)WealthRatingId; }
            set { WealthRatingId = (uint?)value; }
        }

        [JsonProperty("treasureClass")]
        public uint? TreasureClassId { get; set; }

        /// <summary>
        /// Emote Types:
        ///   CreateTreasure (56 / 0x38)
        /// </summary>
        [Display(Name = "Treasure Class")]
        [EmoteType(new uint[] { 0x38 })]
        public TreasureClass? TreasureClass
        {
            get { return (TreasureClass?)TreasureClassId; }
            set { TreasureClassId = (uint?)value; }
        }

        /// <summary>
        /// Valid values are 0-3
        /// Emote Types:
        ///   CreateTreasure (56 / 0x38)
        /// </summary>
        [JsonProperty("treasureType")]
        [Display(Name = "Treasure Type")]
        [EmoteType(new uint[] { 0x38 })]
        public uint? TreasureType { get; set; }

        /// <summary>
        /// Emote Types:
        ///   Motion (5 / 0x05)
        ///   ForceMotion (52 / 0x34)
        /// </summary>
        [JsonProperty("motion")]
        public uint? MotionId { get; set; }

        [Display(Name = "Motion")]
        [EmoteType(new uint[] { 0x05, 0x34 })]
        [JsonIgnore]
        public MotionCommand? Motion
        {
            get { return (MotionCommand?)MotionId; }
            set { MotionId = (uint?)value; }
        }

        /// <summary>
        /// Emote Types:
        ///   PhysScript (7 / 0x07)
        /// </summary>
        [JsonProperty("physicsScript")]
        public uint? PhysicsScriptId { get; set; }

        [JsonIgnore]
        [Display(Name = "Physics Script")]
        [EmoteType(new uint[] { 0x07 })]
        public PhysicsScriptType? PhysicsScript
        {
            get { return (PhysicsScriptType?) PhysicsScriptId; }
            set { PhysicsScriptId = (uint?) value; }
        }

        /// <summary>
        /// Emote Types:
        ///   Sound (9 / 0x09)
        /// </summary>
        [JsonProperty("sound")]
        [Display(Name = "Sound")]
        [EmoteType(new uint[] { 0x09 })]
        public uint? Sound { get; set; }

        /// <summary>
        /// Emote Types:
        ///   InqStringStat (38 / 0x26)
        ///   InqYesNo (75 / 0x4B)
        /// </summary>
        [JsonProperty("testString")]
        [Display(Name = "Test String")]
        [EmoteType(new uint[] { 0x26, 0x4B })]
        public string TestString { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x72)
        ///   ( / 0x31)
        /// </summary>
        [JsonProperty("minimum64")]
        [Display(Name = "Minimum 64")]
        [EmoteType(new uint[] { 0x31, 0x72 })]
        public long? Minimum64 { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x72)
        ///   ( / 0x31)
        /// </summary>
        [JsonProperty("maximum64")]
        [Display(Name = "Maximum 64")]
        [EmoteType(new uint[] { 0x31, 0x72 })]
        public long? Maximum64 { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x25)
        /// </summary>
        [JsonProperty("minimumFloat")]
        [Display(Name = "Minimum Float")]
        [EmoteType(new uint[] { 0x25 })]
        public float? MinimumFloat { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x25)
        /// </summary>
        [JsonProperty("maximumFloat")]
        [Display(Name = "Maximum Float")]
        [EmoteType(new uint[] { 0x25 })]
        public float? MaximumFloat { get; set; }

        /// <summary>
        /// Emote Types:
        ///   ( / 0x32)
        /// </summary>
        [JsonProperty("display")]
        [Display(Name = "Display")]
        [EmoteType(new uint[] { 49, 50 })]
        public bool? Display { get; set; }

        [JsonProperty("positionLandblockId")]
        [Display(Name = "Position Landblock Id")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public uint? PositionLandBlockId { get; set; }

        [JsonProperty("positionX")]
        [Display(Name = "Position X")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? PositionX { get; set; }

        [JsonProperty("positionY")]
        [Display(Name = "Position Y")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? PositionY { get; set; }

        [JsonProperty("positionZ")]
        [Display(Name = "Position Z")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? PositionZ { get; set; }

        [JsonProperty("rotationW")]
        [Display(Name = "Rotation W")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? RotationW { get; set; }

        [JsonProperty("rotationX")]
        [Display(Name = "Rotation X")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? RotationX { get; set; }

        [JsonProperty("rotationY")]
        [Display(Name = "Rotation Y")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? RotationY { get; set; }

        [JsonProperty("rotationZ")]
        [Display(Name = "Rotation Z")]
        [EmoteType(new uint[] { 0x3F, 0x63, 0x64 })]
        public float? RotationZ { get; set; }

        [JsonProperty("sortOrder")]
        [Display(Name = "Sort Order")]
        public uint? SortOrder { get; set; }

        [JsonProperty("spellId")]
        [Display(Name = "Spell Id")]
        [EmoteType(new uint[] { 0x0E, 0x13, 0x1B, 0x49 })]
        public uint? SpellId { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        /// <summary>
        /// checks the EmoteType attributes of the requested property to determine whether or not
        /// it should be shown
        /// </summary>
        public static bool IsPropertyVisible(string propertyName, EmoteType emoteType)
        {
            PropertyInfo property = typeof(Emote).GetProperty(propertyName);
            var attribs = property.GetCustomAttributes(typeof(EmoteTypeAttribute), false).Cast<EmoteTypeAttribute>().ToList();

            // because the lists are long and could get unwieldy, we'll allow for multiple on the same property
            return attribs.Any(a => a.TypeList.Contains(emoteType));
        }
    }
}
