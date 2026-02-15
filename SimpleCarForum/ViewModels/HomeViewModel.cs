using SimpleCarForum.Core.ViewModels.Category;
using SimpleCarForum.Core.ViewModels.Post;

namespace SimpleCarForum.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<CategoryDto> Categories { get; set; }
		public IEnumerable<PostDto> Posts { get; set; }
	}
}
