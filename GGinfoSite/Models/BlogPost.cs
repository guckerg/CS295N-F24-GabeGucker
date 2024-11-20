using System.Security.Cryptography.X509Certificates;

namespace GGinfoSite.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public AppUser? Poster { get; set; }
        public string? PostTitle { get; set; }
        public string? PostText { get; set; }
        public DateTime PostTime { get; set; }
        public int PostRating { get; set; }

        public BlogPost()
        {
            PostTitle = "Default Title";
            PostText = "Default Text";
            PostRating = 0;
            PostTime = DateTime.Now;
            Poster = new AppUser { Name = "unknown" };
        }
    }
}
