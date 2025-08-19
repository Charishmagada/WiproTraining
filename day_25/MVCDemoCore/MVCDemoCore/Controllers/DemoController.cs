using Microsoft.AspNetCore.Mvc;

namespace MVCDemoCore.Controllers
{
    public class DemoController : Controller
    {
        public string Index()
        {
            return "Welcome to ASP.NET Core Web MVC demo";
        }
        public string Aslesha()
        {
            return "Hi I am Aslesha from .NET Full Stack Batch";
        }

        public string Greeting()
        {
            int hr = DateTime.Now.Hour;
            if (hr < 12)
            {
                return "Good Morning";
            }
            if (hr >= 12 && hr < 16)
            {
                return "Good Afternoon";
            }
            if (hr >= 16)
            {
                return "Good Evening";
            }
            return "";
        }

        public string arya()
        {
            return "Hi I am Arya!";
        }
    }
}

