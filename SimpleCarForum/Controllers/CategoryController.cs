using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.ViewModels;

namespace SimpleCarForum.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService service;

		public CategoryController(ICategoryService _service)
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create()
		{
			var model = new CategoryCreateDto();
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(CategoryCreateDto model)
		{
			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			await service.CreateAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await service.GetByIdAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(CategoryDto model)
		{
			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			await service.UpdateAsync(model);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var model = await service.GetByIdAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id)
		{
			await service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
