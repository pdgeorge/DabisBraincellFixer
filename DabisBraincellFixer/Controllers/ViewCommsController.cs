using Microsoft.AspNetCore.Mvc;
using DabisBraincellFixer.Services;

namespace DabisBraincellFixer.Controllers
{
    [ApiController]
    [Route("Home")]
    public class ViewCommsController : Controller
    {
        private readonly CommService _commService;

        public ViewCommsController()
            => _commService = new CommService();

        // GET / or /Home
        [HttpGet("ViewComms")]
        public IActionResult ViewComms([FromQuery] string? searchUsername)
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