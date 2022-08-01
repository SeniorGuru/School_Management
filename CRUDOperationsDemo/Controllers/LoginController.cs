using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;

namespace School.Controllers
{
    public class LoginController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public LoginController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromBody]User std)
        {
            int type = 0;
            foreach(var item in _context.Users)
            {
                if (item.Email == std.Email)
                {
                    if(item.Title == "student")
                        type = 1;
                    if (item.Title == "teacher")
                        type = 2;
                    if (item.Title == "admin")
                        type = 3;
                }
            }
            return Json(type);
        }
    }
}
