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
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;
        private readonly string databaseId = "JulianAugusto.com";
        private readonly string containerId = "Items";
        public async Task AddItemsToContainerAsync(CosmoItem andersenFamily)
        {
            try
            {
                ItemResponse<CosmoItem> andersenFamilyResponse = await container.ReadItemAsync<CosmoItem>(andersenFamily.id, new PartitionKey(andersenFamily.partitionKey));
                Console.WriteLine("Item in database with id: {0} already exists\n", andersenFamilyResponse.Resource.id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ItemResponse<CosmoItem> andersenFamilyResponse = await container.CreateItemAsync(andersenFamily, new PartitionKey(andersenFamily.partitionKey));
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", andersenFamilyResponse.Resource.id, andersenFamilyResponse.RequestCharge);
            }
        }
        public async Task QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.PartitionKey = 'Andersen'";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new(sqlQueryText);
            FeedIterator<CosmoItem> queryResultSetIterator = container.GetItemQueryIterator<CosmoItem>(queryDefinition);

            List<CosmoItem> families = new();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<CosmoItem> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (CosmoItem family in currentResultSet)
                {
                    families.Add(family);
                    Console.WriteLine("\tRead {0}\n", family);
                }
            }
        }
        public async Task ReplaceFamilyItemAsync(string partitionKeyValue, string itemID)
        {
            ItemResponse<CosmoItem> wakefieldFamilyResponse = await container.ReadItemAsync<CosmoItem>(itemID, new PartitionKey(partitionKeyValue));
            var itemBody = wakefieldFamilyResponse.Resource;
            itemBody.IsRegistered = true;
            wakefieldFamilyResponse = await container.ReplaceItemAsync(itemBody, itemBody.id, new PartitionKey(itemBody.partitionKey));
            Console.WriteLine("Updated Item [{0},{1}].\n \tBody is now: {2}\n", itemBody.Name, itemBody.id, wakefieldFamilyResponse.Resource);
        }
        public async Task DeleteFamilyItemAsync(string partitionKeyValue, string ItemId)
        {
            ItemResponse<CosmoItem> wakefieldFamilyResponse = await container.DeleteItemAsync<CosmoItem>(ItemId, new PartitionKey(partitionKeyValue));
            Console.WriteLine("Deleted Item [{0},{1}]\n", partitionKeyValue, ItemId);
        }
    }
}