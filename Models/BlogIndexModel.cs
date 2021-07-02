using Personal.Data;
using System.Collections.Generic;

namespace Personal.Models
{
    public class BlogIndexModel
    {
        public BlogIndexModel()
        {
        }

        public List<Post> Entradas { get; set; }
    }
}