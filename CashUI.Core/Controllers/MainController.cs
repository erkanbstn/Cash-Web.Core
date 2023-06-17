using Microsoft.AspNetCore.Mvc;

namespace CashUI.Core.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
