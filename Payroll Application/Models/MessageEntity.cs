using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Application.Models
{
    [Table("tblMessage")]
    public class MessageEntity
    {
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public bool Isread { get; set; }
        public string From_ID { get; set; }
        public string To_ID { get; set; }
        public string SenderName { get; set; }
        public string RecieverName { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
        public bool IsLoan { get; set; }
        public int ID { get; set; }
    }
}