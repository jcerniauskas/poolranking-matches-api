using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using poolranking_matches_api.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace poolranking_matches_api.Data
{
    public class DataClient
    {
        private DocumentClient client;

        public DataClient()
        {
            this.client = new DocumentClient(new Uri(Constants.EndpointUri), Constants.PrimaryKey);

        }

        public async Task<Match> CreateMatchIfNotExists(Match match)
        {
            if (match.Id != null)
            {
                try
                {
                    var foundMatch = await this.client.ReadDocumentAsync(
                         UriFactory.CreateDocumentUri(Constants.databaseName, Constants.collectionName, match.Id));
                    return JsonConvert.DeserializeObject<Match>(foundMatch.Resource.ToString());
                }
                catch (DocumentClientException de)
                {
                    if (de.StatusCode == HttpStatusCode.NotFound)
                    {
                        var createdMatchWithId = await this.client.CreateDocumentAsync(
                              UriFactory.CreateDocumentCollectionUri(Constants.databaseName, Constants.collectionName), match);

                        return JsonConvert.DeserializeObject<Match>(createdMatchWithId.Resource.ToString());
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                var newMatch =
                    await this.client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(Constants.databaseName, Constants.collectionName), match);
                return JsonConvert.DeserializeObject<Match>(newMatch.Resource.ToString());
            }
        }

        public async Task<Match> GetMatch(string id)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = 1 };

            return await this.client.ReadDocumentAsync<Match>(
                    UriFactory.CreateDocumentUri(Constants.databaseName, Constants.collectionName, id));
        }

        public async Task<List<Match>> GetMatches()
        {
            Match match = new Match();
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IDocumentQuery<Match> query = client.CreateDocumentQuery<Match>(
                UriFactory.CreateDocumentCollectionUri(Constants.databaseName, Constants.collectionName),
                new FeedOptions { MaxItemCount = -1 })
                .AsDocumentQuery();
            List<Match> results = new List<Match>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Match>());
            }

            return results;
        }
    }
}
