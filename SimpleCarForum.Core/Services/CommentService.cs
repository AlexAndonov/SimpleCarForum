using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels.Comment;
using SimpleCarForum.Data;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Core.Services
{
	public class CommentService : ICommentService
	{
		private readonly ApplicationDbContext context;

		public CommentService(ApplicationDbContext _context)
		{
			context = _context;	
		}

		public async Task<CommentDto> CreateAsync(CommentCreateDto model, string userId)
		{
			Comment comment = new Comment()
			{
				Id = Guid.NewGuid(),
				Content = model.Content,
				AuthorId = userId,
				CreatedOn = DateTime.UtcNow,
				PostId = model.PostId,
			};

			await context.AddAsync(comment);
			await context.SaveChangesAsync();

			var user = await context.Users.FindAsync(userId) ?? throw new InvalidOperationException("Author not found");

			return new CommentDto()
			{
				Id = comment.Id,
				Content = comment.Content,
				AuthorId = comment.AuthorId,
				AuthorName = user.FirstName + " " + user.LastName,
				CreatedOn = comment.CreatedOn,
				PostId = comment.PostId,
			};
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var comment = await context.Comments.FindAsync(id);

			if (comment == null)
			{
				return false;
			}

			context.Remove(comment);
			await context.SaveChangesAsync();

			return true;
		}

		public async Task<CommentDto?> GetByIdAsync(Guid id)
		{
			var comment = await context.Comments
				.Include(c => c.Author)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (comment == null)
			{
				return null;
			}

			return new CommentDto()
			{
				Content = comment.Content,
				AuthorId = comment.AuthorId,
				AuthorName = comment.Author.FirstName + " " + comment.Author.LastName,
				CreatedOn = comment.CreatedOn,
				PostId = comment.PostId,
			};
		}

		public async Task<IEnumerable<CommentDto>> GetByPostIdAsync(Guid postId)
		{
			return await context.Comments
				.Include(c => c.Author)
				.Where(c => c.PostId == postId)
				.Select(c => new CommentDto()
				{
					Content = c.Content,
					AuthorId = c.AuthorId,
					AuthorName = c.Author.FirstName + " " + c.Author.LastName,
					CreatedOn = c.CreatedOn,
					PostId = c.PostId
				})
				.OrderBy(c => c.CreatedOn)	
				.ToListAsync();
		}

		public async Task<bool> IsOwnerAsync(Guid commentId, string userId)
		{
			return await context.Comments.AnyAsync(c => c.Id == commentId && c.AuthorId == userId);
		}

		public async Task<bool> UpdateAsync(CommentEditDto model)
		{
			var comment = await context.Comments.FindAsync(model.Id);

			if (comment == null)
			{
				return false;
			}

			comment.Content = model.Content;

			await context.SaveChangesAsync();

			return true;
		}
	}
}
