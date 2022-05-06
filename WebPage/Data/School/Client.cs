namespace Personal.Data
{
    public class Client
    {
        public Client() { }
        [Key]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string IdBusiness { get; set; }
    }
}