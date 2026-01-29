using SimpleCarForum.Core.ViewModels;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Contracts
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDto>> GetAllAsync();
		Task<CategoryDto?> GetByIdAsync(int id);
		Task<CategoryDto> CreateAsync(CategoryCreateDto model);
		Task<CategoryDto?> UpdateAsync(CategoryDto model);
		Task<bool> DeleteAsync(int id);
	}
}
