using Edu_Library.Data; // นำเข้า namespace สำหรับการเข้าถึง ApplicationDbContext
using Microsoft.AspNetCore.Mvc; // นำเข้า namespace สำหรับการใช้ Controller และ IActionResult
using Edu_Library.Models; // นำเข้า namespace สำหรับการใช้โมเดล Book_tb และ Category_tb
using Microsoft.EntityFrameworkCore; // ใช้ Include() เพื่อดึงข้อมูลที่เกี่ยวข้องระหว่างตาราง

namespace Edu_Library.Controllers
{
    // ควบคุมการทำงานที่เกี่ยวข้องกับการแสดงผลข้อมูลหนังสือในระบบ
    public class BooksController : Controller
    {
        // ตัวแปร _context ใช้สำหรับการเข้าถึงฐานข้อมูลผ่าน ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Constructor ที่รับพารามิเตอร์ context จาก Dependency Injection (DI Container)
        public BooksController(ApplicationDbContext context)
        {
            _context = context; // กำหนดค่า _context โดยใช้ค่าที่ได้รับจาก DI
        }

        // Action Method สำหรับแสดงรายการหนังสือทั้งหมด
        public IActionResult Index()
        {
            // ดึงข้อมูลจากตาราง Book_tb พร้อมกับข้อมูลหมวดหมู่ (Category_tb) ที่เกี่ยวข้อง
            // ใช้ Include() เพื่อดึงข้อมูลของหมวดหมู่ที่เชื่อมโยงกับแต่ละหนังสือ
            IEnumerable<Book_tb> books = _context.Book_tb
                .Include(b => b.Category) // ดึงข้อมูลหมวดหมู่ของหนังสือแต่ละเล่ม
                .ToList(); // แปลงผลลัพธ์เป็น List

            // ส่งข้อมูลที่ได้ไปยัง View เพื่อแสดงผล
            return View(books); // ส่งรายการหนังสือทั้งหมดไปยัง View
        }
    }
}
