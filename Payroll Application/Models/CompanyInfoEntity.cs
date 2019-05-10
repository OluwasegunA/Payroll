using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblCompanyInfo")]
    public class CompanyInfoEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public int ID { get; set; }
    }
}