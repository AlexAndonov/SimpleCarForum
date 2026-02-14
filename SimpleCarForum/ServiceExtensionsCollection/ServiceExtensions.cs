using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Core.Contracts;
using SimpleCarForum.Core.Services;
using SimpleCarForum.Data;
using SimpleCarForum.Infra.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IPostService, PostService>();
			services.AddScoped<ICommentService, CommentService>();
			return services;
		}

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
		{
			services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			return services;
		}
	}
}
