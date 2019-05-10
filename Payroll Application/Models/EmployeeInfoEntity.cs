using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblEmployeeInfo")]
    public class EmployeeInfoEntity
    {
        public string StaffNo { get; set; }
        public long RecordID { get; set; }
        public int BranchCode { get; set; }
        public DateTime DateJoined { get; set; }
        public string Grade { get; set; }
        public string Designation { get; set; }
        public string EmploymentType { get; set; }
        public int DeptCode { get; set; }
        public int SupervisorCode { get; set; }
        public string JobDescription { get; set; }
        public int ID { get; set; }
    }
}