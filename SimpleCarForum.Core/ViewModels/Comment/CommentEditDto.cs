using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;


namespace SimpleCarForum.Core.ViewModels.Comment
{
	public class CommentEditDto
	{
		[Required]
		public Guid Id { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[MaxLength(CommentContentMaxLength, ErrorMessage = StringLengthErrorMessage)]
		public string Content { get; set; } = null!;
	}
}
