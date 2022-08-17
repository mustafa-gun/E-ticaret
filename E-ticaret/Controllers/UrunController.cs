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
        private IWebHostEnvironment _webHostEnvironment;
        public UrunController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<ActionResult> UrunEkle([FromForm] Urunler obj, IFormCollection formValues)
        {
            if (ModelState.IsValid)
            {
                if (obj.Gorsel != null)
                {
                    string folder = "images/products/";
                    folder += Guid.NewGuid().ToString() + "_" + obj.Gorsel.FileName;
                    obj.GorselURL = folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await obj.Gorsel.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                _db.tblUrunler.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Ürün ekleme başarılı";
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
            var urunFromDb = _db.tblUrunler.Find(id);
            //var categoryFromDbFirst = _db.tblKategori.FirstOrDefault(u=>u.KategoriID==id);
            //var urunFromDb = _db.tblUrunler.SingleOrDefault(u => u.UrunID == id);

            if (urunFromDb == null)
            {
                return NotFound();
            }

            return View(urunFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UrunDuzenle([FromForm] Urunler obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Gorsel != null)
                {
                    string folder = "images/products/";
                    folder += Guid.NewGuid().ToString() + "_" + obj.Gorsel.FileName;
                    obj.GorselURL = folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await obj.Gorsel.CopyToAsync(new FileStream(serverFolder, FileMode.CreateNew));
                }
                _db.tblUrunler.Update(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                TempData["success"] = "Ürün düzenleme başarılı";
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
            TempData["success"] = "Ürün silme başarılı";
            return RedirectToAction("Index");

        }
    }
}
