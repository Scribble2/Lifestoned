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
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Recipe
{
    public class Recipe : BaseModel
    {
        [JsonProperty("recipeGuid")]
        public Guid? RecipeGuid { get; set; }

        /// <summary>
        /// enum RecipeType
        /// </summary>
        [JsonProperty("recipeType")]
        public int? RecipeType { get; set; }

        [JsonIgnore]
        public RecipeType? RecipeType_Binder
        {
            get { return (RecipeType?)RecipeType; }
            set { RecipeType = (int?)value; }
        }

        [JsonIgnore]
        public string RecipeTypeString
        {
            get
            {
                return ((RecipeType?)RecipeType).GetName();
            }
        }

        [JsonProperty("sourceWcid")]
        public uint? SourceWcid { get; set; }

        [JsonProperty("targetWcid")]
        public uint? TargetWcid { get; set; }

        [JsonProperty("skillId")]
        public ushort? SkillId { get; set; }

        public SkillId? Skill_Binder
        {
            get { return (SkillId?)SkillId; }
            set { SkillId = (ushort?)value; }
        }

        public string SkillName
        {
            get
            {
                return ((SkillId?)SkillId).GetName();
            }
        }

        [JsonProperty("skillDifficulty")]
        public ushort? SkillDifficulty { get; set; }

        [JsonProperty("successMessage")]
        public string SuccessMessage { get; set; }

        [JsonProperty("failMessage")]
        public string FailMessage { get; set; }

        /// <summary>
        /// used by dyeing for the alt-colors
        /// </summary>
        [JsonProperty("alternateMessage")]
        public string AlternateMessage { get; set; }

        /// <summary>
        /// enum RecipeResult
        /// </summary>
        [JsonProperty("resultFlags")]
        public int? ResultFlags { get; set; }

        [JsonIgnore]
        public RecipeResult ResultFlags_Binder
        {
            get { return ResultFlags != null ? ((RecipeResult)ResultFlags.Value) : RecipeResult.None; }
            set { ResultFlags = (int)value; }
        }

        [JsonProperty("successItem1Wcid")]
        public uint? SuccessItem1Wcid { get; set; }

        [JsonProperty("successItem1Quantity")]
        public uint? SuccessItem1Quantity { get; set; }

        [JsonProperty("successItem2Wcid")]
        public uint? SuccessItem2Wcid { get; set; }

        [JsonProperty("successItem2Quantity")]
        public uint? SuccessItem2Quantity { get; set; }

        [JsonProperty("failureItem1Wcid")]
        public uint? FailureItem1Wcid { get; set; }

        [JsonProperty("failureItem1Quantity")]
        public uint? FailureItem1Quantity { get; set; }

        [JsonProperty("failureItem2Wcid")]
        public uint? FailureItem2Wcid { get; set; }

        [JsonProperty("failureItem2Quantity")]
        public uint? FailureItem2Quantity { get; set; }

        /// <summary>
        /// enum source: DerethForever.Entity.Enum.Properties.PropertyAttribute
        /// </summary>
        [JsonProperty("healingAttribute")]
        public ushort? HealingAttribute { get; set; }

        [JsonProperty("lastModified")]
        [Display(Name = "Last Modified Date")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        [Display(Name = "Last Modified By")]
        public string ModifiedBy { get; set; }
    }
}
