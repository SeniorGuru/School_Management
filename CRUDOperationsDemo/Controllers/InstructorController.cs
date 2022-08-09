using CRUDOperationsDemo;
using CRUDOperationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public InstructorController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            InstructorViewModel instructor = new InstructorViewModel();
            instructor.subjects = new List<Subject>();
            instructor.tsubject = new List<Subject>();
            instructor.users = new List<User>();
            instructor.teacher = new User();

            instructor.teacher = _context.users.FirstOrDefault(a => a.Title == "teacher");
            instructor.subjects = _context.subjects;
            instructor.users = _context.users;

            string teacherName = instructor.teacher.FirstName + " " + instructor.teacher.LastName;
            instructor.tsubject = _context.enrolls.SelectMany(a => a.Teacher == teacherName);
            return View(instructor);
        }

    }
}
