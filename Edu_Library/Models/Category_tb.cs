namespace Edu_Library.Models
{
    public class Category_tb
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; } // รายการหนังสือที่อยู่ในหมวดหมู่นี้
    }
}
