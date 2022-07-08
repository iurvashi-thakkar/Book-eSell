using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
