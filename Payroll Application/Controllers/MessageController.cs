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
        
        //Sending Messages
        [HttpPost]
        public ActionResult SendMsg(MessageEntity messageContent)
        {
            MyDbContext db = new MyDbContext();
            bool check = false; string desc = "";
            try
            {
                MessageEntity Content = new MessageEntity();
                Content.To_ID = messageContent.To_ID;
                Content.From_ID = messageContent.From_ID;
                Content.Body = messageContent.Body;
                Content.Subject = messageContent.Subject;
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