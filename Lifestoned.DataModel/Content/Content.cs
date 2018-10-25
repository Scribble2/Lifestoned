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
using Lifestoned.DataModel.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lifestoned.DataModel.Content
{
    /// <summary>
    /// this is a dual purpose class for interacting with the Api as well as serving 
    /// as a model for this web ui
    /// </summary>
    public class Content : BaseModel
    {
        /// <summary>
        /// content identifier.
        /// </summary>
        [JsonProperty("contentGuid")]
        public Guid? ContentGuid { get; set; }
        
        /// <summary>
        /// user-defined name for the content that is searchable
        /// </summary>
        [Display(Name = "Name")]
        [JsonProperty("contentName")]
        public string ContentName { get; set; }

        /// <summary>
        /// logical grouping for what type of content this is
        /// </summary>
        [Display(Name = "Type")]
        [JsonProperty("contentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ContentType ContentType { get; set; }
        
        /// <summary>
        /// list of landblock upper words (ie, landblock x/y) containing dungeons associated with this quest.  please note, other content
        /// may be associated with them as well
        /// </summary>
        [JsonProperty("associatedLandblocks")]
        public List<ContentLandblock> AssociatedLandblocks { get; set; } = new List<ContentLandblock>();

        /// <summary>
        /// list of weenies that are associated with this content.  NPCs, items turned in, found, or otherwise
        /// involved in this quest.  could also be traps, levers, or other static objects in the dungeon.
        /// also includes spawn generators associated with the quests.
        /// </summary>
        [JsonProperty("weenies")]
        public List<ContentWeenie> Weenies { get; set; } = new List<ContentWeenie>();

        /// <summary>
        /// list of URLs linking the content in other places (acpedia, asheron.wikia, etc)
        /// </summary>
        [JsonProperty("externalResources")]
        public List<ContentResource> ExternalResources { get; set; } = new List<ContentResource>();

        /// <summary>
        /// list of associated content
        /// </summary>
        [JsonProperty("associatedContent")]
        public List<ContentLink> AssociatedContent { get; set; } = new List<ContentLink>();

        [JsonProperty("lastModified")]
        [Display(Name = "Last Modified Date")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        [Display(Name = "Last Modified By")]
        public string ModifiedBy { get; set; }
    }
}
