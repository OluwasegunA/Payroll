using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblLoan")]
    public class LoanEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string MinPay { get; set; }
        public string MaxPay { get; set; }
        public int ID { get; set; }
    }
}