using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.Services;
using SimpleCarForum.Core.ViewModels.Comment;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace SimpleCarForum.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService service;

		public CommentController(ICommentService _service)
		{
			service = _service;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(CommentCreateDto model)
		{
			if (ModelState.IsValid == false)
			{
				return RedirectToAction("Details", "Post", new { id = model.PostId });
			}

			var userId = GetUserId();

			if (userId == null)
			{
				return Unauthorized();
			}

			await service.CreateAsync(model, userId);

			return RedirectToAction("Details", "Post", new { id = model.PostId });
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{
			var comment = await service.GetByIdAsync(id);
			if (comment == null)
			{
				return NotFound();
			}

			var userId = GetUserId();
			if (userId == null)
			{
				return Unauthorized();
			}

			if (!IsOwnerOrAdmin(userId, comment.AuthorId))
			{
				return Forbid();
			}

			var model = new CommentEditDto
			{
				Id = comment.Id,
				Content = comment.Content,
				PostId = comment.PostId
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id, Guid postId)
		{
			var userId = GetUserId();
			if (userId == null)
			{
				return Unauthorized();
			}

			var comment = await service.GetByIdAsync(id);
			if (comment == null)
			{
				return NotFound();
			}

			if (!IsOwnerOrAdmin(userId, comment.AuthorId))
			{
				return Forbid();
			}

			await service.DeleteAsync(id);

			return RedirectToAction("Details", "Post", new { id = postId });
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Edit(Guid id)
		{
			var comment = await service.GetByIdAsync(id);
			if (comment == null)
			{
				return NotFound();
			}

			var userId = GetUserId();
			if (userId == null)
			{
				return Unauthorized();
			}

			if (comment.AuthorId != userId)
			{
				return Forbid();
			}

			var model = new CommentEditDto()
			{
				Id = comment.Id,
				Content = comment.Content,
				PostId = comment.PostId,
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Edit(CommentEditDto model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var userId = GetUserId();
			if (userId == null)
			{
				return Unauthorized();
			}

			var comment = await service.GetByIdAsync(model.Id);
			if (comment == null)
			{
				return NotFound();
			}

			if (userId != comment.AuthorId)
			{
				return Forbid();
			}

			await service.UpdateAsync(model);

			return RedirectToAction("Details", "Post", new { id = model.PostId });
		}

		private string? GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		private bool IsOwnerOrAdmin(string? userId, string authorId)
		{
			return userId == authorId || User.IsInRole("Admin");
		}

	}
}
