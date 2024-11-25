using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using GGinfoSite.Data;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BlogPost> blogPosts = _context.BlogPost.Include(bp => bp.Poster).ToList();
            return View(blogPosts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult BlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogPost(BlogPost model)
        {
            model.PostTime = DateTime.Now;
            return View("Index", model);
        }
    }
}
