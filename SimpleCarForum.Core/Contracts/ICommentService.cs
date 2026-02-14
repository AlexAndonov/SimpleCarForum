using SimpleCarForum.Core.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Contracts
{
	public interface ICommentService
	{
		Task<IEnumerable<CommentDto>> GetByPostIdAsync(Guid postId);
		Task<CommentDto?> GetByIdAsync(Guid id);
		Task<CommentDto> CreateAsync(CommentCreateDto model, string userId);
		Task<bool> UpdateAsync(CommentEditDto model);
		Task<bool> DeleteAsync(Guid id);
		Task<bool> IsOwnerAsync(Guid commentId, string userId);
	}
}
