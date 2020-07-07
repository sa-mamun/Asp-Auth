using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SamTech.StudentManagement.Web.Models;

namespace SamTech.StudentManagement.Web.Controllers
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

        [HttpPost]
        public IActionResult Index(StudentModel studentModel)
        {
            studentModel.createStudent();
            return View();
        }

        [HttpPost]
        public IActionResult EditStudent(StudentModel studentModel)
        {
            studentModel.editStudent();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult DeleteStudent(StudentModel studentModel)
        {
            studentModel.deleteStudent();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Course(CourseModel courseModel)
        {
            courseModel.createCourse();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult EditCourse(CourseModel courseModel)
        {
            courseModel.editCourse();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult DeleteCourse(CourseModel courseModel)
        {
            courseModel.deleteCourse();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Registration(StudentRegistrationModel studentRegistrationModel)
        {
            studentRegistrationModel.createRegistration();
            return Redirect("/Home/Index");
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
