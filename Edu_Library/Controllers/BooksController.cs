using Edu_Library.Data;
using Microsoft.AspNetCore.Mvc;
using Edu_Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Edu_Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            // ดึงข้อมูลจากตาราง Book_tb ทั้งหมด
            IEnumerable<Book_tb> books = _context.Book_tb.ToList();
            return View(books);
        }
    }
}
