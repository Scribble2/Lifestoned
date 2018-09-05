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
using System.Collections.Generic;
using DerethForever.Web.Models.Enums;

namespace DerethForever.Web.Models.PreComp
{
    public class PreCompWeenie
    {
        public string Label { get; set; }

        public uint Timestamp { get; set; }

        public uint WeenieType { get; set; }

        public uint WCID { get; set; }

        public Dictionary<string, int> IntValues { get; set; }

        public Dictionary<string, long> LongValues { get; set; }

        public Dictionary<string, bool> BoolValues { get; set; }

        public Dictionary<string, double> DoubleValues { get; set; }

        public Dictionary<string, string> StringValues { get; set; }

        public Dictionary<string, uint> DIDValues { get; set; }

        public Dictionary<string, float> SpellCastingProbability { get; set; }

        public uint[] EventFilters { get; set; }

        public Dictionary<string, Position> PositionValues { get; set; }

        public AttributeSet Attributes { get; set; }

        public Dictionary<string, BodyPart> BodyParts { get; set; }

        public Dictionary<string, List<Emote>> Emotes { get; set; }

        public List<CreateItem> CreateList { get; set; }

        public List<Generator> Generators { get; set; }

        public Extra1 Extra1 { get; set; }

        public List<ExtraItem3> Extra2Items { get; set; }

        public List<ExtraItem2> Extra3Items { get; set; }

        //public Weenie.Weenie Convert(out List<string> warnings)
        //{
            //warnings = new List<string>();
            //Weenie.Weenie w = new Weenie.Weenie();
            //w.DataObjectId = WCID;
            //w.WeenieClassId = WCID;

            //w.IntProperties.Add(new Shared.IntProperty() { IntPropertyId = (int)IntPropertyId.WeenieType, Value = (int)WeenieType });

            //foreach (var kvp in IntValues)
            //    w.IntProperties.Add(new Shared.IntProperty() { IntPropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //foreach (var kvp in LongValues)
            //    w.Int64Properties.Add(new Shared.Int64Property() { Int64PropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //foreach (var kvp in BoolValues)
            //    w.BoolProperties.Add(new Shared.BoolProperty() { BoolPropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //foreach (var kvp in DoubleValues)
            //    w.DoubleProperties.Add(new Shared.DoubleProperty() { DoublePropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //foreach (var kvp in StringValues)
            //    w.StringProperties.Add(new Shared.StringProperty() { StringPropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //foreach (var kvp in DIDValues)
            //    w.DidProperties.Add(new Shared.DataIdProperty() { DataIdPropertyId = int.Parse(kvp.Key), Value = kvp.Value });

            //if (Extra1 != null)
            //    warnings.Add("GDLWeenie contained 'Extra1' data - this data will be lost.");

            //if (Extra1 != null)
            //    warnings.Add("GDLWeenie contained 'Extra2Items' data - this data will be lost.");

            //if (Extra1 != null)
            //    warnings.Add("GDLWeenie contained 'Extra3Items' data - this data will be lost.");
        //    warnings = null;

        //    return null;
        //}
    }
}
