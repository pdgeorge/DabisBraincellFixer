using Microsoft.AspNetCore.Mvc;

namespace DabisBraincellFixer.Controllers
{
    [ApiController]
    [Route("helloworld")]
public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}
