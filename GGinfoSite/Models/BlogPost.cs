using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GGinfoSite.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public AppUser? Poster { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? PostTitle { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [MinLength(10, ErrorMessage = "Content must be at least 10 characters.")]
        public string? PostText { get; set; }
        public DateTime PostTime { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public int PostRating { get; set; } //should remove
        public ICollection<Comment>? Comments { get; set; }
    }
}
