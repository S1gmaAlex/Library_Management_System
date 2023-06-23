using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace library.Controllers
{
    public class IssueBookController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: IssueBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Getbook()
        {
            var books = db.books.Select(p => new
            {
                ID = p.id,
                Bookname = p.bookname
            }).ToList();
            return Json(books, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult GetMemberID(int memberid)
        {
            var mid = (from s in db.members where s.id == memberid select s.name).ToList();
            return Json(mid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(issuebook issue)
        {
            if (ModelState.IsValid)
            {
                db.issuebooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issue);
        }
    }
}