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


namespace AttendanceSystem.Controllers
{
    [Authorize(Roles ="Students")]
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> Index()
        {  
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var context = new ApplicationDbContext();
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            var studInfo =await context.Student.SingleOrDefaultAsync(u => u.User_Id == currentUser.Id);
            var depInfo = await context.Deptartment.SingleOrDefaultAsync(u => u.deptID == studInfo.deptID);
            var attInfo = await context.Attendance.SingleOrDefaultAsync(u => u.stud_id == studInfo.St_Id);
            var query = (from att in context.Attendance
                         where att.stud_id == studInfo.St_Id && att.Late == true
                         select att.stud_id).Count();
            StudentDetailsViewModel std = new StudentDetailsViewModel { studinfo = studInfo, userInfo = currentUser, attInfo = attInfo,depInfo=depInfo,LateTimes=query };
          

            return View(std); 
        }

        [HttpPost]
        public async Task<ActionResult> Days(DateTime date)
        {
            var context = new ApplicationDbContext();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            var studInfo =  await context.Student.SingleOrDefaultAsync(u => u.User_Id == currentUser.Id);
            //var attThatDay = (from att in context.Attendance
            //                  where DbFunctions.TruncateTime(att.AttendTime) == DbFunctions.TruncateTime(date) && att.stud_id == studInfo.St_Id
            //                  select att.stud_id).ToList();
            var attd = await context.Attendance.FirstOrDefaultAsync(a => DbFunctions.TruncateTime(a.AttendTime) == DbFunctions.TruncateTime(date) && a.stud_id == studInfo.St_Id);
            if (attd != null)
            {
                if(attd.Late==true)
                {
                    attd.lateString = "Yes";
                }
                else
                {
                    attd.lateString = "No";
                }
                return PartialView(attd);

            }
            else
            {
                return Content("You didn't come That day");
            }
          

        }
    }
}