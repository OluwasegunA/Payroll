using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Payroll_Application.Models;
using Payroll_Application.BusinessLayers;

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
            public ActionResult GeneralSetup()
            {
                if (Session["Username"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            //=================================NEW ALLOWANCE===================================================
            //Get Allowance Code
            [HttpGet]
            public ActionResult GetAllowanceCode()
            {
                try
                {
                    int code = int.Parse(DataClass.GetNextDocumentNo("Allowance", 1100).ToString());
                    return Json(code, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }
            }
            //save Allowance
            [HttpPost]
            public ActionResult SaveAllowancesSet(AllowanceEntity allowance)
            {
                bool check = false; string desc = "";
                try
                {
                    PayrollClass.SaveAllowance(allowance);
                    check = true;
                }
                catch (Exception ex)
                {
                    desc = ex.Message;
                    check = false;
                }
                return new JsonResult { Data = new { Status = check, Desc = desc } };
            }
            //load all allowances
            [HttpGet]
            public ActionResult LoadAllowances()
            {
                var data = db.Allowances.OrderBy(d => d.Description).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            //Delete Allowance
            [HttpPost]
            public ActionResult DeleteAllowance(int Code)
            {
                bool check = false; string desc = "";
                try
                {
                    var data = db.Allowances.Where(d => d.Code == Code).FirstOrDefault();
                    db.Allowances.Remove(data);
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

            //edit Allowance
            [HttpGet]
            public ActionResult EditAllowance(int Code)
            {
                var dept = db.Allowances.Where(d => d.Code == Code).FirstOrDefault();
                return Json(dept, JsonRequestBehavior.AllowGet);
            }
            //==============================================================================================

            //=================================NEW PENSION===================================================
            //Get Pension Code
            [HttpGet]
            public ActionResult GetPensionCode()
            {
                try
                {
                    int code = int.Parse(DataClass.GetNextDocumentNo("Pension", 2200).ToString());
                    return Json(code, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                }
            }
            //save Allowance
            [HttpPost]
            public ActionResult SavePensionSet(PensionEntity pension)
            {
                bool check = false; string desc = "";
                try
                {
                    PayrollClass.SavePension(pension);
                    check = true;
                }
                catch (Exception ex)
                {
                    desc = ex.Message;
                    check = false;
                }
                return new JsonResult { Data = new { Status = check, Desc = desc } };
            }
            //load all allowances
            [HttpGet]
            public ActionResult LoadPensions()
            {
                var data = db.Pensions.OrderBy(d => d.Description).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            //Delete Allowance
            [HttpPost]
            public ActionResult DeletePension(int Code)
            {
                bool check = false; string desc = "";
                try
                {
                    var data = db.Pensions.Where(d => d.Code == Code).FirstOrDefault();
                    db.Pensions.Remove(data);
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

            //edit Allowance
            [HttpGet]
            public ActionResult EditPension(int Code)
            {
                var dept = db.Pensions.Where(d => d.Code == Code).FirstOrDefault();
                return Json(dept, JsonRequestBehavior.AllowGet);
            }
            //==============================================================================================
    }
}
