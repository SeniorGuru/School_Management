using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class SemesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
