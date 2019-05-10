using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class PayrollController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Payroll
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}