using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;
using School.Models;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public List<User> teachers = new List<User>();
        public TeacherController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Edit()
        {

            if (teachers != null)
                return View(teachers.OrderBy(item => item.FirstName).ToList());
            else
                return View();
        }
        public IActionResult Detail()
        {
            string Email = TempData["email"] as string;

            TeacherViewModel Viewitem = new TeacherViewModel();
            List<string> studentNames = new List<string>();
            List<User> users = new List<User>();

            string subject = "";
            int teacherId = 0;
            int subjectId = 0;

            Viewitem.name = _context.users.SingleOrDefault(a => a.Email == Email).FirstName+ " "+ _context.users.SingleOrDefault(a => a.Email == Email).LastName;
            teacherId = _context.users.SingleOrDefault(a => a.Email == Email).Id;
            subjectId = _context.semesterTeacherSubjects.SingleOrDefault(a => a.TeacherId == teacherId).SubjectId;
            Viewitem.period = _context.subjects.SingleOrDefault(a => a.Id == subjectId).PeriodCount;
            subject = _context.subjects.SingleOrDefault(a => a.Id == subjectId).Name;

            foreach (var item in _context.enrolls)
            {
                if(item.Teacher == Viewitem.name)
                {
                    studentNames.Add(item.Student);
                }
            }

            foreach(var item in studentNames)
            {
                foreach(var st in _context.users)
                {
                    string fullName = st.FirstName + " " + st.LastName;
                    if(fullName == item)
                    {
                        users.Add(st);
                    }
                }
            }
               
            Viewitem.date = DateTime.Today.ToShortDateString();
            Viewitem.students = users;
            Viewitem.subject = subject;

            return View(Viewitem);
        }

        [HttpPost]
        public ActionResult Create([FromBody] User std)
        {
            std.ClientId = _context.users.Count() + 1;
            std.Title = "teacher";
            std.DateModified = DateTime.Now;
            std.DateCreated = DateTime.Now;
            _context.users.Add(std);
            _context.SaveChanges();

            return Json(1);
        }


        public ActionResult Delete([FromBody] User std)
        {
            var result = _context.users.Find(std.Id);
            if (result != null)
            {
                _context.users.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
    }
}
