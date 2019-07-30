using Payroll_Application.BusinessLayers;
using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class HomeController : Controller
    {
        string staffId = "", staffName = "";
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            ViewBag.appName = "Payroll Application";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            try
            {
                string encryptpass = SecurityClass.Encrypt(password);
                var olduser = db.Users.Where(d => (d.Username == username || d.Email==username) && d.Password == encryptpass).FirstOrDefault();
                if (olduser != null)
                {
                    Session["UserID"] = olduser.UserID;
                    if (olduser.OtherID != string.Empty)
                    {
                        Session["OtherID"] = olduser.OtherID;
                    }
                    Session["FullName"] = olduser.FullName;
                    Session["Username"] = olduser.Username;
                    Session["UserRole"] = olduser.UserRole;
                    Session["UserImg"] = olduser.ImageUrl;
                    if (olduser.UserRole == "Admin")
                    {
                        staffId = Session["OtherID"].ToString();
                        staffName = Session["FullName"].ToString();
                        return RedirectToAction("Index", "AdminPortal");
                    }
                    else
                    {
                        staffId = Session["OtherID"].ToString();
                        staffName = Session["FullName"].ToString();
                        return RedirectToAction("Index", "StaffPortal");
                    }
                }
                else
                {
                    ViewBag.errorLogin = "Invalid Username or Password";
                }
            }
            catch(Exception ex)
            {
                ViewBag.errorLogin = ex.Message;
            }
            return View();
        }

       
       
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            return View("Index");
        }

    }
}