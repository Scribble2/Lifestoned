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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DerethForever.Web.Models.Enums;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Account
{
	[Table("subscription")]
    public class SubscriptionModel
    {
		[Column("accountGuid")]
        [JsonProperty("accountGuid")]
        public Guid AccountGuid { get; set; }
        
		[Key]
		[Column("subscriptionId")]
        [JsonProperty("subscriptionId")]
        public uint SubscriptionId { get; set; }

		[Column("subscriptionGuid")]
        [JsonProperty("subscriptionGuid")]
        public Guid SubscriptionGuid { get; set; }
        
		[Column("accessLevel")]
        [JsonProperty("accessLevel")]
        public ulong AccessLevel { get; set; }

        [JsonIgnore]
        public AccessLevel? AccessLevel_Binder
        {
            get { return (AccessLevel?)AccessLevel; }
            set { AccessLevel = (ulong)value; }
        }

        [JsonIgnore]
        public AccessLevel? NewAccessLevel { get; set; }

		[Column("subscriptionName")]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
