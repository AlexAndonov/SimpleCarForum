using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels;
using System.Security.Claims;

namespace SimpleCarForum.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService service;

		public PostController(IPostService _service)
		{
			service = _service;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = await service.GetAllAsync();
			return View(model);
		}

		[HttpGet]
		[Authorize]
		public IActionResult Create()
		{
			var model = new PostCreateDto();
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(PostCreateDto model)
		{
			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (userId == null)
			{
				return Unauthorized();
			}

			await service.CreateAsync(model, userId);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Edit(Guid id)
		{
			var model = await service.GetByIdAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			bool IsOwner = await service.IsOwnerAsync(model.Id, userId!);

			if (!IsOwner)
			{
				return Forbid();
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Edit(PostEditDto model)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (!await service.IsOwnerAsync(model.Id, userId!))
			{
				return Forbid();
			}

			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			await service.UpdateAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{
			var model = await service.GetByIdAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			bool IsOwner = await service.IsOwnerAsync(model.Id, userId!);

			if (!IsOwner && !User.IsInRole("Admin"))
			{
				return Forbid();
			}

			return View(model);
		}

		[HttpPost,ActionName(nameof(Delete))]
		[Authorize]
		public async Task<IActionResult> DeleteConfirm(Guid id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			bool IsOwner = await service.IsOwnerAsync(id, userId!);

			if (!IsOwner && !User.IsInRole("Admin"))
			{
				return Forbid();
			}

			await service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
