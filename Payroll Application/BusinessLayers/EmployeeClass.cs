using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Payroll_Application.BusinessLayers;
using System.Configuration;

namespace Payroll_Application.BusinessLayers
{
    public class EmployeeClass
    {
        public static string conString = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString;
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
            MyDbContext db2 = new MyDbContext();
            var oldper = db.PersonalInfo.Where(d => d.RegistrationID == personal.RegistrationID).FirstOrDefault();
            var userInfo = db2.Users.FirstOrDefault();
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
            userInfo.OtherID = personal.StaffNo;
            userInfo.FullName = personal.Surname + " " + personal.FirstName;
            userInfo.Password = SecurityClass.Encrypt(personal.Surname);
            userInfo.UserRole = personal.StaffStatus;
            userInfo.Username = personal.FirstName;
            userInfo.UserID = personal.ID;
            userInfo.ImageUrl = personal.ImageUrl;
            db2.Users.Add(userInfo);
            db2.SaveChanges();
            db.SaveChanges();
        }

        //saving Contact information
        public static void SaveContact(EmpContactInfoEntity contact)
        {
            MyDbContext db = new MyDbContext();
            MyDbContext db2 = new MyDbContext();
            var oldCont = db.EmployeeContactInfo.Where(d => d.RegistrationID == contact.RegistrationID).FirstOrDefault();
            //var userInformation = db2.Users.Where(p => p.OtherID == contact.StaffNo).FirstOrDefault();
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
                oldCont.LGA = contact.LGA;
                oldCont.Landmark = contact.Landmark;

            }
            else
            {
                db.EmployeeContactInfo.Add(contact);

            }
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string sql = "Update tblUser set Email='" + contact.Email + "',PhoneNo='"+contact.MobileNo+"' where OtherID='" + contact.StaffNo + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

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
                oldNoF.Relationship = nextofKin.Relationship;
                oldNoF.Name = nextofKin.Name;
                oldNoF.Contact = nextofKin.Contact;

            }
            else
            {
                db.EmpNextofKin.Add(nextofKin);
            }
            db.EmpNextofKin.Add(nextofKin);
            db.SaveChanges();
        }
        // saving next of kin and guarantor information
        public static void SaveGuarantor(GurrantorEntity guarantor)
        {
            MyDbContext db = new MyDbContext();
            var oldNoF = db.EmpGurrantor.Where(d => d.RegistrationID == guarantor.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.GFullName = guarantor.GFullName;
                oldNoF.GPhoneNo = guarantor.GPhoneNo;
                oldNoF.GAddress = guarantor.GAddress;
                oldNoF.GCountry = guarantor.GCountry;
                oldNoF.GState = guarantor.GState;
                oldNoF.GPayLevel = guarantor.GPayLevel;

            }
            else
            {
                db.EmpGurrantor.Add(guarantor);
            }
            db.EmpGurrantor.Add(guarantor);
            db.SaveChanges();
        }
        // saving next of kin and guarantor information
        public static void SaveReference(ReferenceEntity reference)
        {
            MyDbContext db = new MyDbContext();
            var oldNoF = db.EmpReference.Where(d => d.RegistrationID == reference.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.RFullName = reference.RFullName;
                oldNoF.RPhoneNo = reference.RPhoneNo;
                oldNoF.RAddress = reference.RAddress;
                oldNoF.RCountry = reference.RCountry;
                oldNoF.RState = reference.RState;
                oldNoF.RJobPosition = reference.RJobPosition;
            }
            else
            {
                db.EmpReference.Add(reference);
            }
            db.EmpReference.Add(reference);
            db.SaveChanges();
        }
        //Saving Medical History
        public static void SaveMedicalHis(MedicalEntity history)
        {
            MyDbContext db = new MyDbContext();
            var oldMed = db.MedicalHistory.Where(r => r.RegistrationID == history.RegistrationID).FirstOrDefault();
            if (oldMed != null)
            {
                oldMed.BGroup = history.BGroup;
                oldMed.Genotype = history.Genotype;
                oldMed.Weight = history.Weight;
                oldMed.Height = history.Height;
                oldMed.Smoke = history.Smoke;
                oldMed.Drink = history.Drink;
                oldMed.Allergies = history.Allergies;
                oldMed.MedHistory = history.MedHistory;
                oldMed.Comments = history.Comments;
            }
            else
            {
                db.MedicalHistory.Add(history);
            }
            db.MedicalHistory.Add(history);
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