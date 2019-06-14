using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblGurrantor")]
    public class GurrantorEntity
    {
        public long RegistrationID { get; set; }
        public string GFullName { get; set; }
        public string GPhoneNo { get; set; }
        public string GAddress { get; set; }
        public string GCountry { get; set; }
        public string GState { get; set; }
        public string GPayLevel { get; set; }
        public long ID { get; set; }
    }
}