using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Group03_PS.Models;

using Microsoft.AspNetCore.Http;
using Group03_PS.Data;
using Group03_PS.ViewModels;

namespace Group03_PS.Controllers
{
    public class HomeController : Controller
    {


        private readonly dataContext _context;
        public HomeController(dataContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            if(HttpContext.Session.GetString("Email")!=null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login");
            }
        }


       // [Route("[Action]")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login( Login Login)
        {
            var db = _context.Login.Where(u=> u.Id==Login.Id && u.Password==Login.Password).FirstOrDefault();
            
           
                if (db!=null)
                { 
                    HttpContext.Session.SetString("Email", db.Id.ToString());
                    return RedirectToAction("About");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            
          
        }

       // [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Login.Add(login);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = login.Id + " is succesfully registered.";
            }

            return RedirectToAction("Index");
        }



        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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
