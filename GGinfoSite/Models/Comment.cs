using System.ComponentModel.DataAnnotations;

namespace GGinfoSite.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public AppUser Poster { get; set; }

        [Required]
        public int PostID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentTimeStamp { get; set; }

        public int? ParentCommentID { get; set; }
    }
}
