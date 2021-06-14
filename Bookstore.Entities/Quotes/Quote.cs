namespace Bookstore.Entities.Quotes
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Quote
    {
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        //[JsonIgnore]
        public string quote { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

    }
}