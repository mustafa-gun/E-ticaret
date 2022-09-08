using E_ticaret.Controllers;
using E_ticaret.Data;
using E_ticaret.Security.Encription;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NuGet.Common;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

//var configuration = new ConfigurationBuilder();

var builder = WebApplication.CreateBuilder( args );

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers( opts =>
{
    opts.ReturnHttpNotAcceptable = true;
} ).AddXmlSerializerFormatters();

//var tokenOptions = configuration
//            .SetBasePath( "C:\\Users\\Mustafa\\source\\repos\\E-ticaret\\E-ticaret\\" )
//            .AddJsonFile( "appsettings.json" )
//            .Build();

//var tokenOptions = builder.Configuration.AddJsonFile( "appsettings.json", false, true );

//builder.Services.AddAuthentication( options =>
//{
//    options.DefaultScheme = "JWT_OR_COOKIE";
//    options.DefaultChallengeScheme = "JWT_OR_COOKIE";
//} )
//    .AddCookie( options =>
//    {
//        options.LoginPath = "/login";
//        options.ExpireTimeSpan = TimeSpan.FromDays( 1 );
//    } )
//    .AddJwtBearer( options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidIssuer = configuration["TokenOptions:Issuer"],
//            ValidAudience = configuration["TokenOptions:Audience"],
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey( configuration["TokenOptions:SecurityKey"] )
//        };
//    } )
//    .AddPolicyScheme( "JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
//    {
//        options.ForwardDefaultSelector = context =>
//        {
//            string authorization = context.Request.Headers[HeaderNames.Authorization];
//            if (!string.IsNullOrEmpty( authorization ) && authorization.StartsWith( "Bearer " ))
//                return JwtBearerDefaults.AuthenticationScheme;

//            return CookieAuthenticationDefaults.AuthenticationScheme;
//        };
//    } );

builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme ).AddJwtBearer( options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = configuration["TokenOptions:Issuer"],
        ValidAudience = configuration["TokenOptions:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey( configuration["TokenOptions:SecurityKey"] )
    };

} );

// Add services to the container.
builder.Services.AddControllersWithViews( opts =>
{
    opts.Filters.Add( new AutoValidateAntiforgeryTokenAttribute() );
} );

builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(
    builder.Configuration.GetConnectionString( "DefaultConnection" )
    ) );

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(Convert.ToInt32( configuration["TokenOptions:AccessTokenExpiration"] ) );

} );

builder.Environment.IsDevelopment();

//builder.Services.AddHttpLogging( options =>
//{
//    //options.LoggingFields = HttpLoggingFields.RequestMethod | HttpLoggingFields.RequestPath;
//    options.LoggingFields = HttpLoggingFields.All;
//    options.MediaTypeOptions.AddText( "application/javascript" );
//    options.RequestBodyLogLimit = 4096;
//    options.ResponseBodyLogLimit = 4096;
//    options.ResponseHeaders.Remove( "Content-Type" );
//    options.ResponseHeaders.Remove( "Server" );
//} );


var app = builder.Build();

app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler( "/Home/Error" );
}

app.UseStaticFiles();

app.UseHttpLogging();

app.UseRouting();

app.UseHsts();

app.Use( async (context, next) =>
{
    //var headers = context.Response.Headers;
    //var token = context.Request.Cookies["Bearer"];
    var token = context.Session.GetString( "accessToken" );
    if (!string.IsNullOrEmpty( token ))
    {
        context.Request.Headers.Add( "Authorization", "Bearer " + token );
    }
    await next();
} );


//app.Use( (ctx, next) =>
//{
//    var eposta = ctx.Session.GetString( "Eposta" );
//    var sifre = ctx.Session.GetString( "Sifre" );
//    if (!string.IsNullOrEmpty( eposta ) || !string.IsNullOrEmpty( sifre ))
//    {
//        return next();
//    }
//    //var controller = new LoginController(new ApplicationDbContext());
//    LoginClass.Login(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()), new E_ticaret.Security.JWT.JWTHelper(), ctx, eposta, sifre);
//    return next();
//} );

app.UseAuthentication();

app.UseAuthorization();

app.Environment.IsDevelopment();

app.MapControllerRoute( name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}" );
app.MapControllerRoute( name: "home",
               pattern: "{controller=Home}/{action=Urun}/{UrunAdi}/{id?}" );

app.MapControllerRoute( name: "menu",
                pattern: "{controller=Menu}/{action=Index}/{id?}/{KategoriAdi?}",
                defaults: new { controller = "Menu", action = "Index" } );

app.MapControllerRoute( name: "detay",
                pattern: "{controller=Menu}/{action=Detay}/{id?}/{KategoriAdi}/{dropdownId?}/{AltKategoriAdi}",
                defaults: new { controller = "Menu", action = "Detay" } );


app.MapControllerRoute( name: "urun",
                pattern: "{controller=Urun}/{action=Index}/{id?}",
                defaults: new { controller = "Urun", action = "Index" } );


app.MapControllerRoute( name: "admin",
                pattern: "{controller=Admin}/{action=Kategoriler}/{id?}/{dropdownId?}",
                defaults: new { controller = "Admin", action = "Kategoriler" } );
app.MapControllerRoute( name: "admin",
                pattern: "{controller=Admin}/{action=EditKategori}/{id?}/",
                defaults: new { controller = "Admin", action = "EditKategori" } );
app.MapControllerRoute( name: "admin",
                pattern: "{controller=Admin}/{action=EditAltKategori}/{id?}/{dropdownId?}",
                defaults: new { controller = "Admin", action = "EditAltKategori" } );

app.Run();
