using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SimpleCarForum.Infra.Data.Constants.ValidationConstants;

namespace SimpleCarForum.Core.ViewModels.Category
{
	public class CategoryCreateDto
	{
		[Required]
		[StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Comment("Name of the category")]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(CategoryDescriptionMaxLength, MinimumLength = CategoryDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Comment("Description of the category")]
		public string Description { get; set; } = null!;
	}
}
