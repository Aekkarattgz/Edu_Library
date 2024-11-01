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
        public IActionResult Register(string username, string email, string password, string cpassword)
        {

            // ตรวจสอบว่ารหัสผ่านทั้งสองตรงกันหรือไม่
            if (password != cpassword)
            {
                ModelState.AddModelError("Cpassword", "Passwords do not match."); // ระบุชื่อฟิลด์ที่มีข้อผิดพลาด
            }

            // ตรวจสอบ ModelState ว่ามีข้อผิดพลาดหรือไม่
            if (!ModelState.IsValid)
            {
                return View(); // ส่งคืน View หากมีข้อผิดพลาด
            }

            // เพิ่มการสร้างบัญชีผู้ใช้ที่นี่

            // ถ้าทุกอย่างถูกต้อง ให้เปลี่ยนเส้นทางไปยังหน้าที่ต้องการ
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
