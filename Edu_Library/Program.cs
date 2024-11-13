using Edu_Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//เพิ่ม Services AddDbContext ผ่าน ApplicationDbContext โดยใช้ optios ระบุผู้ให้บริการฐานข้อมูล ระบุConnectionStringที่สร้างไว้ใน appsettings.json
// เพิ่มการกำหนดค่า Authentication โดยใช้ Cookies
builder.Services.AddAuthentication("Cookies") // ตั้งชื่อ Scheme เป็น "Cookies"
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Account/Login"; // ตั้งเส้นทางหน้า Login
        options.LogoutPath = "/Account/Logout"; // ตั้งเส้นทางหน้า Logout
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// เรียกใช้ Authentication และ Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
