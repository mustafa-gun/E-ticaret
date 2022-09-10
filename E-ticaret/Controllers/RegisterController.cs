using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegisterController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] Musteri obj)
        {
            if (ModelState.IsValid)
            {
                var check = _db.tblMusteri.FirstOrDefault( s => s.Eposta == obj.Eposta );
                if (check == null)
                {
                    obj.KayitTarihi = DateTime.Now;
                    _db.tblMusteri.Add( obj );
                    _db.SaveChanges();
                    return Redirect( "~/Home/Index" );
                }
                else
                {
                    TempData["error"] = "Bu E-posta bir kullanıcıya ait.";
                    return View();
                }
            }
            return View();
        }
    }
}
