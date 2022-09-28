﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;

using VisitorManagementStudent2022.Data;
using VisitorManagementStudent2022.DTO;
using VisitorManagementStudent2022.Models;
using VisitorManagementStudent2022.Services;

using static VisitorManagementStudent2022.Enum.SweetAlertEnum;

namespace VisitorManagementStudent2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITextFileOperations _textFileOperations;
        private readonly ApplicationDbContext _context;
        private readonly ISweetAlert _sweetAlert;
        private readonly IDBCalls _dbCalls;
        private readonly IAPI _api;





        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, ITextFileOperations textFileOperations, ApplicationDbContext context, ISweetAlert sweetAlert, IDBCalls dbCalls, IAPI api)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _textFileOperations = textFileOperations;
            _context = context;

            _sweetAlert = sweetAlert;
            _dbCalls = dbCalls;
            _api = api;
        }

        public IActionResult Index()
        {
            Root root = _api.WeatherAPI().Result;

            ViewData["Temp"] = "The temperature is " + root.main.temp + " degrees Celsius. But it feels like " + root.main.feels_like;

            ViewData["Wind"] = "The wind is " + root.wind.speed + " kph at " + root.wind.deg + " degrees, and the humidity is  " + root.main.humidity + " kpa" + " Wind direction is " + Compass(root.wind.deg);

            //      TempData["notification"] = _sweetAlert.AlertPopupWithImage("The Visitor Management System", "Automate and record visitor management", "/images/gary.jpg", NotificationType.success);






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


        private string Compass(int windDegrees)
        {
            var data = windDegrees;
            var degrees = windDegrees;
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            var test = caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
            return test;
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


                //increase the counter 
                var staff = _context.StaffNames.Find(visitors.StaffNameId);
                staff.VisitorCount++;
                _context.Update(staff);


                _context.Add(visitors);
                await _context.SaveChangesAsync();

                TempData["create"] = _sweetAlert.AlertPopup("Welcome to the College", visitors.FirstName + " visiting " + staff.Name + " in " + staff.Department, NotificationType.success);

                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Id", visitors.StaffNameId);
            return View(visitors);
        }


        public IActionResult Admin()
        {

            ViewData["WhereQueryMethod"] = _dbCalls.WhereQuery();
            ViewData["WhereMethodSyntax"] = _dbCalls.WhereMethodSyntax();
            ViewData["Orderby"] = _dbCalls.OrderBy();
            ViewData["UniqueVisitorCount"] = _dbCalls.UniqueVisitorCount();


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