using System.ComponentModel.DataAnnotations;

namespace Edu_Library.Models
{
    public class Category_tb
    {
        // Navigation Property
        public ICollection<Book_tb> Books { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
