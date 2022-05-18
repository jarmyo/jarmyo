using System.Text.Json;
namespace Personal.Data
{
    public class CosmoItem
    {
        public string id { get; set; }
        public string partitionKey { get; set; }
        public string Name { get; set; }
        public bool IsRegistered { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}