using System.ComponentModel.DataAnnotations;

namespace Edu_Library.Models
{
    public class Category_tb
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
