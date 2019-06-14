using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblAttachment")]
    public class AttachmentEntity
    {
        public long RegistrationID { get; set; }
        public string FileUrl { get; set; }
        public int ID { get; set; }
    }
}