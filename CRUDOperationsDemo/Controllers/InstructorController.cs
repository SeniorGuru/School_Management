using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
