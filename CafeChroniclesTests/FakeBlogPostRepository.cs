using GGinfoSite.Data;
using GGinfoSite.Models;

public class FakeBlogPostRepository : IBlogPostRepository
{
    private List<BlogPost> blogPosts = new List<BlogPost>();

    public async Task<BlogPost> GetBlogPostByIdAsync(int id)
    {
        BlogPost blogPost = blogPosts.FirstOrDefault(bp => bp.BlogPostID == id);
        return await Task.FromResult(blogPost);
        //allows me to simulate async behavior in a fake repo
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync()
    {
        return await Task.FromResult(blogPosts);
        /*
         * simulating async behavior, as this method
         * fetches a list in the real repository
        */
    }

    public int StoreBlogPost(BlogPost model)
    {
        int status = 0;
        if (model != null)
        {
            model.BlogPostID = blogPosts.Count + 1;
            blogPosts.Add(model);
            status = 1;
        }
        return status;
    }
}