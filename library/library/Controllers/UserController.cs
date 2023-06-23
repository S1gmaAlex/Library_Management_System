using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models;

namespace library.Controllers
{   
    
    public class UserController : Controller
    {
        // GET: User
        lmsEntities db = new lmsEntities();
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (db.Users.Any(x => x.UserName == user.UserName))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                Session["UserID"] = user.UserID.ToString();
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var check = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)).FirstOrDefault();
            if(check != null)
            {
                Session["UserID"] = user.UserID.ToString();
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Nofitication = "Wrong UserName or Password";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}