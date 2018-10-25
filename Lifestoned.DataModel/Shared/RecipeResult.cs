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
using System.Web;

namespace Lifestoned.DataModel.Shared
{
    [Flags]
    public enum RecipeResult
    {
        None                     = 0,
        [Display(Name = "0x01 - Source Item Destroyed")]
        SourceItemDestroyed      = 1,
        [Display(Name = "0x02 - Target Item Destroyed")]
        TargetItemDestroyed      = 2,
        [Display(Name = "0x04 - Source Item Uses Decrement")]
        SourceItemUsesDecrement  = 4,
        [Display(Name = "0x08 - Target Item Uses Decrement")]
        TargetItemUsesDecrement  = 8,
        [Display(Name = "0x10 - Success Item 1")]
        SuccessItem1             = 16,
        [Display(Name = "0x20 - Success Item 2")]
        SuccessItem2             = 32,
        [Display(Name = "0x40 - Failure Item 1")]
        FailureItem1             = 64,
        [Display(Name = "0x80 - Failure Item 2")]
        FailureItem2             = 128
    }

    public static class RecipeResultExtensions
    {
        public static string GetDescription(this RecipeResult prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString() ?? "";
        }

        public static string GetName(this RecipeResult prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString() ?? "";
        }
    }
}
