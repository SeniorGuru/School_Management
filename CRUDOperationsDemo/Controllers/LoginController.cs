using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Login(User std)
        {
            int type = 0;
            foreach(var item in _context.Users)
            {
                if (item.Email == std.Email)
                {
                    if (item.Title == "student")
                    {
                        return RedirectToAction("Detail", "Student", std.Email);
                    }
                    if (item.Title == "teacher")
                    {
                        return RedirectToAction("Detail", "Teacher", std.Email);
                    }
                    if (item.Title == "admin")
                    {
                        type = 3;
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View("Index");
        }
    }
}
