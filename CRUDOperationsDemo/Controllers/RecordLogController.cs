using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class RecordLogController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public RecordLogController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
