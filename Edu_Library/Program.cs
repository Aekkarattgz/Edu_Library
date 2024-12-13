using Edu_Library.Data; // นำเข้า Namespace ของโปรเจ็กต์ที่มีการจัดการฐานข้อมูล (DbContext)
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore; // นำเข้า Namespace สำหรับการใช้งาน Entity Framework Core
using Microsoft.Extensions.Options; // นำเข้า Namespace สำหรับการตั้งค่าต่างๆ ในโปรเจ็กต์

var builder = WebApplication.CreateBuilder(args); // สร้างตัวสร้าง (Builder) สำหรับ Web Application

// Add services to the container.
// เพิ่มบริการ (Services) ที่ใช้ในแอปพลิเคชัน

builder.Services.AddControllersWithViews();
// เพิ่มบริการสำหรับการใช้ Controller และ View (MVC)

// เพิ่มบริการ DbContext สำหรับการเชื่อมต่อฐานข้อมูล
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// กำหนด DbContext (`ApplicationDbContext`) ให้เชื่อมต่อฐานข้อมูล SQL Server
// โดยดึง Connection String ที่กำหนดไว้ใน `appsettings.json` ผ่านชื่อ "DefaultConnection"

// เพิ่มการกำหนดค่า Authentication โดยใช้ Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // เวลาหมดอายุของคุกกี้
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.Name = "MyAppAuthCookie";
        options.Cookie.MaxAge = TimeSpan.Zero; // หมดอายุทันทีหลังจากออกจากระบบ
    });

// การตั้งค่า Authentication นี้ช่วยให้แอปพลิเคชันสามารถจัดการการล็อกอินและล็อกเอาต์โดยใช้ Cookies ได้

var app = builder.Build(); // สร้าง Application จากการตั้งค่าทั้งหมด

// Configure the HTTP request pipeline.
// กำหนดการตั้งค่า Pipeline สำหรับการประมวลผล HTTP Requests

if (!app.Environment.IsDevelopment())
// ตรวจสอบว่าไม่ใช่ Environment การพัฒนา (Development Environment)
{
    app.UseExceptionHandler("/Home/Error");
    // ใช้ Middleware สำหรับจัดการข้อผิดพลาด (Error Handling) โดยเปลี่ยนเส้นทางไปที่ "/Home/Error"

    app.UseHsts();
    // เปิดใช้งาน HSTS (HTTP Strict Transport Security) เพื่อเพิ่มความปลอดภัยในโปรดักชัน
}

// Middleware สำหรับกำหนดการเปลี่ยนเส้นทาง (Redirect) HTTP ไป HTTPS
app.UseHttpsRedirection();

// Middleware สำหรับให้บริการไฟล์คงที่ (Static Files) เช่น CSS, JavaScript, รูปภาพ
app.UseStaticFiles();

// Middleware สำหรับการกำหนดเส้นทาง
app.UseRouting();

// เพิ่ม Middleware สำหรับ Authentication (การยืนยันตัวตน)
app.UseAuthentication();

// เพิ่ม Middleware สำหรับ Authorization (การกำหนดสิทธิ์)
app.UseAuthorization();

// กำหนดเส้นทาง (Route) เริ่มต้นของแอปพลิเคชัน
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);
// Route นี้กำหนดให้เมื่อผู้ใช้เข้าถึงแอปพลิเคชันโดยไม่มีการระบุเส้นทาง จะถูกนำไปที่ Controller `Account` และ Action `Login`

app.Run();
// เริ่มการทำงานของแอปพลิเคชัน
