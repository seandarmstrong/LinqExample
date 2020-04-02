using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinqExample.Models;

namespace LinqExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result(string nameQuery)
        {
            List<Student> studentList = new List<Student>() {
                new Student() { Id = 1, Name = "Steve", Age = 18 } ,
                new Student() { Id = 2, Name = "Steve",  Age = 21 } ,
                new Student() { Id = 3, Name = "Bill",  Age = 18 } ,
                new Student() { Id = 4, Name = "Ram" , Age = 20 } ,
                new Student() { Id = 5, Name = "Ron" , Age = 21 }
            };

            var student = studentList.Where(x => x.Name == nameQuery).ToList();
            var newStudentList = studentList.OrderBy(x => x.Name).ToList();
            var result = studentList.Any(x => x.Name == "Bill");
            var studentExists = studentList.Any<Student>();
            var studentName = studentList.OrderBy(x => x.Age).Select(y => y.Age).ToList();
            var studentAge = studentList.Select(x => x.Age).FirstOrDefault();

            var queryResult = (from s in studentList
                              where s.Id == 3
                              select s.Name).ToList();

            var sumOfAllAges = studentList.Sum(x => x.Age);

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
