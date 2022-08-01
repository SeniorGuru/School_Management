using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
