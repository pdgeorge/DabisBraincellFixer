using DabisBraincellFixer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace DabisBraincellFixer.Controllers
{
    public class PersonalityController : Controller
    {

        private const string _rawUrl = "https://raw.githubusercontent.com/pdgeorge/DabisNewBraincell/refs/heads/master/system.json";

        private static readonly Lazy<Task<SelectList>> _personalities =
            new(() => PersonalityLoader.FromGitHubAsync(_rawUrl));

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _personalities.Value;
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string selectedPersonality)
        {
            // do something with the choice…
            TempData["Msg"] = $"You chose: {selectedPersonality}";
            var list = await _personalities.Value;
            return View(list);      // ← always send the list back with the view
        }
    }
}
