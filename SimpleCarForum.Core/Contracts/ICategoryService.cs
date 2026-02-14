using SimpleCarForum.Core.ViewModels.Category;

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
