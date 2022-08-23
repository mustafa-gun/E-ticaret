using E_ticaret.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts =>
{
    opts.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();

    
// Add services to the container.
builder.Services.AddControllersWithViews(opts =>
    {
        opts.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddSession();

builder.Environment.IsDevelopment();

builder.Services.AddHttpLogging(options =>
{
    //options.LoggingFields = HttpLoggingFields.RequestMethod | HttpLoggingFields.RequestPath;
    options.LoggingFields = HttpLoggingFields.All;
    options.MediaTypeOptions.AddText("application/javascript");
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
    options.ResponseHeaders.Remove("Content-Type");
    options.ResponseHeaders.Remove("Server");
});


var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseHttpLogging();

app.UseRouting();

app.UseHsts();

app.UseAuthorization();

app.Environment.IsDevelopment();

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "menu",
                pattern: "{controller=Menu}/{action=Index}/{id?}",
                defaults: new { controller = "Menu", action = "Index" });

app.MapControllerRoute(name: "detay",
                pattern: "{controller=Menu}/{action=Detay}/{id?}/{dropdownId?}",
                defaults: new { controller = "Menu", action = "Detay" });


app.MapControllerRoute(name: "urun",
                pattern: "{controller=Urun}/{action=Index}/{id?}",
                defaults: new { controller = "Urun", action = "Index" });


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
