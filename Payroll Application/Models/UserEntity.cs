using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{
    [Table("tblUser")]
    public class UserEntity
    {
        public string Username { get; set; }
        public long UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string Department { get; set; }
        public string OtherID { get; set; }
        public string ImageUrl { get; set; }
        public long ID { get; set; }
    }
}