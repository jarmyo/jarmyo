using System.Text.Json;
using System.Text.Json.Serialization;

namespace Personal.Data
{
    public class Family
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("partitionKey")]
        public string PartitionKey { get; set; }
        public string LastName { get; set; }
        public Parent[] Parents { get; set; }
        public Child[] Children { get; set; }
        public Address Address { get; set; }
        public bool IsRegistered { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}