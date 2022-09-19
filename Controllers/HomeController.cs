using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;

using VisitorManagementStudent2022.Data;
using VisitorManagementStudent2022.Models;
using VisitorManagementStudent2022.Services;

namespace VisitorManagementStudent2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITextFileOperations _textFileOperations;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, ITextFileOperations textFileOperations, ApplicationDbContext context)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _textFileOperations = textFileOperations;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Conditions"] = _textFileOperations.LoadConditionsOfAcceptance();


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
            //Create View Code    GET: Visitors/Create
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Name");

            //Create an instance of visitor
            Visitors visitor = new Visitors();
            //pass in the current date and time
            visitor.DateIn = DateTime.Now;
            visitor.Business = "Mind Your Own";

            return View(visitor);
        }





        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateIn,DateOut,StaffNameId")] Visitors visitors)
        {
            if (ModelState.IsValid)
            {
                visitors.Id = Guid.NewGuid();
                _context.Add(visitors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Id", visitors.StaffNameId);
            return View(visitors);
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