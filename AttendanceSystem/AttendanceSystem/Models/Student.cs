using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AttendanceSystem.Models
{
    public class Student
    {   
        [Key]
        public int St_Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }
        [ForeignKey("Department")]
        public int deptID { get; set; }
        public Department Department { get; set; }
        public ApplicationUser User { get; set; }
        
        public string FullName { get; set; }
       
        
    }
}