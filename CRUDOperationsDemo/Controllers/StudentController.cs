using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using School.Models;

namespace CRUDOperationsDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public int weeks;
        public StudentController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(_context.users.OrderBy(item => item.FirstName).ToList());
        }

        public IActionResult Detail()
        {
            string Email = TempData["email"] as string;
            StudentPortalViewModel Viewdata = new StudentPortalViewModel();
            int studentId;
            string studentName;
            List<PointSystem> points = new List<PointSystem>();

            studentId = _context.users.SingleOrDefault(a => a.Email == Email).Id;
            studentName = _context.users.SingleOrDefault(a => a.Email == Email).FirstName + " " + _context.users.SingleOrDefault(a => a.Email == Email).LastName;
            Viewdata.Date = DateTime.Now.ToShortDateString();
            Viewdata.StudentName = studentName;

            foreach(var item in _context.semesters)
            {
                if(DateTime.Now > item.FromDate && DateTime.Now < item.EndDate)
                {
                    weeks = item.Weeks;
                }
            }
            foreach(var enroll in _context.enrolls)
            {

                if(enroll.Student == studentName)
                {
                    PointSystem point = new PointSystem();
                    point.StudentAbsenses = new List<StudentAbsense>();

                    point.Teacher = enroll.Teacher;
                    string subject = enroll.Subject;
                    int period = _context.subjects.SingleOrDefault(a => a.Name == subject).PeriodCount;

                    point.Allowed = period * weeks * 1;
                    point.SubjectName = subject;

                    foreach(var item in _context.studentAbsenses)
                    {
                        if(item.StudentId == studentId)
                        {
                            point.StudentAbsenses.Add(item);
                            switch (item.AbsenseType)
                            {
                                case 1:
                                    break;
                                case 2:
                                    point.Deducated -= 1;
                                    break;
                                case 3:
                                    point.Deducated -= 2;
                                    break;
                                case 4:
                                    point.Deducated -= 2;
                                    point.Missed++;
                                    break;
                            }
                        }
                    }

                    point.Deducated += 2 * point.Allowed;
                    points.Add(point);
                }
            }

            Viewdata.PointSystems = points;

            return View(Viewdata);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody]User std)
        {
            std.ClientId = _context.users.Count() + 1;
            std.Title = "student";
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
