using System.ComponentModel.DataAnnotations;

namespace Edu_Library.Models
{
    public class User_tb
    {
        [Key]
        public int UserId { get; set; } // เลข 6 หลัก
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
