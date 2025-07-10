using DabisBraincellFixer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace DabisBraincellFixer.Controllers
{
    public class HomeController : Controller
    {
        // one, centrally-defined list ― no repeats, no nulls
        private static readonly SelectList _actions =
            new SelectList(new[] { "reset", "load_personality", "__other" });

        [HttpGet]
        public IActionResult Index()
        {
            // pass the list as the *model* – avoids dynamic/ViewBag pitfalls
            return View(_actions);
        }

        [HttpPost]
        public IActionResult Index(string selectedAction)
        {
            // do something with the choice…
            TempData["Msg"] = $"You chose: {selectedAction}";
            return View(_actions);      // ← always send the list back with the view
        }
    }
}
