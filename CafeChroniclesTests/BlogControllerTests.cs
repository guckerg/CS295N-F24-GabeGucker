using Microsoft.AspNetCore.Mvc;
using GGinfoSite.Data;
using GGinfoSite.Controllers;
using GGinfoSite.Models;

namespace CafeChroniclesTests
{
    public class BlogControllerTests
    {
        IBlogPostRepository _repo = new FakeBlogPostRepository();
        BlogController _controller;
        BlogPost _blogPost = new BlogPost();

        public BlogControllerTests()
        {
            _controller = new BlogController(_repo);
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
