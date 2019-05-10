using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table ("tblEmpQualification")]
    public class EmpQualificationEntity
    {
        public long RegistrationID { get; set; }
        public string Institution { get; set; }
        public string EducationQua { get; set; }
        public string Year { get; set; }
        public bool IsDeleted { get; set; }
        public long ID { get; set; }
    }
}