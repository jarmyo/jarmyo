using System;
using System.ComponentModel.DataAnnotations;

namespace Personal.Data
{
    public class Post
    {           
        [Key]
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Etiquetas{ get; set; }
    }
}
