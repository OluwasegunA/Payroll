using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblAllowance")]
    public class AllowanceEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string AllType { get; set; }
        public int Percentage { get; set; }
        public string Grade { get; set; }
        public string Period { get; set; }
        public int ID { get; set; }
    }
}