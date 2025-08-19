using Microsoft.AspNetCore.Mvc;

namespace MVCDemoCore.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Topic = "Dotnet Core";
            ViewBag.Venue = "Online Training";
            return View();
        }

        public ActionResult Module2()
        {
            ViewBag.Content = "Winforms, Entity Framework, WPF";
            return View();
        }

        public ActionResult Module3()
        {
            ViewBag.Content = "WCF, ASP.NET and MVC";
            return View();
        }

    }
}

