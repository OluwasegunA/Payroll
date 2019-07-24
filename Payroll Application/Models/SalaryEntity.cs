using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblSalary")]
    public class SalaryEntity
    {
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string BasicDescription { get; set; }
        public string BasicType { get; set; }
        public int BasicPer { get; set; }
        public string HousingDescription { get; set; }
        public string HousingType { get; set; }
        public int HousingPer { get; set; }
        public string TransportDescription { get; set; }
        public string TransportType { get; set; }
        public int TransportPer { get; set; }
        public string UtilityDescription { get; set; }
        public string UtilityType { get; set; }
        public int UtilityPer { get; set; }
        public string LunchDescription { get; set; }
        public string LunchType { get; set; }
        public int LunchPer { get; set; }
        public string OtherDescription { get; set; }
        public string OtherType { get; set; }
        public int OtherPer { get; set; }
        public string BasicAmt { get; set; }
        public string HousingAmt { get; set; }
        public string TransportAmt { get; set; }
        public string UtilityAmt { get; set; }
        public string LunchAmt { get; set; }
        public string OtherAmt { get; set; }
        public decimal Amount { get; set; }
        public int ID { get; set; }
    }
}