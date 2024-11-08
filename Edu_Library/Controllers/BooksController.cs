using Microsoft.AspNetCore.Mvc;

namespace Edu_Library.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
