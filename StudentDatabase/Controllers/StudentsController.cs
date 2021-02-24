using Microsoft.AspNetCore.Mvc;
using StudentDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Controllers
{
    public class StudentsController : Controller
    {

        private readonly StudentsContext _studentsDB;
        public StudentsController(StudentsContext studentsContext)
        {
            _studentsDB = studentsContext;
        }

        public IActionResult Index()
        {
            return View(_studentsDB.Students.ToList());
        }

        public IActionResult Search(int StudentId)
        {
            Student s = _studentsDB.Students.Find(StudentId);
            return View(s);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentsDB.Students.Add(student);
                _studentsDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
