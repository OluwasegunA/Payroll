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
            var EmpCount = db.PersonalInfo.Where(d => d.ID > 0).Count();
            return Json(EmpCount, JsonRequestBehavior.AllowGet);
        }
    }
}