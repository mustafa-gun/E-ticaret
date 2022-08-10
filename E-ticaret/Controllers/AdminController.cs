using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace E_ticaret.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ExpandoObject GetAllMenu()
        {

            IEnumerable<Kategori> objKategori = _db.tblKategori.ToList();
            IEnumerable<AltKategori> altKategoris = _db.tblAltKategori.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = objKategori;
            mymodel.AltMenu = altKategoris;

            return mymodel;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            var getMenu = GetAllMenu();
            return View(getMenu);
        }

    }
}
