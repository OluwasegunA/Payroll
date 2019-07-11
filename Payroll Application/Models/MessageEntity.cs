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
        public int From_ID { get; set; }
        public int To_ID { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string StaffID { get; set; }
        public int ID { get; set; }
    }
}