using Microsoft.EntityFrameworkCore; // นำเข้า namespace สำหรับการใช้ Entity Framework Core
using Edu_Library.Models; // นำเข้า namespace สำหรับการใช้โมเดลที่กำหนดไว้


namespace Edu_Library.Data
{
    // คลาส ApplicationDbContext สืบทอดมาจาก DbContext ของ Entity Framework Core
    // ซึ่งทำหน้าที่เชื่อมต่อกับฐานข้อมูลและกำหนด DbSet สำหรับตารางต่างๆ
    public class ApplicationDbContext : DbContext
    {
        // ตัว constructor นี้ใช้เพื่อกำหนดค่าการตั้งค่าต่างๆ ของ DbContext
        // พารามิเตอร์ options จะถูกกำหนดค่าผ่าน Dependency Injection 
        // โดยใน options จะมีการตั้งค่าการเชื่อมต่อกับฐานข้อมูล
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // base(options) เรียก constructor ของ DbContext เพื่อส่งการตั้งค่าการเชื่อมต่อฐานข้อมูลที่ได้รับมา
        }

        // DbSet สำหรับตาราง Book_tb ในฐานข้อมูล
        public DbSet<Book_tb> Book_tb { get; set; }

        // DbSet สำหรับตาราง Category_tb ในฐานข้อมูล
        public DbSet<Category_tb> Category_tb { get; set; }

        // DbSet สำหรับตาราง User_tb ในฐานข้อมูล
        public DbSet<User_tb> User_tb { get; set; }
    }
}
