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

        // The Index action method for the home page
        public IActionResult Index()
        {
            _logger.LogInformation("Index page loaded.");
            // Display welcome message and brief about the assignment
            ViewBag.Title = "Concert Halls Management";
            ViewBag.Message = "Welcome to the Concert Halls management system. Use the navigation bar to manage concerts.";
            return View();
        }

        // The About action method for the about page
        public IActionResult About()
        {
            _logger.LogInformation("About page loaded.");
            ViewBag.Title = "About Concert Halls Management";
            ViewBag.Message = "This application allows you to manage concerts by creating, editing, and deleting concert information. The system is built using ASP.NET Core MVC.";
            ViewBag.Course = "WEB524 - Fall 2024";
            return View();
        }

        // The Contact action method for the contact page
        public IActionResult Contact()
        {
            _logger.LogInformation("Contact page loaded.");
            ViewBag.Title = "Contact";
            ViewBag.Message = "Developer Contact Information";
            ViewBag.Name = "Your Full Name";
            ViewBag.Email = "YourEmail@domain.com";
            return View();
        }
    }
}
