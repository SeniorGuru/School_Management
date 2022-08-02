using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class RecordLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
