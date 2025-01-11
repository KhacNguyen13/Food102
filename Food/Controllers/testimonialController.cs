using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers
{
    public class testimonialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
