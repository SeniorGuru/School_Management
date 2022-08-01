using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public User[] teachers;
        public TeacherController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Edit()
        {
           
            return View(_context.Users.OrderBy(item => item.FirstName).ToList());
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeacher([FromBody] User std)
        {
            std.ClientId = _context.Users.Count() + 1;
            std.Title = "teacher";
            std.DateModified = DateTime.Now;
            std.DateCreated = DateTime.Now;
            _context.Users.Add(std);
            _context.SaveChanges();

            return Json(1);
        }

        public ActionResult Delete([FromBody] User std)
        {
            var result = _context.Users.Find(std.Id);
            if (result != null)
            {
                _context.Users.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
    }
}
