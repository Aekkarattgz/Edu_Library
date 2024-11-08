var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
