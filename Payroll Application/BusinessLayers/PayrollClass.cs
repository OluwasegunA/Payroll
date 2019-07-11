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
                oldSalary.AllowanceDescription1 = salary.AllowanceDescription1;
                oldSalary.AllowanceDescription2 = salary.AllowanceDescription2;
                oldSalary.AllowanceDescription3 = salary.AllowanceDescription3;
                oldSalary.AllowanceDescription4 = salary.AllowanceDescription4;
                oldSalary.AllowanceDescription5 = salary.AllowanceDescription5;
                oldSalary.AllowanceType1 = salary.AllowanceType1;
                oldSalary.AllowanceType2 = salary.AllowanceType2;
                oldSalary.AllowanceType3 = salary.AllowanceType3;
                oldSalary.AllowanceType4 = salary.AllowanceType4;
                oldSalary.AllowanceType5 = salary.AllowanceType5;
                oldSalary.AllowancePer1 = salary.AllowancePer1;
                oldSalary.AllowancePer2 = salary.AllowancePer2;
                oldSalary.AllowancePer3 = salary.AllowancePer3;
                oldSalary.AllowancePer4 = salary.AllowancePer4;
                oldSalary.AllowancePer5 = salary.AllowancePer5;
                oldSalary.Amount = salary.Amount;
            db.Salaries.Add(salary);
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
    }
}