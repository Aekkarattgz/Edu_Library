using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Edu_Library.Controllers
{
    public class AccountController : Controller
    {
        // แสดงฟอร์มหน้า Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // รับข้อมูลจากฟอร์ม Login เมื่อผู้ใช้ส่งข้อมูล (HTTP POST)
        [HttpPost]
        public IActionResult Login(string Username, string Password, bool RememberMe)
        {
            // ตรวจสอบข้อมูลที่ผู้ใช้กรอก (เพียงตัวอย่างการตรวจสอบข้อมูลแบบฮาร์ดโค้ด)
            if (Username == "admin" && Password == "password") // ใช้แค่เพื่อการทดสอบ
            {
                // หากข้อมูลถูกต้อง ให้เปลี่ยนเส้นทางไปยังหน้าหลัก
                return RedirectToAction("Index", "Books");
            }

            // หากข้อมูลไม่ถูกต้อง เพิ่มข้อความข้อผิดพลาดลงใน ModelState
            ModelState.AddModelError("admin & password", "Invalid username or password.");

            // ส่ง View กลับพร้อมแสดงข้อผิดพลาด
            return View();
        }

        // แสดงฟอร์มหน้า Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // รับข้อมูลจากฟอร์ม Register เมื่อผู้ใช้ส่งข้อมูล (HTTP POST)
        [HttpPost]
        public IActionResult Register(string Username, string Email, string Passeord, string cpassword)
        {
            // ตรวจสอบว่ารหัสผ่านทั้งสองช่องตรงกันหรือไม่
            if (Passeord != cpassword)
            {
                // เพิ่มข้อความข้อผิดพลาดลงใน ModelState หากรหัสผ่านไม่ตรงกัน
                ModelState.AddModelError("Cpassword", "Passwords do not match.");
                return View();
            }

            // สามารถเพิ่มขั้นตอนการสร้างบัญชีผู้ใช้ที่นี่ (การเชื่อมต่อฐานข้อมูลหรือการบันทึกข้อมูล)

            // หากข้อมูลผ่านการตรวจสอบ ให้เปลี่ยนเส้นทางไปยังหน้าหลัก
            return RedirectToAction("Index", "Books");
        }

        // แสดงหน้า Access Denied (ในกรณีที่ผู้ใช้ไม่มีสิทธิ์เข้าถึงบางส่วนของเว็บ)
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
            //Task เป็นชนิดข้อมูลที่ใช้รองรับการทำงานแบบ asynchronous ซึ่งจะส่งคืนผลลัพธ์ในอนาคตเมื่อเมธอดทำงานเสร็จ
        {
            // ลบข้อมูลการยืนยันตัวตน (เช่น การออกจากระบบ)
            await HttpContext.SignOutAsync();

            // เปลี่ยนเส้นทางไปที่หน้าล็อกอินหลังจากออกจากระบบ
            return RedirectToAction("Login", "Account");
        }
    }
}
