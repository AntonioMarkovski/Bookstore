namespace Bookstore.Entities.Quotes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    public class QuotesDataMap
    {
        public List<Quote> Quotes { get; set; }
    }
}
