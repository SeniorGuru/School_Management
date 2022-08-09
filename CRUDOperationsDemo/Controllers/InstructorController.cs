using CRUDOperationsDemo;
using CRUDOperationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System.Linq;

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

        public SchoolDbContext Get_context()
        {
            return _context;
        }

        public IActionResult Index(SchoolDbContext _context)
        {
            string teacherName = TempData["teacherName"] as string;

            InstructorViewModel instructor = new InstructorViewModel();
            instructor.subjects = new List<Subject>();
            instructor.tsubject = new List<Subject>();
            instructor.users = new List<User>();
            instructor.teacher = new User();

            List<User> users = new List<User>();
            List<Subject> tsubjects = new List<Subject>();

            instructor.subjects = _context.subjects;
            instructor.users = _context.users;

            if(teacherName == null)
            {
                instructor.teacher = _context.users.FirstOrDefault(a => a.Title == "teacher");
                teacherName = instructor.teacher.FirstName + " " + instructor.teacher.LastName;
            }
            foreach(var item in _context.enrolls)
            {
                if(item.Teacher == teacherName)
                {
                    Subject temp = new Subject();
                    temp.Name = item.Subject;
                    tsubjects.Add(temp);
                }
            }

            instructor.tsubject = (IEnumerable<Subject>)tsubjects;
            return View(instructor);
        }

    }
}
