using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.BusinessLayers
{
    public class SetupClass
    {
        //saving branch Information
        public static void SaveBranchInfo(BranchEntity bra)
        {
            
            MyDbContext db = new MyDbContext();
            var oldBra = db.Branches.Where(d => d.BranchCode == bra.BranchCode).FirstOrDefault();
            if (oldBra != null)
            {
                oldBra.Address = bra.Address;
                //oldBra.BranchCode = bra.BranchCode;
                oldBra.BranchName = bra.BranchName;
                oldBra.Email = bra.Email;
                oldBra.PhoneNo = bra.PhoneNo;
                
            }
            else
            {
                BranchEntity newBra = new BranchEntity();
                newBra.Address = bra.Address;
                newBra.BranchCode = bra.BranchCode;
                newBra.BranchName = bra.BranchName;
                newBra.Email = bra.Email;
                newBra.PhoneNo = bra.PhoneNo;
                db.Branches.Add(newBra);
            }
            db.SaveChanges();
          
        }
        //delete branch Info
        public static void deleteBranch(int BranchCode)
        {
            MyDbContext db = new MyDbContext();
            bool check = false;
            var emp = db.EmployeeInfo.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
            if (emp != null)
            {
                check = true;
            }
            var bra = db.Branches.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
            if (bra != null)
            {
                if (check)
                {
                    bra.IsDeleted = true;
                }
                else
                {
                    db.Branches.Remove(bra);
                }

            }
            db.SaveChanges();
        }

        //saving titles
        public static void SaveTitles(TitleEntity title)
        {
            MyDbContext db = new MyDbContext();
            var oldTitle = db.Titles.Where(d => d.Code == title.Code).FirstOrDefault();
            if (oldTitle == null)
            {
                TitleEntity newTitle = new TitleEntity();
                newTitle.Code = title.Code;
                newTitle.Description = title.Description;
                db.Titles.Add(newTitle);
                
            }
            else
            {
               // oldTitle.Code = title.Code;
                oldTitle.Description = title.Description;
                
            }
            db.SaveChanges();
        }

        //Save Levels
        public static void SaveLevels(LevelEntity level)
        {
            MyDbContext db = new MyDbContext();
            var oldLevel = db.Levels.Where(d => d.Code == level.Code).FirstOrDefault();
            if (oldLevel == null)
            {
                
                db.Levels.Add(level);
                
            }
            else
            {
                oldLevel.Description = level.Description;
            }
            db.SaveChanges();
        }
        //Save Employee Type
        public static void SaveEmpType(EmploymentTypeEntity emp)
        {
            MyDbContext db = new MyDbContext();
            var empType = db.EmployementType.Where(d => d.Code == emp.Code).FirstOrDefault();
            if (empType == null)
            {
                db.EmployementType.Add(emp);
                
            }
            else
            {
                empType.Description = emp.Description;
            }
            db.SaveChanges();
        }
        //Save Staff Dept
        public static void SaveDept(DepartmentEntity dept)
        {
            MyDbContext db = new MyDbContext();
            var oldDept = db.Depts.Where(d => d.DeptCode == dept.DeptCode).FirstOrDefault();
            if (oldDept == null)
            {
                db.Depts.Add(dept);
            }
            else
            {
                oldDept.Description = dept.Description;
            }
            db.SaveChanges();
        }

        //Save Designation
        public static void SaveDesignation(DesignationEntity Desg)
        {
            MyDbContext db = new MyDbContext();
            var oldDes = db.Designations.Where(d => d.Code == Desg.Code).FirstOrDefault();
            if (oldDes != null)
            {
                oldDes.Description = Desg.Description;
            }
            else
            {
                db.Designations.Add(Desg);
            }
            db.SaveChanges();
        }
        //Save Academic Degree
        public static void SaveDegrees(DegreeEntity Degree)
        {
            MyDbContext db = new MyDbContext();
            var OldDeg = db.Degrees.Where(d => d.Code == Degree.Code).FirstOrDefault();
            if (OldDeg != null)
            {
                OldDeg.Description = Degree.Description;
            }
            else
            {
                db.Degrees.Add(Degree);
            }
            db.SaveChanges();
        }
    }
}