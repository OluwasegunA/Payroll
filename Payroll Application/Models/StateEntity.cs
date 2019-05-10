using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{   
    [Table("tblState")]
    public class StateEntity
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int ID { get; set; }
    }
}