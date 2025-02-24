using System.ComponentModel.DataAnnotations;

namespace GGinfoSite.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public AppUser Commenter { get; set; }

        [Required]
        public int BlogPostID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }
    }
}
