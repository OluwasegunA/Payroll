using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Payroll_Application.BusinessLayers;
using Payroll_Application.ViewModel;

namespace Payroll_Application.Controllers
{
    public class EmployeeController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // GET: Employee
        public ActionResult RegisterEmployee()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult EmployeeSearch()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //populate staff
        [HttpGet]
        public ActionResult GetStates(string CountryName)
        {
            var model = db.States.Where(d => d.CountryName == CountryName).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Upload Image
        [HttpPost]
        public ActionResult UploadEmployeePhoto()
        {
            string _imgname = string.Empty, realImageUrl = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~/EmployeeImages/") + _imgname + _ext;
                    _imgname = _imgname + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);
                    realImageUrl = "~/EmployeeImages/" + Convert.ToString(_imgname);
                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                    {
                        img.Resize(200, 180);
                        img.Save(_comPath);
                        realImageUrl = "~/EmployeeImages/" + Convert.ToString(_imgname);
                    }

                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        //Upload Attachment
        [HttpPost]
        public ActionResult UploadEmployeeAttachment()
        {
            string FileName = "";
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string fname;
                if (Request.Browser.Browser.ToUpper()== "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER"){
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                    FileName = file.FileName;
                }
                fname = Path.Combine(Server.MapPath("~/Attachment/"), Convert.ToString(fname));
                file.SaveAs(fname);
            }
            return Json(Convert.ToString(FileName), JsonRequestBehavior.AllowGet);
        }
        //Saving Attachment fileUrl
        [HttpPost]
        public ActionResult SaveUrl(AttachmentEntity attachment)
        {
            MyDbContext db = new MyDbContext();
            var oldAtt = db.Attachments.Where(d => d.RegistrationID == attachment.RegistrationID).FirstOrDefault();
            bool check = false; string desc = "";
            try
            {
                if (oldAtt != null)
                {
                    oldAtt.FileUrl = attachment.FileUrl;
                }
                else
                {
                    db.Attachments.Add(attachment);
                }
                db.Attachments.Add(attachment);
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

        //save the Staff Prefix
        [HttpPost]
        public JsonResult SavePrefix(string prefix)
        {
            bool check = false;
            try
            {
                var staffprefix = db.StaffPrefix.FirstOrDefault();
                if (staffprefix != null)
                {
                    staffprefix.Prefix = prefix;
                }
                else
                {
                    PrefixEntity p = new PrefixEntity();
                    p.Prefix = prefix;
                    db.StaffPrefix.Add(p);
                }
                db.SaveChanges();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return new JsonResult { Data = new { status = check } };
        }
        //load the prefix
        [HttpGet]
        public ActionResult GetPrefixNo()
        {
            var data = db.StaffPrefix.FirstOrDefault();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        class RegistrationPara
        {
            public string StaffNo { get; set; }
            public long RegistrationID { get; set; }
        }
        //Get the RegistrationNo
        [HttpGet]
        public ActionResult GetRegistrationNo()
        {
            RegistrationPara para = new RegistrationPara();
            try
            {
                
                string pref = EmployeeClass.GetStaffPrefixNo();
                long RegNo = DataClass.GetNextDocumentNo("Registration Number", 1000);
                string staffNo = pref + RegNo.ToString();
                para.RegistrationID = RegNo;
                para.StaffNo = staffNo;
            }
            catch (Exception ex)
            {

            }
            return Json(para, JsonRequestBehavior.AllowGet);
        }
       //save personal Information
       [HttpPost]
       public ActionResult SavePersonalInformation(PersonalInformationEntity personal)
        {
            bool check = false;string desc = "";
            try
            {
                EmployeeClass.SavePersonalInformation(personal);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new {status=check,Desc=desc } };
        }

        //saving contact information
        [HttpPost]
        public ActionResult SaveEmployeeContactInformation(EmpContactInfoEntity contact)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveContact(contact);
                
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //saving nextofkin and guarantor
        [HttpPost]
        public ActionResult SaveEmployeeNextofKinInformation(NextofKinEntity nextofKin)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveNoKin(nextofKin);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        //saving guarantor
        [HttpPost]
        public ActionResult SaveGuarantorInformation(GurrantorEntity guarantor)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveGuarantor(guarantor);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        //Saving MedicalHistory
        [HttpPost]
        public ActionResult SaveMedicalHistory(MedicalEntity history)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveMedicalHis(history);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        //saving Reference
        [HttpPost]
        public ActionResult SaveReferenceInformation(ReferenceEntity reference)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveReference(reference);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        // Saving employment information
        [HttpPost]
        public ActionResult SaveEmployeeEmploymentInfo(EmpEmploymentEntity employment)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveEmp(employment);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        //Saving Qualification
        [HttpPost]
        public ActionResult SaveEmployeeQualificaton(EmpQualificationEntity qualification)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveEmpQua(qualification);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }
        //Load Qualification information
        public ActionResult LoadQualificationInfo(int RegistID)
        {
            var Model = db.EmpQualifications.Where(d => d.IsDeleted == false && d.RegistrationID == RegistID).OrderBy(d => d.Institution).ToList();
            return PartialView("PartialQualificationList", Model);
        }

        [HttpGet]
        public ActionResult GetQuaData(int Id)
        {
            var experi = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
            return Json(experi, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteQualification(int Id)
        {
            bool isDeleted = false;
            try
            {
                EmployeeClass.deleteQuaification(Id);
                isDeleted = true;
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return Json(isDeleted);
        }

        //Saving Experience
        [HttpPost]
        public ActionResult SaveEmployeeExperience(EmpExperienceEntity experience)
        {
            bool check = false; string desc = "";
            try
            {
                EmployeeClass.SaveEmpExp(experience);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                desc = ex.Message;
            }
            return new JsonResult { Data = new { status = check, Desc = desc } };
        }

        //Load experience information
        public ActionResult LoadExpInfo(int RegistID)
        {
            var Model = db.EmpExperiences.Where(d => d.IsDeleted == false && d.RegistrationID == RegistID).OrderBy(d => d.CompName).ToList();
            return PartialView("PartialExperienceList", Model);
        }

        [HttpGet]
        public ActionResult GetExperienceData(int Id)
        {
            var experi = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
            return Json(experi, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteExperience(int Id)
        {
            bool isDeleted = false;
            try
            {
                EmployeeClass.deleteExperience(Id);
                isDeleted = true;
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return Json(isDeleted);
        }

        //load employee list
        [HttpPost]
        public ActionResult StaffList()
        {
            MyDbContext db = new MyDbContext();
            var model = (from p in db.PersonalInfo join n in db.EmpNextofKin on p.RegistrationID equals n.RegistrationID
                         join e in db.EmpEmploymentInfo on p.RegistrationID equals e.RegistrationID
                         join x in db.EmpExperiences on p.RegistrationID equals x.RegistrationID
                         join q in db.EmpQualifications on p.RegistrationID equals q.RegistrationID
                         join g in db.EmpGurrantor on p.RegistrationID equals g.RegistrationID
                         join r in db.EmpReference on p.RegistrationID equals r.RegistrationID
                         join m in db.MedicalHistory on p.RegistrationID equals m.RegistrationID
                         join a in db.Attachments on p.RegistrationID equals a.RegistrationID
                         join c in db.EmployeeContactInfo on p.RegistrationID equals c.RegistrationID into t from rt in t.DefaultIfEmpty() orderby
                         p.Surname, p.FirstName, p.MiddleName  select new {
                             RegistrationID=p.RegistrationID,
                             Surname=p.Surname,
                             FirstName=p.FirstName,
                             MiddleName=p.MiddleName,
                             MobileNo=rt.MobileNo,
                             WorkNo=rt.WorkPhoneNo,
                             StaffNo=rt.StaffNo
                         }).ToList();
            List<EmployeeListRecord> Records = new List<EmployeeListRecord>();
            foreach(var d in model)
            {
                Records.Add(new EmployeeListRecord
                {
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    MobileNo = d.MobileNo,
                    RegistrationID = d.RegistrationID,
                    StaffNo = d.StaffNo,
                    Surname = d.Surname,
                    WorkNo = d.WorkNo
                });
            }
            return PartialView("PartialShowEmpRecord", Records);
        }

        [HttpPost]
        public ActionResult EmployeeListTa()
        {
            MyDbContext db = new MyDbContext();
            var model = (from p in db.PersonalInfo join c in db.EmployeeContactInfo on p.RegistrationID equals c.RegistrationID into w from jo in w
                         join e in db.EmpEmploymentInfo on p.RegistrationID equals e.RegistrationID into t
                         from rt in t.DefaultIfEmpty()
                         orderby p.Surname, p.FirstName, p.MiddleName
                         select new
                         {
                             RegistrationID = p.RegistrationID,
                             Surname = p.Surname,
                             FirstName = p.FirstName,
                             MiddleName = p.MiddleName,
                             Department = rt.Department,
                             MobileNo = jo.MobileNo,
                             WorkNo = jo.WorkPhoneNo,
                             StaffNo = jo.StaffNo
                         }).ToList();
            List<EmployList> Record = new List<EmployList>();
            foreach (var d in model)
            {
                Record.Add(new EmployList
                {
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    MobileNo = d.MobileNo,
                    Department = d.Department,
                    RegistrationID = d.RegistrationID,
                    StaffNo = d.StaffNo,
                    Surname = d.Surname,
                    WorkNo = d.WorkNo
                });
            }
            return PartialView("PartialEmployList", Record);
        }
    }
}