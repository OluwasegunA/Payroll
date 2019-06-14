using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblReference")]
    public class ReferenceEntity
    {
        public long RegistrationID { get; set; }
        public string RFullName { get; set; }
        public string RPhoneNo { get; set; }
        public string RAddress { get; set; }
        public string RCountry { get; set; }
        public string RState { get; set; }
        public string RJobPosition { get; set; }
        public long ID { get; set; }
    }
}