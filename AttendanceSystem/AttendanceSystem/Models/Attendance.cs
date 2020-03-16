using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AttendanceSystem.Models
{
    public class Attendance
    {   
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        [Index(IsUnique =true)]
        public int stud_id { get; set; }
        public Student Student { get; set; }
     
        public DateTime AttendTime { get; set; }

 
        public DateTime? LeaveTime { get; set; }
        public bool Late { get; set; }
        [NotMapped]
        public string lateString { get; set; }

    }
}