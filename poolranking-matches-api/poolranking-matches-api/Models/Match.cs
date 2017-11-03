using Newtonsoft.Json;

namespace poolranking_matches_api.Models
{
    public class Match
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string WinnerId { get; set; }
        public string LoserId { get; set; }
        public string Score { get; set; }
    }
}
