using Microsoft.Azure.Cosmos;
using System.Net;
namespace Personal.Helpers
{
    public class CosmosDBHelper
    {
        public CosmosDBHelper()
        {
            try
            {
                cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "JulianAugusto.com" });
                database = cosmosClient.GetDatabase(databaseId);
                container = database.GetContainer(containerId);
            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }
        public static string PrimaryKey { get; set; }
        public static string EndpointUri { get; set; }
        private readonly CosmosClient cosmosClient;
        private readonly Database database;
        private readonly Container container;
        private readonly string databaseId = "JulianAugusto.com";
        private readonly string containerId = "Items";
    }
}