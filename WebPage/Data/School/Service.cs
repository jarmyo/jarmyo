namespace Personal.Data
{
    public class Service
    {
        public Service() { }
        [Key]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string IdBusiness { get; set; }
    }
}