namespace Personal.Data
{
    public class Visitante : ITabla
    {
        [Key]
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}