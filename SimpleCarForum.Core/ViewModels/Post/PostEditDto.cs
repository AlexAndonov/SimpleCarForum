using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Core.ViewModels.Post
{
    public class PostEditDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;


        [Required(ErrorMessage = RequiredFieldMessage)]
        public int CategoryId { get; set; }
    }
}
