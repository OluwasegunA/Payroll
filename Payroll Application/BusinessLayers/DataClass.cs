using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Payroll_Application.BusinessLayers
{
    public class DataClass
    {
       
        //get next No of Document
        public static long GetNextDocumentNo(string description, long startNo)
        {
            long No = 0;
            MyDbContext db = new Models.MyDbContext();
            var data = db.StartDocumentNo.Where(d => d.Description == description).FirstOrDefault();
            if (data != null)
            {
                No = data.StartNo;
                No++;
                data.StartNo = No;
            }
            else
            {
                No = startNo;
                No++;
                StartDocumentNoEntity sdoc = new Models.StartDocumentNoEntity();
                sdoc.Description = description;
                sdoc.StartNo = No;
                db.StartDocumentNo.Add(sdoc);
            }
            db.SaveChanges();
            return No;
        }
    }
}