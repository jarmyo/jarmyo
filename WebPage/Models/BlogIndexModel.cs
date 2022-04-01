namespace Personal.Models
{
    public class BlogIndexModel
    {
        public BlogIndexModel() { }
        public List<Post> Entradas { get; set; }
        public List<Tag> Etiquetas { get; set; }
        public Dictionary<string,string> Archivo { get; set; }
        public bool DisableFoward { get; set; }
        public bool DisableBack { get; set; }
        public int CurrentPage { get; set; }
    }
}