using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;

namespace CRUDOperationsDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public StudentController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Users.OrderBy(item => item.FirstName).ToList());
        }

        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent([FromBody]User std)
        {
            std.ClientId = _context.Users.Count() + 1;
            std.Title = "student";
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
