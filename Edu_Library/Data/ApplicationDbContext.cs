using Microsoft.EntityFrameworkCore;
using Edu_Library.Models;
namespace Edu_Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User_tb> Users { get; set; }
        public DbSet<Book_tb> Books { get; set; }
        public DbSet<Category_tb> Categories { get; set; }
    }
}
