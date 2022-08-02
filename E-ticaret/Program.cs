var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "detay",
                pattern: "{controller=Menu}/{action=Detay}/{id?}");

//app.MapControllerRoute(name: "detay",
//                pattern: "{controller}/{menuId}/{id}",
//                defaults: new { controller = "Menu", action = "Detay", menuId = "", id = "" });

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
