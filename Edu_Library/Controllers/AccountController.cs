using Microsoft.AspNetCore.Authentication; // นำเข้า namespace สำหรับการใช้ Authentication
using Microsoft.AspNetCore.Authentication.Cookies; // นำเข้า namespace สำหรับใช้ Cookie-based Authentication
using Microsoft.AspNetCore.Mvc; // นำเข้า namespace สำหรับการทำงานกับ MVC
using System.Security.Claims; // นำเข้า namespace สำหรับการสร้าง Claims เพื่อใช้ในการ Authentication
using Edu_Library.Data; // นำเข้า namespace สำหรับการเข้าถึงฐานข้อมูล
using Edu_Library.Models; // นำเข้า namespace สำหรับใช้โมเดล User_tb

namespace Edu_Library.Controllers
{
    // คลาสนี้จัดการการทำงานที่เกี่ยวข้องกับการลงชื่อเข้าใช้ (Login) และการสมัครสมาชิก (Register)
    public class AccountController : Controller
    {
        // ตัวแปร _context ใช้สำหรับการเข้าถึงฐานข้อมูลผ่าน ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Constructor สำหรับการ Inject ApplicationDbContext จาก DI Container
        public AccountController(ApplicationDbContext context)
        {
            _context = context; // กำหนดค่า _context จาก DI
        }

        // Action Method ที่แสดงฟอร์ม Login (HTTP GET)
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                // ถ้าผู้ใช้ล็อกอินอยู่แล้ว ให้รีไดเรกต์ไปที่หน้า dashboard หรือหน้าอื่น
                return RedirectToAction("Index", "Home");
            }

            return View(); // แสดงหน้า Login
        }

        // Action Method ที่รับข้อมูลจากฟอร์ม Login (HTTP POST)
        [HttpPost]
        public async Task<IActionResult> Login(string UsernameOrEmail, string Password, bool RememberMe)
        {
            // ค้นหาผู้ใช้จากฐานข้อมูลที่มีชื่อผู้ใช้หรืออีเมลตรงกับข้อมูลที่กรอก และรหัสผ่านตรงกับที่กรอก
            var user = _context.User_tb
                .FirstOrDefault(u => (u.UserName == UsernameOrEmail || u.Email == UsernameOrEmail) && u.Password == Password);

            // ถ้าหาผู้ใช้ไม่พบ
            if (user == null)
            {
                ViewBag.ErrorMessage = "ชื่อผู้ใช้หรืออีเมล หรือรหัสผ่านไม่ถูกต้อง"; // แสดงข้อความผิดพลาด
                return View(); // ส่งกลับไปที่หน้าฟอร์ม Login
            }

            // สร้าง Claims สำหรับการยืนยันตัวตน
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName), // กำหนด Claim สำหรับชื่อผู้ใช้
                new Claim(ClaimTypes.Email, user.Email), // กำหนด Claim สำหรับอีเมล
            };

            // สร้าง ClaimsIdentity ด้วย Authentication Scheme แบบ Cookies
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // สร้าง ClaimsPrincipal จาก ClaimsIdentity
            var principal = new ClaimsPrincipal(identity);

            // ลงชื่อเข้าใช้ (Sign In) โดยใช้ Cookie Authentication Scheme
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // ตรวจสอบ Role ของผู้ใช้และรีไดเรกต์ไปยังหน้าต่างๆ
            if (user.Role == "Admin")
            {
                // หากเป็น Admin ให้ไปที่หน้า Admin Dashboard
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                // หากเป็น User ให้ไปที่หน้า Books (หรือหน้าที่ผู้ใช้สามารถเข้าถึงได้)
                return RedirectToAction("Index", "Books");
            }
        }


        // Action Method ที่แสดงฟอร์มสมัครสมาชิก (HTTP GET)
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // แสดงฟอร์มสมัครสมาชิก
        }

        // Action Method ที่รับข้อมูลจากฟอร์มสมัครสมาชิก (HTTP POST)
        [HttpPost]
        public IActionResult Register(string Username, string Email, string Password, string cpassword)
        {
            // ตรวจสอบว่า รหัสผ่านที่กรอกสองครั้งตรงกันหรือไม่
            if (Password != cpassword)
            {
                ModelState.AddModelError("Cpassword", "Passwords do not match."); // ถ้าไม่ตรงให้แสดงข้อความผิดพลาด
                return View(); // ส่งกลับไปที่หน้าฟอร์มสมัครสมาชิก
            }

            // ตรวจสอบว่ามีผู้ใช้หรืออีเมลนี้ในระบบแล้วหรือไม่
            if (_context.User_tb.Any(u => u.UserName == Username || u.Email == Email))
            {
                ModelState.AddModelError("DuplicateUser", "Username or Email already exists."); // ถ้ามีให้แสดงข้อความผิดพลาด
                return View();
            }

            try
            {
                // สร้างผู้ใช้ใหม่
                var newUser = new User_tb
                {
                    UserName = Username, // กำหนดชื่อผู้ใช้
                    Email = Email,       // กำหนดอีเมล
                    Password = Password, // เก็บรหัสผ่าน (ควรเก็บแบบเข้ารหัสในโปรดักชัน)
                    Role = "User"        // กำหนดบทบาทผู้ใช้เป็น User
                };

                _context.User_tb.Add(newUser); // เพิ่มผู้ใช้ใหม่ในฐานข้อมูล
                _context.SaveChanges(); // บันทึกการเปลี่ยนแปลงในฐานข้อมูล

                // เปลี่ยนเส้นทางไปที่หน้า Login หลังจากสมัครสมาชิกสำเร็จ
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                // ถ้ามีข้อผิดพลาดในการสมัครสมาชิก ให้แสดงข้อความผิดพลาด
                ViewBag.ErrorMessage = ex.InnerException?.Message ?? ex.Message;
                return View();
            }
        }

        // Action Method สำหรับหน้า Access Denied (กรณีที่ผู้ใช้ไม่มีสิทธิ์เข้าถึงบางส่วนของเว็บ)
        public IActionResult AccessDenied()
        {
            return View(); // แสดงหน้า Access Denied
        }

        // Action Method สำหรับการออกจากระบบ (Logout)

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // ลบข้อมูลการยืนยันตัวตน
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // ลบ Cookie Authentication
            Response.Cookies.Delete(".AspNetCore.Cookies");

            // Set cache control headers to prevent the browser from caching the page
            Response.Headers["Cache-Control"] = "no-store";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            // รีไดเรกต์ไปที่หน้า Login
            return RedirectToAction("Login", "Account");
        }

      }
}
