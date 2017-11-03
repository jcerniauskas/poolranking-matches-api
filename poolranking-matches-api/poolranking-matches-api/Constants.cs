using System;

namespace poolranking_matches_api
{
    public static class Constants
    {
        public static string EndpointUri
        {
            get { return Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT"); }
        }
        public static string PrimaryKey
        {
            get { return Environment.GetEnvironmentVariable("COSMOSDB_KEY"); }
        }
        public const string databaseName = "Rankings";
        public const string collectionName = "Match";
    }

}
