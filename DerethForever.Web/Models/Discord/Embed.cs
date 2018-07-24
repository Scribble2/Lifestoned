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
using System.Net.Mime;
using System.Web;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Discord
{
    public class Embed
    {
        /// <summary>
        /// up to 256 characters
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = "rich";

        /// <summary>
        /// up to 2048 characters
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset? Timestamp { get; set; }

        [JsonProperty("color")]
        public int? Color { get; set; }

        [JsonProperty("footer")]
        public Footer Footer { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        public static Embed GetDefault(string username, DateTimeOffset? created, uint? weenieClassId = null)
        {
            Embed embed = new Embed();
            // embed.Author = new Author { Name = username };
            embed.Timestamp = created;
            if (weenieClassId != null && weenieClassId.Value > 0)
                embed.Thumbnail = new Image() { Url = $"http://www.lifestoned.org/Resource/GetFullyLayeredPngIcon?weenieClassId={weenieClassId}" };
            else
                embed.Thumbnail = new Image() { Url = "http://www.lifestoned.org/images/lifestone_192x192.png" };
            embed.Footer = new Footer { Text = $"Lifestoned WebHooks", IconUrl = "http://www.lifestoned.org/images/lifestone_192x192.png" };

            return embed;
        }
    }
}
