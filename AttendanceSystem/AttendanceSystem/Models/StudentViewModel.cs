using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceSystem.Models
{
    public class StudentViewModel
    {
        public string selectedStudent { get; set; }
        public List<String> Students { get; set; }
        public int depID { get; set; }
        public List<String> AttendedStudents { get; set; }
        public string detailsStudent { get; set; }

    }

}