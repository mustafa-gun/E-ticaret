using E_ticaret.Models;
using E_ticaret.Data;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Dynamic;
using System;
using System.IO;

namespace E_ticaret.Controllers
{
	public class UrunController : Controller
	{
        private readonly ApplicationDbContext _db;
        public UrunController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ExpandoObject GetData()
        {

            IEnumerable<Kategori> objKategori = _db.tblKategori.ToList();
            IEnumerable<AltKategori> altKategoris = _db.tblAltKategori.ToList();
            IEnumerable<Urunler> urunListesi = _db.tblUrunler.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = objKategori;
            mymodel.AltMenu = altKategoris;
			mymodel.Urunler = urunListesi;

            return mymodel;
        }

        public IActionResult Index()
		{
            var data = GetData();
			return View(data);
		}
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunEkle(Urunler obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblUrunler.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult UrunDuzenle(int? id)
		{
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.tblKategori.Find(id);
            //var categoryFromDbFirst = _db.tblKategori.FirstOrDefault(u=>u.KategoriID==id);
            var categoryFromDbSingle = _db.tblUrunler.SingleOrDefault(u => u.UrunID == id);

            if (categoryFromDbSingle == null)
            {
                return NotFound();
            }

            return View(categoryFromDbSingle);
		}
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UrunDuzenle(Urunler obj)
        {
            if (ModelState.IsValid)
            {
                //string UrunGorseli = Path.GetFileNameWithoutExtension(obj.UrunGorseli.FileName  );
                _db.tblUrunler.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

		public IActionResult UrunSil(int? id)
		{
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblUrunler.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("UrunSil")]
        [ValidateAntiForgeryToken]
        public IActionResult UrunSilPOST(int? id)
        {
            var obj = _db.tblUrunler.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.tblUrunler.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
