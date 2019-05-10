using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Payroll_Application.Models
{
    [Table("tblEmpEmployment")]
    public class EmpEmploymentEntity
    {
        public long RegistrationID { get; set; }
        public string Branch { get; set; }
        public DateTime DateJoined { get; set; }
        public string EmpLevel { get; set; }
        public DateTime DateStarted { get; set; }
        public string Designation { get; set; }
        public string EmploymentType { get; set; }
        public string Department { get; set; }
        public string JobDescription { get; set; }
        public long ID { get; set; }
    }
}