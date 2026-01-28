using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Infra.Data.Models
{
    [Comment("Post class")]
    public class Post
    {
        [Key]
        [Comment("Unique identifier of the post")]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(PostTitleMaxLength)]
        [Comment("Title of the post")]
        public string Title { get; set; } = null!;


        [Required]
        [MaxLength(PostContentMaxLength)]
        [Comment("Content of the post")]
        public string Content { get; set; } = null!;


        [Comment("Date and time when post was created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        [Required]
        [Comment("Identifier of the post's author")]
        public string AuthorId { get; set; } = null!;

        [ForeignKey(nameof(AuthorId))]
        [Comment("Navigational property for the author")]
        public ApplicationUser Author { get; set; } = null!;
    }
}
