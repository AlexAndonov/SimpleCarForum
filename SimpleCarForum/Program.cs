using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCarForum.Data;
using SimpleCarForum.Infra.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddApplicationIdentity();
builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    string adminEmail = "admin@example.com";
    string adminPassword = "Admin123!";

    var admin = await userManager.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
        admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true
        };

        await userManager.CreateAsync(admin, adminPassword);
        await userManager.AddToRoleAsync(admin, "Admin");
    }

    string demoEmail = "user@example.com";
    string demoPassword = "User123!";

    var demoUser = await userManager.FindByEmailAsync(demoEmail);
    if (demoUser == null)
    {
        demoUser = new ApplicationUser
        {
            UserName = demoEmail,
            Email = demoEmail,
            FirstName = "Demo",
            LastName = "User",
            EmailConfirmed = true
        };

        await userManager.CreateAsync(demoUser, demoPassword);
        await userManager.AddToRoleAsync(demoUser, "User");
    }

    var demo = await userManager.FindByEmailAsync(demoEmail);

    if (!dbContext.Posts.Any())
    {
        var createdOn = new DateTime(2024, 01, 01, 12, 00, 00, DateTimeKind.Utc);

        dbContext.Posts.AddRange(
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Best Turbo Setup for 2.0 TDI?",
                Content = "Looking for reliable turbo upgrade options for daily driving with moderate power gains. Any proven setups?",
                AuthorId = demo!.Id,
                CategoryId = 1,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Stage 1 vs Stage 2 – Worth the Risk?",
                Content = "Is going Stage 2 really worth the additional stress on the engine components?",
                AuthorId = demo.Id,
                CategoryId = 1,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Oil Change Interval – 8k or 10k km?",
                Content = "What oil change interval do you follow for turbocharged petrol engines?",
                AuthorId = demo.Id,
                CategoryId = 2,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Brake Pads Recommendation",
                Content = "Looking for durable brake pads for mixed city and highway driving.",
                AuthorId = demo.Id,
                CategoryId = 2,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Check Engine Light – P0420",
                Content = "Got P0420 code. Is it always catalytic converter failure?",
                AuthorId = demo.Id,
                CategoryId = 3,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Used Diesel vs Petrol in 2025?",
                Content = "Which is the smarter buy considering maintenance and fuel prices?",
                AuthorId = demo.Id,
                CategoryId = 4,
                CreatedOn = createdOn
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Most Reliable Car Brand?",
                Content = "In your experience, which brand has proven most reliable over the years?",
                AuthorId = demo.Id,
                CategoryId = 5,
                CreatedOn = createdOn
            }
        );

        await dbContext.SaveChangesAsync();
    }
}


app.Run();
