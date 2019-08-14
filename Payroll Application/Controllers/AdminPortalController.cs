using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class AdminPortalController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: AdminPortal
        public ActionResult Index()
        {
            CompanyInfoEntity comp = db.CompanyInfo.FirstOrDefault();
            if (comp != null)
            {
                Session["CompanyLogo"] = comp.ImageUrl;
                Session["CompanyName"] = comp.CompanyName.ToUpper();
            }
            if (Session["Username"] != null)
            {
               // Session["CompanyName"] = "POS SHOP LTD";
                ViewBag.PageTitle = "Dashboard";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        [HttpGet]
        public ActionResult GetEmpCount()
        {
            var EmpCount = db.PersonalInfo.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
            return Json(EmpCount, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUserCount()
        {
            var EmpCount = db.Users.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
            return Json(EmpCount, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStaffLeaveCount()
        {
            var EmpCount = db.Leaves.AsEnumerable().Where(d => d.Status == true).ToList().Count();
            return Json(EmpCount, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUnapproveCount()
        {
            int unLeaves = db.Leaves.AsEnumerable().Where(d => d.IsDeclined == true).ToList().Count();
            int unLoan = db.Messages.AsEnumerable().Where(d => d.IsLoan == true).ToList().Count();
            int unapprove = unLeaves + unLoan;
            return Json(unapprove, JsonRequestBehavior.AllowGet);
        }
    }
}