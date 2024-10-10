using Microsoft.AspNetCore.Mvc;

namespace GGinfoSite.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }
    }
}
