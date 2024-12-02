using System.ComponentModel.DataAnnotations; // นำเข้า namespace สำหรับการใช้ Data Annotations
using System.ComponentModel.DataAnnotations.Schema; // นำเข้า namespace สำหรับการใช้การกำหนดตารางและคอลัมน์ในฐานข้อมูล

namespace Edu_Library.Models
{
    // คลาสนี้คือโมเดลที่ใช้แสดงตาราง User_tb ในฐานข้อมูล
    public class User_tb
    {
        // กำหนดว่า UserId เป็นคีย์หลัก (Primary Key)
        [Key]

        // กำหนดให้ UserId เป็น Identity ซึ่งหมายความว่า SQL Server จะเพิ่มค่า UserId ให้โดยอัตโนมัติ
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // ตัวแปรนี้จะเก็บเลข 6 หลักที่เป็น ID ของผู้ใช้งาน

        // ตัวแปรนี้เก็บชื่อผู้ใช้
        public string UserName { get; set; }

        // ตัวแปรนี้เก็บอีเมลของผู้ใช้
        public string Email { get; set; }

        // ตัวแปรนี้เก็บรหัสผ่านของผู้ใช้
        public string Password { get; set; }

        // ตัวแปรนี้เก็บบทบาทของผู้ใช้ (เช่น Admin, User)
        public string Role { get; set; }
    }
}
