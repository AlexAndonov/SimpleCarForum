using SimpleCarForum.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto?> GetById(Guid id);
        Task<PostDto> Create(PostCreateDto model, string userId);
        Task<PostDto?> Update(PostEditDto model);
        Task<bool> Delete(Guid id);
    }
}
