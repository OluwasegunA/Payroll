using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblBranch")]
    public class BranchEntity
    {
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public int ID { get; set; }
    }
}