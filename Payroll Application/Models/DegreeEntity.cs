using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{   [Table("tblDegree")]
    public class DegreeEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
    }
}