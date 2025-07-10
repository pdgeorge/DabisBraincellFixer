using DabisBraincellFixer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace DabisBraincellFixer.Controllers
{
    public class MessageController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            // pass the list as the *model* – avoids dynamic/ViewBag pitfalls
            return View();
        }
    }
}
