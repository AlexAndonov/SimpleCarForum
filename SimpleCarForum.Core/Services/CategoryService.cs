using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels.Category;
using SimpleCarForum.Data;
using SimpleCarForum.Infra.Data.Models;

namespace SimpleCarForum.Core.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ApplicationDbContext context;

		public CategoryService(ApplicationDbContext _context)
		{
			context = _context;
		}

		public async Task<CategoryDto> CreateAsync(CategoryCreateDto model)
		{
			Category category = new Category()
			{
				Name = model.Name,
				Description = model.Description,
			};

			await context.AddAsync(category);
			await context.SaveChangesAsync();

			return new CategoryDto()
			{
				Id = category.Id,
				Name = category.Name,
				Description = category.Description,
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			Category? category = await context.Categories.FindAsync(id);

			bool hasPosts = await context.Posts.AnyAsync(p => p.CategoryId == id);

			if (hasPosts)
			{
				return false;
			}

			if (category == null)
			{
				return false;
			}

			context.Categories.Remove(category);
			await context.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<CategoryDto>> GetAllAsync()
		{
			return await context.Categories
				.Select(c => new CategoryDto()
				{
					Id = c.Id,
					Name = c.Name,
					Description = c.Description,
				})
				.ToListAsync();
		}

		public async Task<CategoryDto?> GetByIdAsync(int id)
		{
			Category? category = await context.Categories.FindAsync(id);

			if (category == null)
			{
				return null;
			}

			return new CategoryDto()
			{
				Id = category.Id,
				Name = category.Name,
				Description = category.Description,
			};
		}

		public async Task<CategoryDto?> UpdateAsync(CategoryDto model)
		{
			Category? category = await context.Categories.FindAsync(model.Id);

			if (category == null)
			{
				return null;
			}

			category.Name = model.Name;
			category.Description = model.Description;

			await context.SaveChangesAsync();

			return new CategoryDto()
			{
				Id = category.Id,
				Name = category.Name,
				Description = category.Description,
			};
		}
	}
}
