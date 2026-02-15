using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Models;
using SimpleCarForum.ViewModels;

namespace SimpleCarForum.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IPostService postService;

		public HomeController(ICategoryService _categorService, IPostService _postService)
		{
			categoryService = _categorService;
			postService = _postService;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await categoryService.GetAllAsync();
			var posts = await postService.GetAllAsync();	
			var model = new HomeViewModel()
			{
				Categories = categories,
				Posts = posts
			};

			return View(model);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
