using DabisBraincellFixer.Models;
using DabisBraincellFixer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DabisBraincellFixer.Controllers
{
    public class DabiBCController : Controller
    {
        private readonly CommService _commService = new();

        public IActionResult Index(int id = 1)
        {
            var comm = _commService.GetCommById(id) ?? new Comm { Id = id };
            return View(comm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Comm record)
        {
            Console.WriteLine("Pre-Update");
            Console.WriteLine(record.Username);
            _commService.UpdateRecord(record);
            return RedirectToAction("Index", new { id = record.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _commService.DeleteRecord(id);
            return RedirectToAction("Index", new { id = id + 1 });
        }

        public IActionResult Skip(int id)
        {
            return RedirectToAction("Index", new { id = id });
        }
    }
}
