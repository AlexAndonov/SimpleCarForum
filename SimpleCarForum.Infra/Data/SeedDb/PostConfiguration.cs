using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Infra.Data.SeedDb
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			var createdOn = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc);

			builder.HasData
				(
				  new Post
				  {
					  Id = new Guid("10000000-0000-0000-0000-000000000001"),
					  Title = "Best Turbo Setup for 2.0 TDI?",
					  Content = "Looking for reliable turbo upgrade options for daily driving with moderate power gains. Any proven setups?",
					  AuthorId = "11111111-1111-1111-1111-111111111111",
					  CategoryId = 1,
					  CreatedOn = createdOn
				  },
				new Post
				{
					Id = new Guid("10000000-0000-0000-0000-000000000002"),
					Title = "Stage 1 vs Stage 2 – Worth the Risk?",
					Content = "Is going Stage 2 really worth the additional stress on the engine components?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 1,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("10000000-0000-0000-0000-000000000003"),
					Title = "High RPM Misfire After Tune",
					Content = "Experiencing misfires at high RPM after remap. Spark plugs and coils are new. What else to check?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 1,
					CreatedOn = createdOn
				},

				// =========================
				// Category 2 – Maintenance & Repairs
				// =========================
				new Post
				{
					Id = new Guid("20000000-0000-0000-0000-000000000001"),
					Title = "Oil Change Interval – 8k or 10k km?",
					Content = "What oil change interval do you follow for turbocharged petrol engines?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 2,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("20000000-0000-0000-0000-000000000002"),
					Title = "Brake Pads Recommendation",
					Content = "Looking for durable brake pads for mixed city and highway driving.",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 2,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("20000000-0000-0000-0000-000000000003"),
					Title = "Coolant Leak – Hard to Detect",
					Content = "Losing coolant slowly but no visible leak. Where should I start diagnosing?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 2,
					CreatedOn = createdOn
				},

				// =========================
				// Category 3 – Electrical & Diagnostics
				// =========================
				new Post
				{
					Id = new Guid("30000000-0000-0000-0000-000000000001"),
					Title = "Check Engine Light – P0420",
					Content = "Got P0420 code. Is it always catalytic converter failure?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 3,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("30000000-0000-0000-0000-000000000002"),
					Title = "Battery Drains Overnight",
					Content = "Brand new battery but drains overnight. Possible parasitic draw?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 3,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("30000000-0000-0000-0000-000000000003"),
					Title = "OBD Scanner Recommendations",
					Content = "Looking for a reliable OBD2 scanner for home diagnostics.",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 3,
					CreatedOn = createdOn
				},

				// =========================
				// Category 4 – Buying & Selling Advice
				// =========================
				new Post
				{
					Id = new Guid("40000000-0000-0000-0000-000000000001"),
					Title = "Used Diesel vs Petrol in 2025?",
					Content = "Which is the smarter buy considering maintenance and fuel prices?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 4,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("40000000-0000-0000-0000-000000000002"),
					Title = "High Mileage Car – Red Flag?",
					Content = "Is buying a 250k km car always a bad decision?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 4,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("40000000-0000-0000-0000-000000000003"),
					Title = "Best Budget SUV?",
					Content = "Looking for reliable SUV under reasonable budget with low maintenance costs.",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 4,
					CreatedOn = createdOn
				},

				// =========================
				// Category 5 – General Discussion
				// =========================
				new Post
				{
					Id = new Guid("50000000-0000-0000-0000-000000000001"),
					Title = "Most Reliable Car Brand?",
					Content = "In your experience, which brand has proven most reliable over the years?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 5,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("50000000-0000-0000-0000-000000000002"),
					Title = "Manual vs Automatic – Still Relevant?",
					Content = "Do you still prefer manual transmission in modern cars?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 5,
					CreatedOn = createdOn
				},
				new Post
				{
					Id = new Guid("50000000-0000-0000-0000-000000000003"),
					Title = "Future of Electric Vehicles",
					Content = "Do you think EVs will fully replace internal combustion engines?",
					AuthorId = "11111111-1111-1111-1111-111111111111",
					CategoryId = 5,
					CreatedOn = createdOn
				}
				);
		}
	}
}
