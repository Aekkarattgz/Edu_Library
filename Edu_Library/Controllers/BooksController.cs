using Edu_Library.Data;
using Microsoft.AspNetCore.Mvc;
using Edu_Library.Models;
using Microsoft.EntityFrameworkCore; // ใช้ Include() เพื่อดึงข้อมูลที่เกี่ยวข้อง
using System.Collections.Generic;
using System.Linq;

namespace Edu_Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context; // ตัวแปรสำหรับการเข้าถึงฐานข้อมูล
        public BooksController(ApplicationDbContext context)
        {
            _context = context; // กำหนดค่า context จาก DI Container
        }

        public IActionResult Index()
        {
            // ดึงข้อมูลจากตาราง Book_tb และข้อมูลจากตาราง Category_tb พร้อมกัน
            IEnumerable<Book_tb> books = _context.Book_tb
                .Include(b => b.Category) // ใช้ Include() เพื่อดึงข้อมูลหมวดหมู่ที่เกี่ยวข้องกับแต่ละหนังสือ
                .ToList(); // แปลงข้อมูลเป็น List

            return View(books); // ส่งข้อมูลที่ดึงได้ไปยัง View เพื่อแสดงผล
        }
    }
}
