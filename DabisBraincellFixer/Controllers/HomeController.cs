using Microsoft.AspNetCore.Mvc;

namespace DabisBraincellFixer.Controllers
{
    public class HomeController : Controller
    {
        // GET / or /Home
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}