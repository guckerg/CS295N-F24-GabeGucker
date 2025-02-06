using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Data;
using GGinfoSite.Controllers;
using GGinfoSite.Models;
using Microsoft.AspNetCore.Identity;

namespace CafeChroniclesTests
{
    public class BlogControllerTests
    {
        private readonly BlogController _controller;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public BlogControllerTests()
        {
            var testUserManager = _userManager;
            var testSignInManager = _signInManager;
            _controller = new BlogController(_userManager, _signInManager, _repo);
        }


        [Fact]
        public void Blog_PostTest_Success()
        {
            // arrange: done in the constructor

            // act
            _blogPost.Poster = new AppUser();
            var result = _controller.BlogPost(new BlogPost());

            // assert: check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }


        [Fact]
        public void Blog_PostTest_Failure()
        {
            // arrange: done in the constructor

            // act
            var result = _controller.BlogPost(_blogPost);

            // assert: check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}
