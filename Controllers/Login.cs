using CarParkingMVC.Data;
using CarParkingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkingMVC.Controllers
{
    public class Login : Controller
    {

        private readonly CarParkingMVCContext _context;

        public Login(CarParkingMVCContext context)
        {
            _context = context;
        }
        public IActionResult Adminlogin()
        {
            return View();
        }

        

        public ActionResult hedLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult hedLogin(Register login)
        {
            if (ModelState.IsValid)
            {
                
                var user = (from userlist in _context.Register
                            where userlist.Email == login.Email && userlist.Password == login.Password
                            select new
                            {
                                userlist.Email,
                                userlist.Password

                            }).ToList();
                if (user.FirstOrDefault() != null)
                {

                    return RedirectToAction(nameof(dashboard));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }

        public ActionResult WelcomePage()
        {
            return View();
        }
        public ActionResult dashboard()
        {
            return View();
        }





    }
}
