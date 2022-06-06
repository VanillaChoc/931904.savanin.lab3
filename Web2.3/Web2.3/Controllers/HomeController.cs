using Microsoft.AspNetCore.Mvc;

namespace Web2._3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}