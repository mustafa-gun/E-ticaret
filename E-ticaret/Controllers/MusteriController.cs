using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace E_ticaret.Controllers
{
    public class MusteriController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        public MusteriController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public ExpandoObject GetData()
        {

            IEnumerable<Musteri> musteri = _db.tblMusteri.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Musteri = musteri;

            return mymodel;
        }
        public IActionResult Index()
        {
            var getData = GetData();
            return View(getData);
        }

        public IActionResult Detay()
        {
            var getData = GetData();
            return View(getData);
        }

        public IActionResult MusteriDuzenle(Guid? id)
        {
            HttpContext.Session.SetString("id", "session");
            if (id == null || id.Value == Guid.Empty)
            {
                return NotFound();
            }
            var urunFromDb = _db.tblMusteri.Find(id);
            //var categoryFromDbFirst = _db.tblKategori.FirstOrDefault(u=>u.KategoriID==id);
            //var urunFromDb = _db.tblUrun.SingleOrDefault(u => u.UrunID == id);

            if (urunFromDb == null)
            {
                return NotFound();
            }

            return View(urunFromDb);
        }
        //POST
        [HttpPost]
        public ActionResult MusteriDuzenle([FromForm] Musteri obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblMusteri.Update(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                obj.KayitTarihi = DateTime.Now;
                _db.SaveChanges();
                TempData["success"] = "Ürün düzenleme başarılı";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
