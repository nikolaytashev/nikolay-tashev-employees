using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Models
{
    public class EmployeesWorkingPair
    {
        public int FirstEmployeeID { get; set; }
        public int SecondEmployeeID { get; set; }
        public int ProjectID { get; set; }
        public int DaysWorked { get; set; }
    }
}
