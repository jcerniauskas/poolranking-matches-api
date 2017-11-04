using Microsoft.AspNetCore.Mvc;
using poolranking_matches_api.Data;
using poolranking_matches_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poolranking_matches_api.Controllers
{
    [Route("api/[controller]")]
    public class Matches : Controller
    {
        private readonly DataClient dataClient;

        public Matches() {
            dataClient = new DataClient(); 
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Match>> Get()
        {
            return await dataClient.GetMatches();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Match> Get(string id)
        {
            return await dataClient.GetMatch(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<Match> Post([FromBody]Match match)
        {
            return await dataClient.CreateMatchIfNotExists(match);
        }
    }
}
