using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels.Post;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleCarForum.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService service;
		private readonly ICategoryService categoryService;

		public PostController(IPostService _service, ICategoryService _categoryService)
		{
			service = _service;
			categoryService = _categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int? categoryId)
		{
			IEnumerable<PostDto> posts;

			if (categoryId.HasValue)
			{
				posts = await service.GetPostsByCategoryAsync(categoryId);
			}
			else
			{
				posts = await service.GetAllAsync();
			}

			return View(posts);
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			PostDto? post = await service.GetByIdAsync(id);

			if (post == null)
			{
				return NotFound();
			}

			return View(post);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create()
		{
			await LoadCategoriesAsync();

			var model = new PostCreateDto();

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(PostCreateDto model)
		{
			if (ModelState.IsValid == false)
			{
				await LoadCategoriesAsync();
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
			var model = await service.GetForEditAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			await LoadCategoriesAsync();

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
			if (ModelState.IsValid == false)
			{
				await LoadCategoriesAsync();
				return View(model);
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (!await service.IsOwnerAsync(model.Id, userId!))
			{
				return Forbid();
			}

			bool success = await service.UpdateAsync(model);

			if (!success)
			{
				return NotFound();
			}

			return RedirectToAction(nameof(Details), new { id = model.Id});
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

		[HttpPost, ActionName(nameof(Delete))]
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

		private async Task LoadCategoriesAsync()
		{
			var categories = await categoryService.GetAllAsync();

			ViewBag.Categories = categories
				.Select(c => new SelectListItem()
				{
					Value = c.Id.ToString(),
					Text = c.Name,
				})
				.ToList();
		}
	}
}
