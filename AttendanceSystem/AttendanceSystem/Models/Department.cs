using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceSystem.Models
{
    public class Department
    {
        [Key]
        public int deptID { get; set; }
        public string deptName { get; set; }
        
     
    }
}