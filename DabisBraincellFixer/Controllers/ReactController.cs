using Microsoft.AspNetCore.Mvc;

namespace DabisBraincellFixer.Controllers
{
    public class ReactController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}
