using E_ticaret.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Environment.IsDevelopment();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseHsts();

app.UseRouting();

app.UseAuthorization();

app.Environment.IsDevelopment();

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "menu",
                pattern: "{controller=Menu}/{action=Index}/{id?}",
                defaults: new { controller = "Menu", action = "Index" },);

app.MapControllerRoute(name: "detay",
                pattern: "{controller=Menu}/{action=Detay}/{id?}/{dropdownId?}",
                defaults: new { controller = "Menu", action = "Detay" });

app.MapControllerRoute(name: "admin",
                pattern: "{controller=Admin}/{action=Kategoriler}/{id?}/{dropdownId?}",
                defaults: new { controller = "Admin", action = "Kategoriler" });
app.MapControllerRoute(name: "admin",
                pattern: "{controller=Admin}/{action=EditKategori}/{id?}/",
                defaults: new { controller = "Admin", action = "EditKategori" });
app.MapControllerRoute(name: "admin",
                pattern: "{controller=Admin}/{action=EditAltKategori}/{id?}/{dropdownId?}",
                defaults: new { controller = "Admin", action = "EditAltKategori" });

app.Run();
