using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblStaffLoan")]
    public class StaffLoanEntity
    {
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string NetSalary { get; set; }
        public string LoanType { get; set; }
        public decimal LoanAmount { get; set; }
        public int Interest { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public int Installment { get; set; }
        public decimal Repayment { get; set; }
        public bool Status { get; set; }
        public int ID { get; set; }
    }
}