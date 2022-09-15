using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using VisitorManagementStudent2022.Models;
using System.IO;

namespace VisitorManagementStudent2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ViewData["Conditions"] =


             ViewData["Welcome"] = "Welcome to the VM Login System";
            ViewData["Visitor"] = new Visitors()
            {
                FirstName = "Howard",
                LastName = "The Barbarian",
                Business = "None of Yours..."
            };

            ViewBag.VisitorNew = new Visitors()
            {
                FirstName = "Howard",
                LastName = "The Barbarian"
            };



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}