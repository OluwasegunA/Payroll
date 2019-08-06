using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class StaffPortalController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: StaffPortal
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LeaveApplication()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LoanApplication()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveLeave(LeaveEntity leave)
        {
            bool check = false; string desc = "";
            try
            {
                LeaveEntity StaffLeave = new LeaveEntity();
                StaffLeave.StaffId = leave.StaffId;
                StaffLeave.StaffName = leave.StaffName;
                StaffLeave.LeaveType = leave.LeaveType;
                StaffLeave.FromDate = leave.FromDate;
                StaffLeave.ToDate = leave.ToDate;
                StaffLeave.NoDays = leave.NoDays;
                StaffLeave.Recall = leave.Recall;
                StaffLeave.Remark = leave.Remark;
                StaffLeave.Balance = leave.Balance;
                StaffLeave.Status = leave.Status;
                db.Leaves.Add(leave);
                db.SaveChanges();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        //Load Leaves
        [HttpGet]
        public ActionResult LoadLeave(string staffID)
        {
            var data = db.Leaves.Where(d => d.StaffId == staffID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Delete Leave Request
        [HttpPost]
        public ActionResult DeleteLeave(int ID)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                db.Leaves.Remove(data);
                db.SaveChanges();
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return Json(check);
        }

        //Load Application Admin
        [HttpGet]
        public ActionResult LoadAdmin()
        {
            var data = db.Users.Where(d => d.Department == "HR").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Sending Loan Request
        [HttpPost]
        public ActionResult SendLoanReq(MessageEntity messageContent)
        {
            MyDbContext db = new MyDbContext();
            bool check = false; string desc = "";
            try
            {
                MessageEntity Content = new MessageEntity();
                Content.To_ID = messageContent.To_ID;
                Content.RecieverName = messageContent.RecieverName;
                Content.SenderName = messageContent.SenderName;
                Content.From_ID = messageContent.From_ID;
                Content.Body = messageContent.Body;
                Content.Subject = messageContent.Subject;
                Content.IsLoan = true;
                db.Messages.Add(messageContent);
                db.SaveChanges();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
    }
}