using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DerethForever.Web.Models.Shared
{
    public class Book
    {
        [JsonProperty("maxNumCharsPerPage")]
        public int MaxCharactersPerPage { get; set; }

        [JsonProperty("maxNumPages")]
        public int MaxNumberPages { get; set; }

        [JsonProperty("pages")]
        public List<BookPage> Pages { get; set; } = new List<BookPage>();
    }
}