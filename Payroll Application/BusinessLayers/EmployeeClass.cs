﻿using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.BusinessLayers
{
    public class EmployeeClass
    {
       
        //get Prefix
        public static string GetStaffPrefixNo()
        {
            string strRef = "";
            MyDbContext db = new MyDbContext();
            var pref = db.StaffPrefix.FirstOrDefault();
            if (pref != null)
            {
                strRef = pref.Prefix;
            }
            return strRef;
        }

        //saving personal information
        public static void SavePersonalInformation(PersonalInformationEntity personal)
        {
            MyDbContext db = new MyDbContext();
            var oldper = db.PersonalInfo.Where(d => d.RegistrationID == personal.RegistrationID).FirstOrDefault();
            if (oldper != null)
            {
                oldper.DateofBirth = personal.DateofBirth;
                oldper.Disability = personal.Disability;
                oldper.DisabilityDescription = personal.DisabilityDescription;
                oldper.FirstName = personal.FirstName;
                oldper.Gender = personal.Gender;
                oldper.ImageUrl = personal.ImageUrl;
                oldper.MaritalStatus = personal.MaritalStatus;
                oldper.MiddleName = personal.MiddleName;
                oldper.Nationality = personal.Nationality;
                oldper.Religion = personal.Religion;
                oldper.SpouseName = personal.SpouseName;
                oldper.State = personal.State;
                oldper.Surname = personal.State;
                oldper.TitleCode = personal.TitleCode;
               
            }
            else
            {
                db.PersonalInfo.Add(personal);
                
            }
            db.SaveChanges();
        }

        //saving Contact information
        public static void SaveContact(EmpContactInfoEntity contact)
        {
            MyDbContext db = new MyDbContext();
            var oldCont = db.EmployeeContactInfo.Where(d => d.RegistrationID == contact.RegistrationID).FirstOrDefault();
            if (oldCont != null)
            {
                oldCont.Address = contact.Address;
                oldCont.City = contact.City;
                oldCont.Country = contact.Country;
                oldCont.Email = contact.Email;
                oldCont.MobileNo = contact.MobileNo;
                oldCont.MobileNo2 = contact.MobileNo2;
                oldCont.State = contact.State;
                oldCont.WorkEmail = contact.WorkEmail;
                oldCont.WorkPhoneNo = contact.WorkPhoneNo;
                
            }
            else
            {
                db.EmployeeContactInfo.Add(contact);
            }
            db.SaveChanges();
        }

        // saving next of kin and guarantor information
        public static void SaveNoKin(NextofKinEntity nextofKin)
        {
            MyDbContext db = new MyDbContext();
            var oldNoF = db.EmpNextofKin.Where(d => d.RegistrationID == nextofKin.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.FullName = nextofKin.FullName;
                oldNoF.PhoneNo = nextofKin.PhoneNo;
                oldNoF.Address = nextofKin.Address;
                oldNoF.Country = nextofKin.Country;
                oldNoF.State = nextofKin.State;
                oldNoF.GFullName = nextofKin.GFullName;
                oldNoF.GPhoneNo = nextofKin.GPhoneNo;
                oldNoF.GAddress = nextofKin.GAddress;
                oldNoF.GCountry = nextofKin.GCountry;
                oldNoF.GState = nextofKin.GState;

            }
            else
            {
                db.EmpNextofKin.Add(nextofKin);
            }
            db.EmpNextofKin.Add(nextofKin);
            db.SaveChanges();
        }
        //Saving Employee Qualification
        public static void SaveEmpQua(EmpQualificationEntity qualification)
        {
            MyDbContext db = new MyDbContext();
            var oldEmpQua = db.EmpQualifications.Where(d => d.RegistrationID == qualification.RegistrationID).FirstOrDefault();
            if (oldEmpQua != null)
            {
                oldEmpQua.Institution = qualification.Institution;
                oldEmpQua.EducationQua = qualification.EducationQua;
                oldEmpQua.Year = qualification.Year;
            }
            else
            {
                db.EmpQualifications.Add(qualification);
            }
            db.EmpQualifications.Add(qualification);
            db.SaveChanges();
        }
        //Saving Employee Experience
        public static void SaveEmpExp(EmpExperienceEntity experience)
        {
            MyDbContext db = new MyDbContext();
            var oldEmpExp = db.EmpExperiences.Where(d => d.RegistrationID == experience.RegistrationID).FirstOrDefault();
            if (oldEmpExp != null)
            {
                oldEmpExp.CompName = experience.CompName;
                oldEmpExp.JobPosition = experience.JobPosition;
                oldEmpExp.DJoined = experience.DJoined;
                oldEmpExp.DLeft = experience.DLeft;
            }
            else
            {
                db.EmpExperiences.Add(experience);
            }
            db.EmpExperiences.Add(experience);
            db.SaveChanges();
        }
        //delete experience Info
        public static void deleteExperience(int Id)
        {
            MyDbContext db = new MyDbContext();
            bool check = false;
            var emp = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
            if (emp != null)
            {
                check = true;
            }
            var bra = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
            if (bra != null)
            {
                if (check)
                {
                    bra.IsDeleted = true;
                }
                else
                {
                    db.EmpExperiences.Remove(bra);
                }

            }
            db.SaveChanges();
        }
        //Deleting Qualification
        public static void deleteQuaification(int Id)
        {
            MyDbContext db = new MyDbContext();
            bool check = false;
            var emp = db.EmpQualifications.Where(d => d.ID == Id).FirstOrDefault();
            if (emp != null)
            {
                check = true;
            }
            var bra = db.EmpQualifications.Where(d => d.ID == Id).FirstOrDefault();
            if (bra != null)
            {
                if (check)
                {
                    bra.IsDeleted = true;
                }
                else
                {
                    db.EmpQualifications.Remove(bra);
                }

            }
            db.SaveChanges();
        }
        // Saving Employment Info
        public static void SaveEmp(EmpEmploymentEntity employment)
        {
            MyDbContext db = new MyDbContext();
            var oldEmpE = db.EmpEmploymentInfo.Where(d => d.RegistrationID == employment.RegistrationID).FirstOrDefault();
            if (oldEmpE != null)
            {
                oldEmpE.Branch = employment.Branch;
                oldEmpE.DateJoined = employment.DateJoined;
                oldEmpE.EmpLevel = employment.EmpLevel;
                oldEmpE.DateStarted = employment.DateStarted;
                oldEmpE.Designation = employment.Designation;
                oldEmpE.EmploymentType = employment.EmploymentType;
                oldEmpE.Department = employment.Department;
                oldEmpE.JobDescription = employment.JobDescription;
            }
            else
            {
                db.EmpEmploymentInfo.Add(employment);
            }
            db.EmpEmploymentInfo.Add(employment);
            db.SaveChanges();
        }
    }
}