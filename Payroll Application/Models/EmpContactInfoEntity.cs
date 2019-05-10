using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblEmpContactInfo")]
    public class EmpContactInfoEntity
    {
        public long RegistrationID { get; set; }
        public string StaffNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string MobileNo { get; set; }
        public string MobileNo2 { get; set; }
        public string WorkPhoneNo { get; set; }
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public long ID { get; set; }
    }
}