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
using System.Linq;
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Shared
{
    public class IntProperty
    {
        [JsonProperty("intPropertyId")]
        public int IntPropertyId { get; set; }

        [JsonIgnore]
        public string PropertyIdBinder
        {
            get { return ((IntPropertyId)IntPropertyId).GetName(); }
        }

        [JsonProperty("index")]
        public int? Index { get; set; } = 0;

        [JsonProperty("value")]
        public int? Value { get; set; }

        [JsonIgnore]
        public string[] MultiSelectRaw { get; set; }

        [JsonIgnore]
        public string[] MultiSelect
        {
            get
            {
                if (Value == null)
                    return null;

                int v = Value.Value;
                List<int> values = new List<int>();

                // powers of 2 unite!
                for (int i = 0; i <= 31; i++)
                {
                    uint b = (uint)Math.Pow(2, i);
                    if ((b & v) != 0)
                        values.Add((int)b);
                }

                return values.Select(i => i.ToString()).ToArray();
            }
            set
            {
                MultiSelectRaw = value;
                if (value == null || value.Length < 1)
                {
                    Value = null;
                    return;
                }

                Value = 0;
                foreach(string id in value)
                    Value += int.Parse(id);
            }
        }

        [JsonIgnore]
        public ItemType? ItemTypeBoundValue
        {
            get { return (ItemType?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public WeenieType? WeenieTypeBoundValue
        {
            get { return (WeenieType?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public CreatureType? CreatureTypeBoundValue
        {
            get { return (CreatureType?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public ArmorType? ArmorTypeBoundValue
        {
            get { return (ArmorType?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public WieldRequirements? WieldRequirementsBoundValue
        {
            get { return (WieldRequirements?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public PaletteTemplate? PaletteTemplateBoundValue
        {
            get { return (PaletteTemplate?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public int? UiEffects { get; set; }

        [JsonIgnore]
        public Material? Material_Binder
        {
            get { return (Material?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public HeritageGroup? HeritageBinder
        {
            get { return (HeritageGroup?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public WeaponType? WeaponTypeBoundValue
        {
            get { return (WeaponType?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public SkillId? SkillIdBoundValue
        {
            get { return (SkillId?)Value; }
            set { Value = (int?)value; }
        }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
