using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Payroll_Application.Models
{
    [Table("tblEmpExperience")]
    public class EmpExperienceEntity
    {
        public long RegistrationID { get; set; }
        public string CompName { get; set; }
        public string JobPosition { get; set; }
        public DateTime DJoined { get; set; }
        public DateTime DLeft { get; set; }
        public bool IsDeleted { get; set; }
        public long ID { get; set; }
    }
}