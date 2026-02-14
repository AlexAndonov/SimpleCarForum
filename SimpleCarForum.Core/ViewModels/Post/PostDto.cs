using SimpleCarForum.Core.ViewModels.Comment;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Core.ViewModels.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
