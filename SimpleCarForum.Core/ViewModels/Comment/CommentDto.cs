using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Infra.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Core.ViewModels.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(CommentContentMaxLength, MinimumLength = CommentContentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = null!;

        public string AuthorId { get; set; } = null!;
		public string AuthorName{ get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		public Guid PostId { get; set; }
	}
}