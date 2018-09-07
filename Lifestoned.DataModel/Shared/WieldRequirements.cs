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
    public enum WieldRequirements
    {
        [Display(Name = "0 - None")]
        None          = 0,

        [Display(Name = "1 - Skill")]
        Skill    = 1,

        [Display(Name = "2 - Base Skill")]
        BaseSkill    = 2,

        [Display(Name = "3 - Attribute")]
        Attribute  = 3,

        [Display(Name = "4 - Base Attribute")]
        BaseAttribute  = 4,

        [Display(Name = "5 - Vital")]
        Vital    = 5,

        [Display(Name = "6 - Base Vital")]
        BaseVital    = 6,

        [Display(Name = "7 - Character Level")]
        CharacterLevel = 7,

        [Display(Name = "8 - Trained Skill")]
        TrainedSkill = 8,

        [Display(Name = "9 - Society")]
        Society = 9,

        [Display(Name = "11 - Creature Only")]
        CreatureOnly = 11
    }

    public static class WieldRequirementsExtensions
    {
        public static string GetDescription(this WieldRequirements? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Description ?? prop?.ToString() ?? "";
        }

        public static string GetName(this WieldRequirements? prop)
        {
            DisplayAttribute description = prop.GetAttributeOfType<DisplayAttribute>();
            return description?.Name ?? prop?.ToString() ?? "";
        }
    }
}
