using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblPension")]
    public class PensionEntity
    {
        public long Code { get; set; }
        public string Description { get; set; }
        public string EmployeePer { get; set; }
        public string EmployerPer { get; set; }
        public int ID { get; set; }
    }
}