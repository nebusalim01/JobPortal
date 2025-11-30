using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class AddApplication
    {
        public string JobTitle { set; get; }
        public string ComName { set; get; }
        public string JobDes { set; get; }
        public string Location { set; get; }
        public string Salary { set; get; }
        public string Resume { set; get; }
        public DateTime Date { set; get; }
        public string Msg { set; get; }
    }
}