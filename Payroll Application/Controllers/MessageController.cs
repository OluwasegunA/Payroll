using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
        
        //Sending Messages
        [HttpPost]
        public ActionResult SendMsg(MessageEntity messageContent)
        {
            MyDbContext db = new MyDbContext();
            bool check = false; string desc = "";
            try
            {
                MessageEntity Contents = new MessageEntity();
                Contents.To_ID = messageContent.To_ID;
                Contents.From_ID = messageContent.From_ID;
                Contents.Body = messageContent.Body;
                Contents.Subject = messageContent.Subject;
                Contents.SenderName = messageContent.SenderName;
                Contents.RecieverName = messageContent.RecieverName;
                Contents.Date = DateTime.Now;
                db.Messages.Add(Contents);
                db.SaveChanges();
                check = true;
                desc = "Message sent! \n Please Refresh the page to continue";
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //Loading Inbox
        [HttpGet]
        public ActionResult LoadInbox(string myStaffNo)
        {
            var data = db.Messages.Where(d => d.To_ID == myStaffNo && d.IsLoan == false && d.Status == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Loading Sent 
        [HttpGet]
        public ActionResult LoadSent(string myStaffNo)
        {
            var data = db.Messages.Where(d => d.From_ID == myStaffNo && d.IsLoan == false && d.Status == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Loading Trash 
        [HttpGet]
        public ActionResult LoadTrash(string myStaffNo)
        {
            var data = db.Messages.Where(d => (d.From_ID == myStaffNo || d.To_ID == myStaffNo) && d.IsLoan == false && d.Status == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Change Message Status
        [HttpPost]
        public ActionResult MsgStatus(int id)
        {
            bool check = false; string desc = "";
            try
            {
                var msg = db.Messages.Where(d => d.ID == id).FirstOrDefault();
                if (msg != null)
                {
                    msg.Status = true;
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

        //Change Message Status
        [HttpPost]
        public ActionResult RecoverMsg(int id)
        {
            bool check = false; string desc = "";
            try
            {
                var msg = db.Messages.Where(d => d.ID == id).FirstOrDefault();
                if (msg != null)
                {
                    msg.Status = false;
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

        //Completely Delete Messages
        [HttpPost]
        public ActionResult DeleteMsg(int id)
        {
            bool check = false; string desc = "";
            try
            {
                var msg = db.Messages.Where(d => d.ID == id).FirstOrDefault();
                if (msg.Status == true)
                {
                    db.Messages.Remove(msg);
                }
                else
                {
                    msg.Status = true;
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

        //Counting Inbox 
        [HttpGet]
        public ActionResult CountInbox(string myStaffNo)
        {
            var data = db.Messages.AsEnumerable().Where(d => d.To_ID == myStaffNo && d.IsLoan == false && d.Status == false).ToList().Count;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Counting Sent 
        [HttpGet]
        public ActionResult CountSent(string myStaffNo)
        {
            var data = db.Messages.AsEnumerable().Where(d => d.From_ID == myStaffNo && d.IsLoan == false && d.Status == false).ToList().Count;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Counting Trash 
        [HttpGet]
        public ActionResult CountTrash(string myStaffNo)
        {
            var data = db.Messages.AsEnumerable().Where(d => (d.From_ID == myStaffNo || d.To_ID == myStaffNo) && d.IsLoan == false && d.Status == true).ToList().Count;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}