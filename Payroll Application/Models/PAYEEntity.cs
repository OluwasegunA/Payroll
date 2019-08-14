using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblPAYE")]
    public class PAYEEntity
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string PayPeriod { get; set; }
        public string GrossSalary { get; set; }
        public string Basic { get; set; }
        public string Housing { get; set; }
        public string Utility { get; set; }
        public string Transport { get; set; }
        public string Others { get; set; }
        public string Lunch { get; set; }
        public string LoanDeduct { get; set; }
        public string PenaltyDeduct { get; set; }
        public string Pension { get; set; }
        public string NationalHFC { get; set; }
        public string ConsolidatedR { get; set; }
        public string TDeduction { get; set; }
        public string TNonTDeduction { get; set; }
        public string NetTIncome { get; set; }
        public string CalPayE { get; set; }
        public string NetSalary { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
    }
}