using E_ticaret.Data;
using E_ticaret.Models;
using E_ticaret.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private JWTHelper tokenHelper;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
            tokenHelper = new JWTHelper();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Eposta, string Sifre)
        {
            var loginObj = LoginClass.Login(_db,tokenHelper, HttpContext, Eposta,Sifre);
            if (loginObj == "")
            {
                return View();
            }
            else
            {
                return Redirect( "~/" + loginObj );
            }
            
            //TempData["success"] = "Başarılı";
            //return View();

        }

        private void RecordInSession(string action)
        {
            var paths = HttpContext.Session.GetString( "actions" ) ?? string.Empty;
            HttpContext.Session.SetString( "actions", paths + ";" + action );
        }


    }

    public static class LoginClass{
        public static string Login(ApplicationDbContext _db, JWTHelper tokenHelper, HttpContext context ,string Eposta, string Sifre)
        {
            IList<Musteri> musteriler = _db.tblMusteri.ToList();
            foreach (var musteri in musteriler)
            {
                if (musteri.Eposta != Eposta || musteri.Sifre != Sifre)
                {
                    //TempData["error"] = "Kullanıcı adı veya şifre hatalı";
                    return "";
                }
                var accessToken = tokenHelper.CreateToken( musteri );
                //HttpContext.Session.SetString( "TokenOptions", accessToken );
                Console.WriteLine( $"{accessToken.Token}\n{accessToken.Expiration}" );

                var token = tokenHelper.CreateToken( musteri );
                //var acsToken = JsonConvert.DeserializeObject( token.Token );
                //HttpContext.Session.SetString( "token", acsToken.ToString());
                //ViewData["token1"] = acsToken;

                //if (token.Token != null)
                //{
                //    //Save token in session object
                //    HttpContext.Session.SetString( "JWToken", token.Token );
                //}

                //Response.Cookies.Append("Bearer", token.Token);
                //HttpContext.Response.Cookies.Append("token1", token.Token);

                //TODO: Eğer eposta ve şifre sessionda varsa bir daha ekleme
                context.Session.SetString( "Eposta", Eposta );
                context.Session.SetString( "Sifre", Sifre );
                context.Session.SetString( "accessToken", token.Token );
                //Console.WriteLine( token.Token );
                //RecordInSession( "Login" );

                //return Redirect( "~/Home/Index" );
                return "Home/Index";
            }
            return "";
        }
    }

}


