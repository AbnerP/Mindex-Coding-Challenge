using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class ReportingStructure
    {
        public Employee ParentEmployee { get; set; }
        public int NumberOfReports { get; set; }
    }
}
