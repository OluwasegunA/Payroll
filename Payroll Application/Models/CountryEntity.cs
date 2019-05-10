using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payroll_Application.Models
{   
    [Table("tblCountry")]
    public class CountryEntity
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}