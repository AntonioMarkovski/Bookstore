namespace Bookstore.Entities.Quotes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    public class QuotesData
    {
        [JsonPropertyName("quotes")]
        public List<Quote> Quotes { get; set; }
    }
}
