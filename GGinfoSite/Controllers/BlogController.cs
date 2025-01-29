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
        //private instance variable
        IBlogPostRepository repo;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        //constructor
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

        public IActionResult BlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogPost(BlogPost model)
        {
            //get appuser object for the current user via Identity
            model.Poster = userManager.GetUserAsync(User).Result;

            //TODO: modify register code to get user's name
            
            model.PostTime = DateTime.Now;

            //Store model in database
            repo.StoreBlogPost(model);
            return View(model);
        }
    }
}
