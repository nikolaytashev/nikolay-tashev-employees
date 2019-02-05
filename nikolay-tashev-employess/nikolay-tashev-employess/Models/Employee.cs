using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
