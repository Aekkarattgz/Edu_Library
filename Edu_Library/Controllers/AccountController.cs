using Microsoft.AspNetCore.Mvc;

namespace Edu_Library.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, bool rememberMe)
        {
            // ตรวจสอบข้อมูลที่ผู้ใช้กรอก
            if (username == "admin" && password == "password") // แค่ตัวอย่างสำหรับการตรวจสอบ
            {
                // ถ้าข้อมูลถูกต้อง เปลี่ยนเส้นทางไปยังหน้าหลัก
                return RedirectToAction("Index", "Home");
            }

            // หากข้อมูลไม่ถูกต้อง แสดงข้อความข้อผิดพลาด
            ViewData["Error"] = "Invalid username or password.";
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
