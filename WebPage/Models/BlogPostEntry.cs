﻿namespace Personal.Models
{
    public class BlogPostEntry
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Fecha { get; set; }
        public string Etiquetas { get; set; }
        public string Contenido { get; set; }
        public bool IsUpdate { get; set; }
    }
}
