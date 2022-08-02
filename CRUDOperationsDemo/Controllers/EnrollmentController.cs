using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class EnrollmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
