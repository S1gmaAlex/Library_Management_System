using library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace library.Controllers
{
    public class ReturnBookController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMemberID(int memberid)
        {
            var mid = (from s in db.issuebooks
                       where s.memberid == memberid
                       select new
                       {
                           IssueDate = s.issuedate,
                           ReturnDate = s.returndate,
                           Memberid = s.memberid,
                           BookName = s.bookid,
                           ElapsedDays = SqlFunctions.DateDiff("day", s.returndate, DateTime.Now)
                       }).ToArray();                 
            return Json(mid,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save( returnbook returnbook)
        {
            if (ModelState.IsValid)
            {
                db.returnbooks.Add(returnbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returnbook);
        }
    }
}