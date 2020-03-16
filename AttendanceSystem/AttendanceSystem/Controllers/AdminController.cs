using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AttendanceSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
namespace AttendanceSystem.Controllers
{[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            var context = new ApplicationDbContext();
            var StudentsListBox = new StudentViewModel();
            ViewBag.Deps = new SelectList(context.Deptartment.ToList(),"deptID", "deptName");

            return View();
        }
      
        public ActionResult Dep(StudentViewModel model)
        {
            var context = new ApplicationDbContext();
            ViewBag.Deps = new SelectList(context.Deptartment.ToList(), "deptID", "deptName");
            var query = from st in context.Student
                        where st.deptID == model.depID
                        select st.FullName;
            StudentViewModel mod = new StudentViewModel { Students = query.ToList(), depID = model.depID };
            return PartialView(mod);
            
        }
        [HttpGet]
        public ActionResult Attended(int dep)
        {
            var context = new ApplicationDbContext();



            var query = from st in context.Student
                        join att in context.Attendance on st.St_Id equals att.stud_id
                        where st.deptID == dep
                        select st.FullName;

            StudentViewModel att_st = new StudentViewModel() { AttendedStudents = query.ToList() };

            return PartialView(att_st);
        }

        [HttpPost]
        public async Task<ActionResult> Attended(StudentViewModel model)
        {   var dateNow = DateTime.Now;
            var context = new ApplicationDbContext();
            bool LateComer=false;
            DateTime LateDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 9, 0, 0);
            var student = await context.Student.FirstOrDefaultAsync(a => a.FullName == model.selectedStudent);
            if(dateNow>LateDate)
            {
                LateComer = true;
            }
            if(context.Attendance.FirstOrDefault(a=>a.stud_id==student.St_Id)!=null)
            {
                return Content("Already Registered " + student.FullName);

            }
            else
            {


                Attendance newAtt = new Attendance()
                {
                    stud_id = student.St_Id,
                    AttendTime = DateTime.Now,
                    Late = LateComer
                  
                };
                context.Attendance.Add(newAtt);
                context.SaveChanges();
                var query = from st in context.Student
                            join att in context.Attendance on st.St_Id equals att.stud_id
                            select st.FullName;

                StudentViewModel att_st = new StudentViewModel() { AttendedStudents = query.ToList() };

                return Content("Registered " + student.FullName);
            }
         
        }
        [HttpPost]
        public ActionResult DateDetails(DateTime date,string dep)
        {
            var context = new ApplicationDbContext();

            var query = from att in context.Attendance
                        join st in context.Student on att.stud_id equals st.St_Id
                        join dp in context.Deptartment on st.deptID equals dp.deptID
                        where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date) && dp.deptName == dep
                        select st.FullName;

            var query2 = from att in context.Attendance
                         join st in context.Student on att.stud_id equals st.St_Id
                         join dp in context.Deptartment on st.deptID equals dp.deptID
                         where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date) && dp.deptName == dep
                         select att.AttendTime;
            var query3 = from att in context.Attendance
                         join st in context.Student on att.stud_id equals st.St_Id
                         join dp in context.Deptartment on st.deptID equals dp.deptID
                         where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date) && dp.deptName == dep
                         select att.LeaveTime;

            //var query2 = from att in context.Attendance
            //             where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date)
            //             select att.AttendTime;
            //var query3 = from att in context.Attendance
            //             where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date)
            //             select att.LeaveTime;

            StudentDetailsViewModel std = new StudentDetailsViewModel() { StudentNames = query.ToList(), AttendTimes = query2.ToList(), LeaveTimes = query3.ToList() };



            return PartialView(std);
        }
       [HttpPost]
        public async Task<ActionResult>Details(string stname)
        {
            var context = new ApplicationDbContext();
            var student = await context.Student.FirstOrDefaultAsync(a => a.FullName ==stname);
            var details = await context.Attendance.FirstOrDefaultAsync(a => a.stud_id == student.St_Id);


            return PartialView(details);
        }
        public async Task<ActionResult>Departure(StudentViewModel model)
        {
            var context = new ApplicationDbContext();
            var student = await context.Student.FirstOrDefaultAsync(a => a.FullName == model.selectedStudent);
            var leavingStudent = await context.Attendance.FirstOrDefaultAsync(a => a.stud_id == student.St_Id);
            if(leavingStudent.LeaveTime==null)
            {
                leavingStudent.LeaveTime = DateTime.Now;
                context.SaveChanges();
            }
            else
            {
                return Content("Already Departed " + student.FullName);
            }




            return Content("Successfully Departed "+student.FullName);
            
        }

    }
}