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
        public async Task AddItemsToContainerAsync(CosmoItem andersenFamily)
        {
            try
            {
                ItemResponse<CosmoItem> andersenFamilyResponse = await container.ReadItemAsync<CosmoItem>(andersenFamily.Id, new PartitionKey(andersenFamily.PartitionKey));
                Console.WriteLine("Item in database with id: {0} already exists\n", andersenFamilyResponse.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ItemResponse<CosmoItem> andersenFamilyResponse = await container.CreateItemAsync(andersenFamily, new PartitionKey(andersenFamily.PartitionKey));
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", andersenFamilyResponse.Resource.Id, andersenFamilyResponse.RequestCharge);
            }
        }
        public async Task QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.PartitionKey = 'Andersen'";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new(sqlQueryText);
            FeedIterator<CosmoItem> queryResultSetIterator = container.GetItemQueryIterator<CosmoItem>(queryDefinition);

            List<CosmoItem> families = [];

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
            wakefieldFamilyResponse = await container.ReplaceItemAsync(itemBody, itemBody.Id, new PartitionKey(itemBody.PartitionKey));
            Console.WriteLine("Updated Item [{0},{1}].\n \tBody is now: {2}\n", itemBody.Name, itemBody.Id, wakefieldFamilyResponse.Resource);
        }
        public async Task DeleteFamilyItemAsync(string partitionKeyValue, string ItemId)
        {
            _ = await container.DeleteItemAsync<CosmoItem>(ItemId, new PartitionKey(partitionKeyValue));
            Console.WriteLine("Deleted Item [{0},{1}]\n", partitionKeyValue, ItemId);
        }
    }
}