using System.Security.Cryptography.X509Certificates;

namespace GGinfoSite.Models
{
    public class BlogPost
    {
        public AppUser? Poster { get; set; }
        public string? PostTitle { get; set; }
        public string? PostText { get; set; }
        public DateTime PostTime { get; set; }
        public int PostRating { get; set; }
    }
}
