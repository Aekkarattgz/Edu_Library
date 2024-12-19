using Microsoft.AspNetCore.Mvc;

namespace Edu_Library.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
