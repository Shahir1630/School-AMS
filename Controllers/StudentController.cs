using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Group03_PS.Models;


using Group03_PS.Data;
using Group03_PS.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
//pdf
using Rotativa.AspNetCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Group03_PS.Controllers
{
    public class StudentController : Controller
    {
        // GET: /<controller>/

        private readonly dataContext _context;
        //pdf


        public StudentController(dataContext context)
        {
            _context = context;
        }
        
      //  [Route("Student/All")]
        public IActionResult StudentList()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                var test = _context.Student.ToList();
                var model = new List<Student>();
                foreach (var i in test)
                {
                    var s = new Student()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Class = i.Class,
                        Phone = i.Phone
                    };
                    model.Add(s);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }



              
        public IActionResult Details(Int64 id)
        {
                     
            var data = _context.Student.Where(u => u.Id == id).FirstOrDefault();

            return View(data);
        }

        //pdf
        
        public IActionResult ExportToPDF(Int64 Id)
        {

            var data = _context.Student.Where(u => u.Id == Id).FirstOrDefault();

            var pdf = new ViewAsPdf("Details", data);
            return pdf;
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add( Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();


            
            return RedirectToAction("StudentList");

        }


        public IActionResult Edit(int Id)
        {

            var data = _context.Student.Where(u => u.Id == Id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Student Student)
        {

            var data = _context.Student.Where(u => u.Id == Student.Id).FirstOrDefault();

            data.Id = Student.Id;
            data.Name = Student.Name;
            data.Class = Student.Class;
            data.Phone = Student.Phone;
            data.FatherName = Student.FatherName;
            data.MotherName = Student.MotherName;
            data.Address = Student.Address;
            data.Comment = Student.Comment;
            _context.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public IActionResult Delect(Student Student)
        {
            var data = _context.Student.Where(u => u.Id == Student.Id).FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();
                
            
            return RedirectToAction("StudentList");
        }

       
       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
