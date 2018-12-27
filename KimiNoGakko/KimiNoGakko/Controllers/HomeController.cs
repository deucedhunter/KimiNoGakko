using Microsoft.AspNetCore.Mvc;

namespace KimiNoGakko.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
