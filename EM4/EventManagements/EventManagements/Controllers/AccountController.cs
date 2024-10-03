using EventManagements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagements.Controllers;
namespace EventManagements.Controllers
{
    public class AccountController : Controller
    {

        private readonly EventManagementSystemEntities db = new EventManagementSystemEntities();
        public ActionResult AccountIndex() { return View(); }

        // Login Action
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if the admin exists in the database
                    var existingAdmin = db.Admins.FirstOrDefault(a => a.UserName == admin.UserName  && a.Password == admin.Password);

                    if (existingAdmin != null)
                    {
                        // Successfully logged in, redirect to Admin dashboard
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        // If the credentials are incorrect
                        ViewBag.ErrorMessage = "Invalid email or password";
                        return View(admin);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message(ex.Message);
            }
            
            return View(admin);
        }

        //userlogin
        public ActionResult UserLogin() => View();
        [HttpPost]
        public ActionResult UserLogin(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.users.SingleOrDefault(u => u.Username == username && u.password == password);
                    if (user != null)
                    {
                        Session["UserId"] = user.UserId;
                        return RedirectToAction("ClientIndex", "Client");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid login credentials";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message(ex.Message);
            }
            return View();
        }

        // Register Action
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("UserLogin");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message(ex.Message);
            }
            return View(user);
        }
    }

}