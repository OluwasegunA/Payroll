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
    }
}