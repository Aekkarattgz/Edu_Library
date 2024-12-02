using System.ComponentModel.DataAnnotations; // นำเข้า namespace สำหรับการใช้ Data Annotations
using System.ComponentModel.DataAnnotations.Schema; // นำเข้า namespace สำหรับการใช้การกำหนดตารางและคอลัมน์ในฐานข้อมูล

namespace Edu_Library.Models
{
    // คลาสนี้คือโมเดลที่ใช้แสดงตาราง Book_tb ในฐานข้อมูล
    public class Book_tb
    {
        // กำหนดให้ BookId เป็นคีย์หลัก (Primary Key) ของตาราง Book_tb
        [Key]
        public int BookId { get; set; } // ตัวแปรนี้เก็บ ID ของหนังสือ

        // ตัวแปรนี้เก็บชื่อของหนังสือ
        public string Name { get; set; }

        // ตัวแปรนี้เก็บรายละเอียดของหนังสือ
        public string Detail { get; set; }

        // ตัวแปรนี้เก็บชื่อของผู้เขียนหนังสือ
        public string Author { get; set; }

        // ตัวแปรนี้เก็บ URL หรือที่อยู่ของรูปภาพปกหนังสือ
        public string CoverImage { get; set; }

        // กำหนดว่า CategoryId เป็น Foreign Key ที่เชื่อมโยงไปยังตาราง Category_tb
        public int CategoryId { get; set; }

        // Navigation Property: เชื่อมโยง Book_tb กับ Category_tb โดยใช้ CategoryId เป็น Foreign Key
        public Category_tb Category { get; set; }
    }
}
