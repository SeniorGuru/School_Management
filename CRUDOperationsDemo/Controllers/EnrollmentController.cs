using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public EnrollmentController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {

            EnrollmentViewModel item = new EnrollmentViewModel();
            item.users = _context.users;
            item.subjects = _context.subjects;
            item.enrolls = _context.enrolls;

            return View(item);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Enrollment std)
        {
            bool flag = false;
            foreach(var item in _context.enrolls)
            {
                if(item.Student == std.Student && item.Subject == std.Subject)
                {
                    flag = true;
                }
            }

            if(!flag)
            {
                _context.enrolls.Add(std);
                _context.SaveChanges();
            }

            return Json(1);
        }

        public ActionResult Delete([FromBody] Enrollment std)
        {
            var result = _context.enrolls.Find(std.Id);
            if (result != null)
            {
                _context.enrolls.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
        }
}