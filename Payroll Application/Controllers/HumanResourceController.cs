using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class HumanResourceController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: HumanResource
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LeaveMod()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Approve Leave
        [HttpPost]
        public ActionResult ApproveLeave(int ID)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (data != null)
                {
                    check = true;
                }
                var aLeave = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (aLeave != null)
                {
                    if (check)
                    {
                        aLeave.Status = true;
                        aLeave.IsDeclined = false;
                    }
                    else
                    {
                        db.Leaves.Remove(aLeave);
                    }

                }
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        [HttpPost]
        public ActionResult DeclineLeave(int ID)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (data != null)
                {
                    check = true;
                }
                var aLeave = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (aLeave != null)
                {
                    if (check)
                    {
                        aLeave.Status = false;
                        aLeave.IsDeclined = true;
                    }
                    else
                    {
                        db.Leaves.Remove(aLeave);
                    }

                }
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        //Load Pending Leave
        [HttpGet]
        public ActionResult LoadPendingLea()
        {
            var data = db.Leaves.Where(d => d.Status == false && d.IsDeclined == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Load Approve Leave
        [HttpGet]
        public ActionResult LoadApproveLea()
        {
            var data = db.Leaves.Where(d => d.Status == true && d.IsDeclined == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Load Declined Leave
        [HttpGet]
        public ActionResult LoadDeclineLea()
        {
            var data = db.Leaves.Where(d => d.IsDeclined == true && d.Status == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Delete Leave
        [HttpPost]
        public ActionResult DeleteLeave(int ID)
        {
            bool check = false; string desc = "";
            var emp = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
            try {
                db.Leaves.Remove(emp);
                check = true;
            }
            catch(Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        //Loading Loan
        [HttpGet]
        public ActionResult LoadLoan()
        {
            var data = db.Messages.Where(d => d.IsLoan == true).ToList().FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Delete Leave
        [HttpPost]
        public ActionResult DeleteLoan(int ID)
        {
            bool check = false; string desc = "";
            var emp = db.Messages.Where(d => d.ID == ID && d.IsLoan == true).FirstOrDefault();
            try
            {
                db.Messages.Remove(emp);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }
    }
}