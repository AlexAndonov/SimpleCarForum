using SimpleCarForum.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto?> GetByIdAsync(Guid id);
        Task<PostDto> CreateAsync(PostCreateDto model, string userId);
        Task<PostDto?> UpdateAsync(PostEditDto model);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> IsOwnerAsync(Guid postId, string userId);
    }
}
