using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Group03_PS.Data;
using Group03_PS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group03_PS.Controllers
{
    public class TeacherController : Controller
    {
        // GET: /<controller>/

        private readonly dataContext _context;
        

        public TeacherController(dataContext context)
        {
            _context = context;
        }

        public IActionResult TeacherList()
        {
            var test = _context.Teacher.ToList();
            var model = new List<Teacher>();
            foreach (var i in test)
            {
                var s = new Teacher()
                {
                    TeacherId = i.TeacherId,
                    TeacherName = i.TeacherName,
                    Address = i.Address,
                    Phone = i.Phone
                };
                model.Add(s);
            }

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            _context.SaveChanges();



            return RedirectToAction("TeacherList");

        }


        public IActionResult Edit(int TeacherId)
        {

            var data = _context.Teacher.Where(u => u.TeacherId == TeacherId).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {

            var data = _context.Teacher.Where(u => u.TeacherId == teacher.TeacherId).FirstOrDefault();

            data.TeacherId = teacher.TeacherId;
            data.TeacherName = teacher.TeacherName;
            data.Address = teacher.Address;
            data.Phone = teacher.Phone;
          
            _context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        public IActionResult Delect(Teacher teacher)
        {
            var data = _context.Teacher.Where(u => u.TeacherId == teacher.TeacherId).FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();


            return RedirectToAction("TeacherList");
        }

        public IActionResult Details(Int64 TeacherId)
        {

            var data = _context.Teacher.Where(u => u.TeacherId == TeacherId).FirstOrDefault();

            return View(data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
