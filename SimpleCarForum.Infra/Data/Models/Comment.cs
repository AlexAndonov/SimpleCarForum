using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Infra.Data.Models
{
    [Comment("Comments for posts")]
    public class Comment
    {
        [Key]
        [Comment("Unique identifier of the comment")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        [Comment("Text content of the comment")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Identifier of the comment's author")]
        public string AuthorId { get; set; } = null!;

        [ForeignKey(nameof(AuthorId))]
        [Comment("Navigational property for the author")]
        public ApplicationUser Author { get; set; } = null!;


        [Comment("Date and time when comment was created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        [Comment("Identifier of the related post")]
        public Guid PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        [Comment("Navigational property for the post")]
        public Post Post { get; set; } = null!;
    }
}
