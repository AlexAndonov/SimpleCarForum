using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels.Comment;
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
				return RedirectToAction("Details", "Post", new {id = model.PostId});
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (userId == null)
			{
				return Unauthorized();
			}

			await service.CreateAsync(model, userId);

			return RedirectToAction("Details", "Post", new {id = model.PostId});
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (userId == null)
			{
				return Unauthorized();
			}

			bool isOwner = await service.IsOwnerAsync(id, userId);

			if (isOwner == false)
			{
				return Forbid();
			}

			bool success = await service.DeleteAsync(id);

			if (success == false)
			{
				return NotFound();
			}

			return RedirectToAction("Details", "Post", new {id});
		}
	}
}
