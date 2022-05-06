namespace Personal.Data
{
    public class Business
    {
        public Business() { }
        [Key]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(10)]
        public string Shorturl { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string SaltPassword { get; set; }
    }
}