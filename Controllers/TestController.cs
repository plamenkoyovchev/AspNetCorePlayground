using AspNetCorePlayground.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePlayground.Controllers
{
    public class TestController : Controller
    {
        private readonly PlaygroundContext context;

        public TestController(PlaygroundContext context)
        {
            this.context = context;
        }

        public IActionResult Get()
        {
            return Ok(this.context.Installations);
        }
    }
}