using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.ViewModel
{
    public class EmployList
    {
        public long RegistrationID { get; set; }
        public string StaffNo { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string MobileNo { get; set; }
        public string WorkNo { get; set; }
    }
}