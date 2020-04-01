using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackingFrontEnd.Models
{
    public class EmployeeModel
    {
        public int UserId { get; set; }
        public string NameOfEmployee { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool Active { get; set; }
    }
}
