using Newtonsoft.Json;

namespace WCF_Service
{
    public class Value
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("joke")]
        public string Joke { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }
    }


    public class Joke
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public Value[] Value { get; set; }
    }
}