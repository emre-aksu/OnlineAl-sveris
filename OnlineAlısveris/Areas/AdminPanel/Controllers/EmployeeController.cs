using Microsoft.AspNetCore.Mvc;
using OnlineAlısveris.Areas.AdminPanel.Filters;

namespace OnlineAlısveris.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
