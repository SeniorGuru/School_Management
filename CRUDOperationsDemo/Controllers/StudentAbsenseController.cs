using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class StudentAbsenseController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public StudentAbsenseController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [HttpPost]
        public ActionResult CreateAbsense([FromBody] StudentAbsense std)
        {
            std.AuditDate = DateTime.Now;
            bool flag = false;
            foreach (var item in _context.studentAbsenses)
            {
                if (item.StudentId == std.StudentId && item.Subject == std.Subject || item.Teacher == std.Teacher)
                {
                    flag = true;
                }
            }

            if (flag == false)
            {
                _context.studentAbsenses.Add(std);
                _context.SaveChanges();
            }

            return Json(1);
        }
    }
}
