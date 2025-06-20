using Microsoft.AspNetCore.Mvc;

namespace DabisBraincellFixer.Controllers
{
    [ApiController]
    [Route("Home")]
public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("helloworld")]
        public IActionResult helloworld()
        {
            return Ok("Hello, world!");
        }
    }
}
