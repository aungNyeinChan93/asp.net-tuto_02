using Microsoft.AspNetCore.Mvc;

namespace One.MVC.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View("Home/NotFound");
        }
    }
}
