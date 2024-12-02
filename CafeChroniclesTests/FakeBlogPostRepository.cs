using GGinfoSite.Data;
using GGinfoSite.Models;

public class FakeBlogPostRepository : IBlogPostRepository
{
    private List<BlogPost> blogPosts = new List<BlogPost>();

    public BlogPost GetBlogPostById(int id)
    {
        BlogPost blogPost = blogPosts.Find(bp => bp.BlogPostID == id);
        return blogPost;
    }

    public List<BlogPost> GetBlogPosts()
    {
        return blogPosts;
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