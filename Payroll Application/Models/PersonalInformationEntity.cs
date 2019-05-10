using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblPersonalInformation")]
    public class PersonalInformationEntity
    {
        public long RegistrationID { get; set; }
        public string StaffNo { get; set; }
        public int TitleCode { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public string Religion { get; set; }
        public string SpouseName { get; set; }
        public string Disability { get; set; }
        public string DisabilityDescription { get; set; }
        public string ImageUrl { get; set; }
        public string StaffStatus { get; set; }
        public long ID { get; set; }
    }
}