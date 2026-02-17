using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Infra.Data.Models;
using SimpleCarForum.Infra.Data.SeedDb;

namespace SimpleCarForum.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		  : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			builder.Entity<Comment>()
				.HasOne(c => c.Post)
				.WithMany(p => p.Comments)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<Post>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Posts)
				.OnDelete(DeleteBehavior.NoAction);

			builder.ApplyConfiguration(new CategoryConfiguration());
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
