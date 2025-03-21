using Microsoft.EntityFrameworkCore;
using VanLife.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add sqlite 
builder.Services.AddDbContext<VanLifeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VanLifeContext") ??
                      throw new InvalidOperationException("Connection string VanLifeContext not found.")));

// enable runtime compilation for development stage
builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();