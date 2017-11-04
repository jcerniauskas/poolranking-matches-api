using Microsoft.AspNetCore.Mvc;
using poolranking_matches_api.Data;
using poolranking_matches_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poolranking_matches_api.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly DataClient dataClient;

        public MatchesController(DataClient dataClient)
        {
            this.dataClient = dataClient;
        }

        // GET api/matches
        [HttpGet]
        public async Task<IEnumerable<Match>> Get()
        {
            return await dataClient.GetMatches();
        }

        // GET api/matches/5
        [HttpGet("{id}")]
        public async Task<Match> Get(string id)
        {
            return await dataClient.GetMatch(id);
        }

        // GET api/matches/allplayermatches/5
        [HttpGet("allplayermatches/{id}")]
        public async Task<IEnumerable<Match>> Get(string id, string fakeStr)
        {
            return await dataClient.GetMatchesByPlayerId(id);
        }

        // POST api/matches
        [HttpPost]
        public async Task<Match> Post([FromBody]Match match)
        {
            return await dataClient.CreateMatchIfNotExists(match);
        }
    }
}
