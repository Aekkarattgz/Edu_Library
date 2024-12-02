using System.ComponentModel.DataAnnotations; // นำเข้า namespace สำหรับการใช้ Data Annotations

namespace Edu_Library.Models
{
    // คลาสนี้คือโมเดลที่ใช้แสดงตาราง Category_tb ในฐานข้อมูล
    public class Category_tb
    {
        // Navigation Property: ตัวแปรนี้ใช้เพื่อเชื่อมโยงกับคอลเลกชันของหนังสือที่เกี่ยวข้องกับหมวดหมู่นี้
        public ICollection<Book_tb> Books { get; set; }

        // กำหนดให้ CategoryId เป็นคีย์หลัก (Primary Key) ของตาราง Category_tb
        [Key]
        public int CategoryId { get; set; } // ตัวแปรนี้เก็บ ID ของหมวดหมู่

        // ตัวแปรนี้เก็บชื่อของหมวดหมู่
        public string Name { get; set; }
    }
}
