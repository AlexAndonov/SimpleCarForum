using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCarForum.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Infra.Data.SeedDb
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                   new Category
                   {
                       Id = 1,
                       Name = "Engine & Performance",
                       Description = "Discussions about engines, tuning, performance upgrades, turbo setups, and power optimization."
                   },
                   new Category
                   {
                       Id = 2,
                       Name = "Maintenance & Repairs",
                       Description = "Troubleshooting issues, regular maintenance, DIY repairs, and service advice."
                   },
                   new Category
                   {
                       Id = 3,
                       Name = "Electrical & Diagnostics",
                       Description = "Battery problems, sensors, ECU errors, OBD diagnostics, and electrical system discussions."
                   },
                   new Category
                   {
                       Id = 4,
                       Name = "Buying & Selling Advice",
                       Description = "Car buying tips, resale advice, market insights, and vehicle recommendations."
                   },
                   new Category
                   {
                       Id = 5,
                       Name = "General Discussion",
                       Description = "Open discussions about cars, brands, news, and automotive trends."
                   }
                );
        }
    }
}
