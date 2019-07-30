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

        // GET: StaffSetup
        public ActionResult StaffSetup()
        {
            if (Session["UserID"] == null)
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
                var data = db.Pensions.OrderBy(d => d.Code).ToList();
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

        //=================================NEW LOAN===================================================
        //Get Loan Code
        [HttpGet]
        public ActionResult GetLoanCode()
        {
            try
            {
                int code = int.Parse(DataClass.GetNextDocumentNo("Loan", 3300).ToString());
                return Json(code, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        //save Loan
        [HttpPost]
        public ActionResult SaveLoanSet(LoanEntity loan)
        {
            bool check = false; string desc = "";
            try
            {
                PayrollClass.SaveLoan(loan);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }
        //load all Loans
        [HttpGet]
        public ActionResult LoadLoans()
        {
            var data = db.Loans.OrderBy(d => d.Code).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //Delete Loan
        [HttpPost]
        public ActionResult DeleteLoan(int Code)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Loans.Where(d => d.Code == Code).FirstOrDefault();
                db.Loans.Remove(data);
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

        //edit Loan
        [HttpGet]
        public ActionResult EditLoan(int Code)
        {
            var dept = db.Loans.Where(d => d.Code == Code).FirstOrDefault();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        //==============================================================================================

        //=================================NEW PENALTY===================================================
        //Get Penalty Code
        [HttpGet]
        public ActionResult GetPenaltyCode()
        {
            try
            {
                int code = int.Parse(DataClass.GetNextDocumentNo("Penalty", 4400).ToString());
                return Json(code, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        //save Loan
        [HttpPost]
        public ActionResult SavePenaltySet(PenaltyEntity penalty)
        {
            bool check = false; string desc = "";
            try
            {
                PayrollClass.SavePenalty(penalty);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }
        //load all Loans
        [HttpGet]
        public ActionResult LoadPenalties()
        {
            var data = db.Penalties.OrderBy(d => d.Code).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //Delete Loan
        [HttpPost]
        public ActionResult DeletePenalty(int Code)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Penalties.Where(d => d.Code == Code).FirstOrDefault();
                db.Penalties.Remove(data);
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

        //edit Loan
        [HttpGet]
        public ActionResult EditPenalty(int Code)
        {
            var dept = db.Penalties.Where(d => d.Code == Code).FirstOrDefault();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        //==============================================================================================

        
        //Loading Staff
        [HttpGet]
        public ActionResult LoadAllStaff()
        {
            var data = db.PersonalInfo.OrderBy(d => d.StaffNo).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //loading staff names
        [HttpGet]
        public ActionResult GetStaffName(string staff)
        {
            var res = db.PersonalInfo.Where(d => d.StaffNo == staff).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //Loading allowance description
        [HttpGet]
        public ActionResult LoadAllType()
        {
            var model = db.Allowances.OrderBy(d => d.Code).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Loading allowance types and percent value
        [HttpGet]
        public ActionResult LoadAllowanceType(string descript)
        {
            var model = db.Allowances.Where(d => d.Description == descript).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Saving Salary Information
        [HttpPost]
        public ActionResult SaveSalaryDet(SalaryEntity salary)
        {
            bool check = false; string desc = "";
            try
            {
                PayrollClass.SaveSalary(salary);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //Loading Net Salary for Staff
        [HttpGet]
        public ActionResult LoadNetSalary(string staffName, string staffID)
        {
            var model = db.Salaries.Where(d => d.StaffNo == staffID || d.StaffName == staffName).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Saving Staff Loan
        [HttpPost]
        public ActionResult SaveStaffLoan(StaffLoanEntity indiviLoan)
        {
            bool check = false; string desc = "";
            try
            {
                PayrollClass.SaveStaffLoan(indiviLoan);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //Loading Net Salary for Staff
        [HttpGet]
        public ActionResult LoadDeduction(string describe)
        {
            var model = db.Penalties.Where(d => d.Description == describe).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Saving Staff Deduction
        [HttpPost]
        public ActionResult SaveStaffDeduction(DeductionEntity staffDeduction)
        {
            bool check = false; string desc = "";
            try
            {
                PayrollClass.Savededuct(staffDeduction);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //load from Salary table with ID
        [HttpGet]
        public ActionResult LoadALL(string sID)
        {
            var data = db.Salaries.Where(d => d.StaffNo == sID && d.Period == "Monthly").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //load from Salary table with ID
        [HttpGet]
        public ActionResult LoadALLAnnual(string sID)
        {
            var data = db.Salaries.Where(d => d.StaffNo == sID && d.Period == "Annually").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //load from StaffLoan table with ID
        [HttpGet]
        public ActionResult PStaffLoan(string sID)
        {
            var data = db.StaffLoans.Where(d => d.StaffNo == sID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //load from StaffPenalty table with ID
        [HttpGet]
        public ActionResult PStaffDeduction(string sID)
        {
            var data = db.StaffDeductions.Where(d => d.StaffNo == sID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
