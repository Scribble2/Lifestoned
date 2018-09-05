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
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.DF
{
    public class CreationProfile
    {
        /// <summary>
        /// Table field Primary Key
        /// </summary>
        [JsonProperty("creationProfileGuid")]
        public Guid? CreationProfileGuid { get; set; }

        /// <summary>
        /// owning weenie id
        /// </summary>
        [JsonProperty("ownerId")]
        public uint? OwnerId { get; set; }

        /// <summary>
        /// Table Field Weenie Class
        /// </summary>
        [JsonProperty("weenieClassId")]
        public uint? WeenieClassId { get; set; }

        /// <summary>
        /// Table Field Palette
        /// </summary>
        [JsonProperty("palette")]
        public uint? Palette { get; set; }

        /// <summary>
        /// Table Field Shade - used as an offset percentage into palette (? check with Iron Golem)
        /// </summary>
        [JsonProperty("shade")]
        public double? Shade { get; set; }

        /// <summary>
        /// Table Field Destination - where are we creating the object.
        /// </summary>
        [JsonProperty("destination")]
        public uint? Destination { get; set; }

        [JsonIgnore]
        public Destination? Destination_Binder
        {
            get { return (Destination?)Destination; }
            set { Destination = (uint?)value; }
        }

        /// <summary>
        /// Table Field StackSize - how many are we creating of stackable items.   Not all items have this property.
        /// </summary>
        [JsonProperty("stackSize")]
        public int? StackSize { get; set; }

        /// <summary>
        /// Table Field TryToBond - flag for the item that we create to be bonded.
        /// </summary>
        [JsonProperty("bond")]
        public bool? TryToBond { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
