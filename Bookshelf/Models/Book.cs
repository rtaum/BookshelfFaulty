using Newtonsoft.Json;

namespace Bookshelf.Models
{
    public class Book
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
