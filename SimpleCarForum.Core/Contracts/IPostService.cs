using SimpleCarForum.Core.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<IEnumerable<PostDto>> GetPostsByCategoryAsync(int? categoryId);
        Task<PostDto?> GetByIdAsync(Guid id);
		Task<PostEditDto?> GetForEditAsync(Guid id);
		Task<PostDto> CreateAsync(PostCreateDto model, string userId);
        Task<bool> UpdateAsync(PostEditDto model);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> IsOwnerAsync(Guid postId, string userId);
    }
}
