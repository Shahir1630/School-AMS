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
    public class TeacherPaymentController : Controller
    {
        // GET: /<controller>/
        private readonly dataContext _context;
        public TeacherPaymentController(dataContext context)
        {
            _context = context;
        }

        public IActionResult Teacher(Int64 TeacherId, TeacherPayment teacherPayment)
        {

            var data = _context.TeacherPayment.ToList();

            var model = new List<TeacherPayment>();
            foreach (var i in data)
            {
                if (TeacherId != i.TeacherId)
                {
                    continue;
                }

                var s = new TeacherPayment();
                s.TeacherId = i.TeacherId;
                s.Date = i.Date;
                s.Salary = i.Salary;
                
                s.MonthName = i.MonthName;
               
                s.Fine = i.Fine;
               
                model.Add(s);
            }
            return View(model);
        }

        public IActionResult TeacherPaymentAdd(Int64 Id, TeacherPayment teacherPayment)
        {
            teacherPayment.TeacherId = Id;
            return View();
        }


        [HttpPost]
        public IActionResult TeacherPaymentAdd(TeacherPayment teacherPayment)
        {
            Int64 Id = teacherPayment.TeacherId;
            _context.TeacherPayment.Add(teacherPayment);
            _context.SaveChanges();



            return RedirectToAction("Teacher", new { id = Id });

        }

        public IActionResult TeacherPaymentEdit(Int64 TeacherId, DateTime Date)
        {
            var t = Date;

            var model = _context.TeacherPayment.Where(u => u.TeacherId == TeacherId && u.Date == Date).FirstOrDefault();

            //var data = _context.StudentPayment.ToList();
            //if(data.Id==Id )
            return View(model);
        }

        [HttpPost]
        public IActionResult TeacherPaymentEdit(TeacherPayment i)
        {

            var s = _context.TeacherPayment.Where(u => u.TeacherId == i.TeacherId && u.No == i.No).FirstOrDefault();

            s.TeacherId = i.TeacherId;
            s.Date = i.Date;
            s.Salary = i.Salary;
           
            s.MonthName = i.MonthName;
            s.Fine = i.Fine;
           
            //  _context.StudentPayment.Update(s);
            _context.SaveChanges();
            return RedirectToAction("Teacher", new { Teacherid = i.TeacherId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
