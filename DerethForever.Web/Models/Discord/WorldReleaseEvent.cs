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
using System.Web;

namespace DerethForever.Web.Models.Discord
{
    public class WorldReleaseEvent : IDiscordMessage
    {
        public string User { get; set; }

        public DateTimeOffset ReleaseTime { get; set; }
        
        public string Name { get; set; }

        public string Size { get; set; }

        public Message GetDiscordMessage()
        {
            Embed embed = Embed.GetDefault(User, ReleaseTime);

            embed.Title = $"A new World Release was created by {User}";
            embed.Description = $"{Name} ({Size}) is now available for download.";

            embed.Fields = new List<Field>();

            // http://localhost:62809/WorldRelease/Get?fileName=DF-World-2018.03.30-16.21.16.zip
            string downloadUrl = $"http://www.lifestoned.org/WorldRelease/Get?fileName={Name}";

            string links = "";
            links += $"[Download Release]({downloadUrl})";
            links += $" | [Lifestoned](http://www.lifestoned.org)";

            embed.Fields.Add(new Field { Name = "Links", Value = links });

            return new Message(embed);
        }
    }
}
