using System.ComponentModel.DataAnnotations;

namespace Personal.Data
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }
    }
}