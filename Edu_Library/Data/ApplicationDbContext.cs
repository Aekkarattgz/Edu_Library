using Microsoft.EntityFrameworkCore;
using Edu_Library.Models;
using Microsoft.Extensions.Options;
namespace Edu_Library.Data
{
    //ตัว constructor นี้เป็นวิธีที่เรากำหนดค่าให้กับคลาส ApplicationDbContext ซึ่งเป็นคลาสที่สืบทอดมาจาก DbContext ของ Entity Framework Core

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //DbContextOptions เป็นคลาสที่เก็บข้อมูลการตั้งค่าทั้งหมดที่ DbContext จะต้องใช้
        //พารามิเตอร์นี้(options) จะถูกกำหนดค่าจากภายนอก ผ่าน Dependency Injection ซึ่งช่วยให้เราไม่ต้องกำหนดค่าภายในคลาส ApplicationDbContext เอง
        //ข้อมูลใน options อาจประกอบด้วยการตั้งค่าการเชื่อมต่อกับฐานข้อมูล
        {

        }
        public DbSet<User_tb> Users { get; set; }
        public DbSet<Book_tb> Books { get; set; }
        public DbSet<Category_tb> Categories { get; set; }
    }
}
