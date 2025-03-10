using System.ComponentModel.DataAnnotations;

namespace GGinfoSite.Models.ViewModels
{
    public class CommentVM
    {
        public int BlogPostID { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [MinLength(10, ErrorMessage = "Comment must be at least 10 characters.")]
        public String CommentText { get; set; }

    }
}
