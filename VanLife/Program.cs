using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VanLife.Data;
using VanLife.Models;
using VanLife.Utility;

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

// add third-party authentication service
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        googleOptions.AccessDeniedPath  = "/Account/Login";
    });

builder.Services.AddAuthentication()
    .AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"]!;
        facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"]!;
        facebookOptions.AccessDeniedPath = "/Account/Login";
    });


// enable Session for verification code
builder.Services.AddSession(); 

// add email service
builder.Services.AddScoped<SendGridEmailSender>();



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
if (app.Environment.IsDevelopment())
{
    // only for test
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// deal with http status code
app.UseStatusCodePagesWithReExecute ("/Home/HandleStatusCode", "?code={0}");

app.UseHttpsRedirection();
app.UseRouting();

// enable Session for verification code
app.UseSession(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();