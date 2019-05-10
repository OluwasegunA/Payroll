using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblNextofKin")]
    public class NextofKinEntity
    {
        public long RegistrationID { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string GFullName { get; set; }
        public string GPhoneNo { get; set; }
        public string GAddress { get; set; }
        public string GCountry { get; set; }
        public string GState { get; set; }
        public long ID { get; set; }
    }
}