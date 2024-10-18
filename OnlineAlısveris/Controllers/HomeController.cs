using Microsoft.AspNetCore.Mvc;

namespace OnlineAlısveris.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
