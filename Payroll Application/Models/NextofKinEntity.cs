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
        public string Relationship { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public long ID { get; set; }
    }
}