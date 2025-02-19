using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Models;
using GGinfoSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GGinfoSite.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        IBlogPostRepository _repo;
        ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public CommentController(IBlogPostRepository r, ApplicationDbContext context, 
            UserManager<AppUser> userMnger)
        {
            _repo = r;
            _context = context;
            _userManager = userMnger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync(Comment model)
        {
            model.Poster = await _userManager.GetUserAsync(User);
            model.CommentTimeStamp = DateTime.Now;

            _repo.StoreComment(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentByIdAsync()
        {
            //add definition
            return View();
        }
    }
}
