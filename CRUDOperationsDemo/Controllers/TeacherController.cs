using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;

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
            foreach (var item in _context.Users)
            {
                if (item.Title == "teacher")
                {
                    teachers.Add(item);
                }
            }
            if (teachers != null)
                return View(teachers.OrderBy(item => item.FirstName).ToList());
            else
                return View();
        }
        public IActionResult Detail(string Email)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromBody] User std)
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
