using Microsoft.AspNetCore.Mvc;
using OnlineAlısveris.Areas.AdminPanel.Filters;

namespace OnlineAlısveris.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
