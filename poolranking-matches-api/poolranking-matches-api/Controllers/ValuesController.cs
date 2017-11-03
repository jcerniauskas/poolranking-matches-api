using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using poolranking_matches_api.Data;
using poolranking_matches_api.Models;

namespace poolranking_matches_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly DataClient dataClient;

        public ValuesController() {
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
