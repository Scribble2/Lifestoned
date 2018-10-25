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
    public enum BodyPartType
    {
        Undefined           = -1,
        Head                = 0,
        Chest               = 1,
        Abdomen             = 2,
        UpperArm            = 3,
        LowerArm            = 4,
        Hand                = 5,
        UpperLeg            = 6,
        LowerLeg            = 7,
        Foot                = 8,
        Horn                = 9,
        FrontLeg            = 10,
        // 11 is missing in client
        FrontFoot           = 12,
        RearLeg             = 13,
        // 14 is missing in client
        RearFoot            = 15,
        Torso               = 16,
        Tail                = 17,
        Arm                 = 18,
        Leg                 = 19,
        Claw                = 20,
        Wings               = 21,
        Breath              = 22,
        Tentacle            = 23,
        UpperTentacle       = 24,
        LowerTentacle       = 25,
        Cloak               = 26
    }

    public static class BodyPartTypeExtensions
    {
        public static string GetDescription(this BodyPartType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString() ?? "";
        }

        public static string GetName(this BodyPartType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString() ?? "";
        }
    }
}
