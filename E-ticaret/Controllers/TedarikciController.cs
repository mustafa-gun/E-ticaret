using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace E_ticaret.Controllers
{
    public class TedarikciController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        public TedarikciController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public ExpandoObject GetData()
        {

            IEnumerable<Kategori> objKategori = _db.tblKategori.ToList();
            IEnumerable<AltKategori> altKategoris = _db.tblAltKategori.ToList();
            IEnumerable<Tedarikci> tedarikciler = _db.tblTedarikci.ToList();
            IEnumerable<Urunler> urunListesi = _db.tblUrunler.ToList();
            IEnumerable<Musteri> musteriler = _db.tblMusteri.ToList();
            IEnumerable<Yetkili> yetkililer = _db.tblYetkili.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = objKategori;
            mymodel.AltMenu = altKategoris;
            mymodel.Urunler = urunListesi;
            mymodel.Tedarikci = tedarikciler;
            mymodel.Musteri = musteriler;
            mymodel.Yetkili = yetkililer;

            return mymodel;
        }

        public IActionResult Index()
        {
            var data = GetData();
            return View(data);
        }
    }
}
