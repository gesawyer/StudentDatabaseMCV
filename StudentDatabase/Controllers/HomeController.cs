using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDatabase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Controllers
{
    public class HomeController : Controller
    {
        ////private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public StudentsContext studentsDb { get; set; } = new StudentsContext();

        public IActionResult Index()
        {
            return View(studentsDb.Students.ToList());
        }

        public IActionResult Search(int StudentId)
        {
            Student s = studentsDb.Students.Find(StudentId);
            return View(s);
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
