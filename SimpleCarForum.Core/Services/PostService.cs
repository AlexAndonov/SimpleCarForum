using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels;
using SimpleCarForum.Data;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<PostDto> CreateAsync(PostCreateDto model, string userId)
        {
            Post post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
                CreatedOn = DateTime.UtcNow,
                AuthorId = userId,
                CategoryId = model.CategoryId,
            };

            await context.AddAsync(post);
            await context.SaveChangesAsync();

            var user = await context.Users.FindAsync(userId) ?? throw new InvalidOperationException("Author not found!");

            await context.Entry(post).Reference(p => p.Category).LoadAsync();

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                AuthorId = user.Id,
                AuthorName = user.FirstName + " " + user.LastName,
                CategoryId = post.CategoryId,
                CategoryName = post.Category.Name,
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            Post? post = await context.Posts
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return false;
            }

            context.RemoveRange(post.Comments);
            context.Remove(post);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            return await context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Select(p => new PostDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    AuthorId = p.AuthorId,
                    AuthorName = p.Author.FirstName + " " + p.Author.LastName,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                })
                .ToListAsync();
        }

        public async Task<PostDto?> GetByIdAsync(Guid id)
        {
            Post? post = await context.Posts
              .Include(p => p.Author)
              .Include(p => p.Category)
              .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return null;
            }

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                AuthorId = post.AuthorId,
                AuthorName = post.Author.FirstName + " " + post.Author.LastName,
                CategoryId = post.CategoryId,
                CategoryName = post.Category.Name,
            };
        }

		public async Task<bool> IsOwnerAsync(Guid postId, string userId)
		{
            return context.Posts.Any(p => p.Id == postId && p.AuthorId == userId);
		}

		public async Task<PostDto?> UpdateAsync(PostEditDto model)
        {
            Post? post = await context.Posts
            .Include(p => p.Author)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (post == null)
            {
                return null;
            }

            post.Title = model.Title;
            post.Content = model.Content;
            post.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                AuthorId = post.AuthorId,
                AuthorName = post.Author.FirstName + " " + post.Author.LastName,
                CategoryId = post.CategoryId,
                CategoryName = post.Category.Name,
            };
        }
    }
}
