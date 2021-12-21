using System.ComponentModel.DataAnnotations;

namespace Personal.Data
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat( ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Text)]
        public string Titulo { get; set; }
        [DataType(DataType.Text)]
        public string Contenido { get; set; }
        public string Etiquetas { get; set; } //descriptor
    }
}