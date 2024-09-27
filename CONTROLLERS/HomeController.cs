using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YourNamespace.Controllers
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
            _logger.LogInformation("Index page loaded.");
            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("About page loaded.");
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogInformation("Contact page loaded.");
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}