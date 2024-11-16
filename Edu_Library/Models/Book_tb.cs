using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edu_Library.Models
{
    public class Book_tb
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public Category_tb Category { get; set; }
    }
}
