using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCorePlayground.Models;
using System.Net;

namespace AspNetCorePlayground.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult NF()
        {
            return NotFound();
        }

        public IActionResult ISE()
        {
            return StatusCode(500);
        }

        public IActionResult HttpError(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.NotFound)
            {
                return this.View("Views/Shared/Errors/NotFound404.cshtml");
            }
            else if (statusCode == HttpStatusCode.InternalServerError)
            {
                return this.View("Views/Shared/Errors/InternalServerError500.cshtml");
            }

            return this.Error();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
