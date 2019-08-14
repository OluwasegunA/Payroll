using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.BusinessLayers
{
    public class PayrollClass
    {
        //Save Allowance
        public static void SaveAllowance(AllowanceEntity allowance)
        {
            MyDbContext db = new MyDbContext();
            var oldAll = db.Allowances.Where(d => d.Code == allowance.Code).FirstOrDefault();
            if (oldAll != null)
            {
                oldAll.Description = allowance.Description;
                oldAll.AllType = allowance.AllType;
                oldAll.Percentage = allowance.Percentage;
                oldAll.Grade = allowance.Grade;
                oldAll.Period = allowance.Period;
            }
            else
            {
                db.Allowances.Add(allowance);
            }
            db.SaveChanges();
        }
        //Save Pension
        public static void SavePension(PensionEntity pension)
        {
            MyDbContext db = new MyDbContext();
            var oldAll = db.Pensions.Where(d => d.Code == pension.Code).FirstOrDefault();
            if (oldAll != null)
            {
                oldAll.Description = pension.Description;
                oldAll.EmployeePer = pension.EmployeePer;
                oldAll.EmployerPer = pension.EmployerPer;
            }
            else
            {
                db.Pensions.Add(pension);
            }
            db.SaveChanges();
        }
        //Save Loan
        public static void SaveLoan(LoanEntity loan)
        {
            MyDbContext db = new MyDbContext();
            var oldLoan = db.Loans.Where(d => d.Code == loan.Code).FirstOrDefault();
            if (oldLoan != null)
            {
                oldLoan.Description = loan.Description;
                oldLoan.MinPay = loan.MinPay;
                oldLoan.MaxPay = loan.MaxPay;
            }
            else
            {
                db.Loans.Add(loan);
            }
            db.SaveChanges();
        }
        //Save Penalty
        public static void SavePenalty(PenaltyEntity penalty)
        {
            MyDbContext db = new MyDbContext();
            var oldPe = db.Penalties.Where(d => d.Code == penalty.Code).FirstOrDefault();
            if (oldPe != null)
            {
                oldPe.Description = penalty.Description;
                oldPe.Percentage = penalty.Percentage;
                oldPe.DeductType = penalty.DeductType;
            }
            else
            {
                db.Penalties.Add(penalty);
            }
            db.SaveChanges();
        }

        //Save Salary
        public static void SaveSalary(SalaryEntity salary)
        {
            MyDbContext db = new MyDbContext();
            SalaryEntity oldSalary = new SalaryEntity();
                oldSalary.StaffNo = salary.StaffNo;
                oldSalary.StaffName = salary.StaffName;
                oldSalary.Period = salary.Period;
                oldSalary.BasicDescription = salary.BasicDescription;
                oldSalary.HousingDescription = salary.HousingDescription;
                oldSalary.TransportDescription = salary.TransportDescription;
                oldSalary.UtilityDescription = salary.UtilityDescription;
                oldSalary.LunchDescription = salary.LunchDescription;
                oldSalary.OtherDescription = salary.OtherDescription;
                oldSalary.BasicType = salary.BasicType;
                oldSalary.HousingType = salary.HousingType;
                oldSalary.TransportType = salary.TransportType;
                oldSalary.UtilityType = salary.UtilityType;
                oldSalary.LunchType = salary.LunchType;
                oldSalary.OtherType = salary.OtherType;
                oldSalary.BasicPer = salary.BasicPer;
                oldSalary.HousingPer = salary.HousingPer;
                oldSalary.TransportPer = salary.TransportPer;
                oldSalary.UtilityPer = salary.UtilityPer;
                oldSalary.LunchPer = salary.LunchPer;
                oldSalary.OtherPer = salary.OtherPer;
                oldSalary.BasicAmt = salary.BasicAmt;
                oldSalary.HousingAmt = salary.HousingAmt;
                oldSalary.TransportAmt = salary.TransportAmt;
                oldSalary.UtilityAmt = salary.UtilityAmt;
                oldSalary.LunchAmt = salary.LunchAmt;
                oldSalary.OtherAmt = salary.OtherAmt;
                oldSalary.Amount = salary.Amount;
            db.Salaries.Add(oldSalary);
            db.SaveChanges();
        }

        //Save Staff loan
        public static void SaveStaffLoan(StaffLoanEntity indiviLoan)
        {
            MyDbContext db = new MyDbContext();
            StaffLoanEntity oldSL = new StaffLoanEntity();
            oldSL.StaffNo = indiviLoan.StaffNo;
            oldSL.StaffName = indiviLoan.StaffName;
            oldSL.NetSalary = indiviLoan.NetSalary;
            oldSL.LoanType = indiviLoan.LoanType;
            oldSL.LoanAmount = indiviLoan.LoanAmount;
            oldSL.Interest = indiviLoan.Interest;
            oldSL.TotalLoanAmount = indiviLoan.TotalLoanAmount;
            oldSL.Installment = indiviLoan.Installment;
            oldSL.Repayment = indiviLoan.Repayment;
            db.StaffLoans.Add(oldSL);
            db.SaveChanges();
        }

        //Save Staff deduction
        public static void Savededuct(DeductionEntity staffDeduction)
        {
            MyDbContext db = new MyDbContext();
            DeductionEntity newDeduct = new DeductionEntity();
            newDeduct.StaffNo = staffDeduction.StaffNo;
            newDeduct.StaffName = staffDeduction.StaffName;
            newDeduct.PenaltyType = staffDeduction.PenaltyType;
            newDeduct.DeductionType = staffDeduction.DeductionType;
            newDeduct.Amount = staffDeduction.Amount;
            db.StaffDeductions.Add(newDeduct);
            db.SaveChanges();
        }

        //Saving generated Staff PAYE
        public static void SaveStaffPayE(PAYEEntity paye)
        {
            MyDbContext db = new MyDbContext();
            PAYEEntity newPayE = new PAYEEntity();
            newPayE.StaffID = paye.StaffID;
            newPayE.StaffName = paye.StaffName;
            newPayE.PayPeriod = paye.PayPeriod;
            newPayE.NetSalary = paye.NetSalary;
            newPayE.Basic = paye.Basic;
            newPayE.Housing = paye.Housing;
            newPayE.Transport = paye.Transport;
            newPayE.Lunch = paye.Lunch;
            newPayE.Utility = paye.Utility;
            newPayE.Others = paye.Others;
            newPayE.LoanDeduct = paye.LoanDeduct;
            newPayE.PenaltyDeduct = paye.PenaltyDeduct;
            newPayE.Pension = paye.Pension;
            newPayE.NationalHFC = paye.NationalHFC;
            newPayE.ConsolidatedR = paye.ConsolidatedR;
            newPayE.Date = DateTime.Now;
            newPayE.NetTIncome = paye.NetTIncome;
            newPayE.GrossSalary = paye.GrossSalary;
            newPayE.TDeduction = paye.TDeduction;
            newPayE.TNonTDeduction = paye.TNonTDeduction;
            newPayE.CalPayE = paye.CalPayE;
            db.PayE.Add(newPayE);
            db.SaveChanges();
        }
    }
}