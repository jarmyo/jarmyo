namespace SecretDrawer.Data
{
    public class Category
    {
        public Category()
        {
            Id = System.Guid.NewGuid().ToString().ToLower();
        }
        [Key]
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int Order { get; set; }
    }
}