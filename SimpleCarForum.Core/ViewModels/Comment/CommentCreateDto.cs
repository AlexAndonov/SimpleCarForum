using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Infra.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Core.ViewModels.Comment
{
	public class CommentCreateDto
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[MaxLength(CommentContentMaxLength, ErrorMessage = StringLengthErrorMessage)]
		public string Content { get; set; } = null!;

		[Required]
		public Guid PostId { get; set; }
	}
}
