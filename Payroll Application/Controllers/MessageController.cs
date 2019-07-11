using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Payroll_Application.Controllers
{
    public class MessageController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Message
        public ActionResult Message()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        //Get Logged User ID
        
    }
}