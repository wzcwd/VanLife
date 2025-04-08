using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VanLife.Data;
using VanLife.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add sqlite 
builder.Services.AddDbContext<VanLifeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VanLifeContext") ??
                      throw new InvalidOperationException("Connection string VanLifeContext not found.")));

// add identity service
builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;

        options.Lockout.MaxFailedAccessAttempts = 10;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    }).AddEntityFrameworkStores<VanLifeContext>()
    .AddDefaultTokenProviders();


// enable runtime compilation for development stage
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// seed user data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await VanLifeContext.CreateUser(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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


app.Run();