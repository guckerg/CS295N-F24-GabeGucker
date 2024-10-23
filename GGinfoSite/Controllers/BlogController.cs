using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace GGinfoSite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            BlogPost model = new BlogPost();
            model.Poster = new AppUser();
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult TopPosts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TopPosts(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            return View("Index", model);
        }
    }
}
