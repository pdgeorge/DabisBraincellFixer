using DabisBraincellFixer.Data;
using DabisBraincellFixer.Models;
using DabisBraincellFixer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DabisBraincellFixer.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommService _commService;

        public HomeController()
        {
            _commService = new CommService();
        }

        public IActionResult Index(int id = 1)
        {
            var comm = _commService.GetCommById(id);
            return View(comm ?? new Comm { Id = id });
        }

        [HttpPost]
        public IActionResult Update(Comm record)
        {
            _commService.UpdateRecord(record);
            return RedirectToAction("Index", new { id = record.Id + 1 });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _commService.DeleteRecord(id);
            return RedirectToAction("Index", new { id = id + 1 });
        }

        public IActionResult Skip(int id)
        {
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult ViewComms(string searchUsername)
        {
            var comms = _commService.GetAllComms();

            if (!string.IsNullOrEmpty(searchUsername))
            {
                comms = comms
                    .Where(c => c.Username != null && c.Username.Contains(searchUsername, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Pass the searchUsername to the view using ViewData
            ViewData["searchUsername"] = searchUsername;

            return View(comms);
        }
    }
}
