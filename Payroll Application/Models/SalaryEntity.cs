using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblSalary")]
    public class SalaryEntity
    {
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string AllowanceDescription1 { get; set; }
        public string AllowanceType1 { get; set; }
        public int AllowancePer1 { get; set; }
        public string AllowanceDescription2 { get; set; }
        public string AllowanceType2 { get; set; }
        public int AllowancePer2 { get; set; }
        public string AllowanceDescription3 { get; set; }
        public string AllowanceType3 { get; set; }
        public int AllowancePer3 { get; set; }
        public string AllowanceDescription4 { get; set; }
        public string AllowanceType4 { get; set; }
        public int AllowancePer4 { get; set; }
        public string AllowanceDescription5 { get; set; }
        public string AllowanceType5 { get; set; }
        public int AllowancePer5 { get; set; }
        public decimal Amount { get; set; }
        public int ID { get; set; }
    }
}