using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
