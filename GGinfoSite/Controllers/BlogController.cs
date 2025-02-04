using GGinfoSite.Data;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GGinfoSite.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        IBlogPostRepository repo;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public BlogController(UserManager<AppUser> userMngr,
            SignInManager<AppUser> signInMngr, IBlogPostRepository r)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            repo = r;
        }
        
        public IActionResult Index()
        {
            var blogPosts = repo.GetBlogPosts();
            return View(blogPosts);
        }

        public IActionResult Filter(string poster, string date)
        {
            var blogPosts = repo.GetBlogPosts()
                .Where(b => b.Poster.UserName == poster || poster == null)
                .ToList();
            return View("Index", blogPosts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult BlogPost() //make async
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogPost(BlogPost model) //make async
        {
            model.Poster = userManager.GetUserAsync(User).Result;
            model.PostTime = DateTime.Now;

            repo.StoreBlogPost(model);
            return View(model);
        }
    }
}
