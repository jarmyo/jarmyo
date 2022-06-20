namespace SecretDrawer.Data
{
    public class Secret
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Hash { get; set; }
        public string? Color { get; set; }
        public int Order { get; set; }
        public int? IdCategory { get; set; }        
    }
}