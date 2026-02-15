using Microsoft.AspNetCore.Mvc;
using One.MVC.Models;
using System.Diagnostics;

namespace One.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
            //return Ok("success");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return Ok("test");
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult TestTwo([FromRoute]int? id, [FromQuery] string name)
        {
            //return View();
            if(!id.HasValue)
            {
                return View();
            }

            if (!string.IsNullOrEmpty(name))
            {
                return Ok(new {name});
            }
            return new ContentResult { Content = id.ToString() };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
