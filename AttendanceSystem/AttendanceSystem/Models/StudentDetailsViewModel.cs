using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceSystem.Models
{
    public class StudentDetailsViewModel
    {
        public List<string> StudentNames { get; set; }
        public List<DateTime> AttendTimes { get; set; }
        public List<DateTime?> LeaveTimes { get; set; }

        public int LateTimes { get; set; }
        public Student studinfo { get; set; }
        public ApplicationUser userInfo { get; set; }
        public Attendance attInfo { get; set; }
        public Department depInfo { get; set; }
        public DateTime? day { get; set; }
    }
}