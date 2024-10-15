using Microsoft.AspNetCore.Mvc;

namespace GGinfoSite.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
