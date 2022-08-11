using E_ticaret.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "menu",
                pattern: "{controller=Menu}/{action=Index}/{id?}",
                defaults: new { controller = "Menu", action = "Index"});

app.MapControllerRoute(name: "detay",
                pattern: "{controller=Menu}/{action=Detay}/{id?}/{dropdownId?}",
                defaults: new { controller = "Menu", action = "Detay" });

app.Run();
