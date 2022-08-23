using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

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

            IList<Kategori> objKategori = _db.tblKategori.ToList();
            IList<AltKategori> altKategoris = _db.tblAltKategori.ToList();
            IList<Urunler> urunListesi = _db.tblUrun.ToList();

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
        public async Task<ActionResult> UrunEkle([FromForm] Urunler obj)
        {
            if (ModelState.IsValid && obj.Gorsel != null)
            {
                string fileName = obj.Gorsel.FileName;
                string grs = Path.GetExtension(fileName);
                if (grs == ".png" || grs == ".jpg" || grs == ".jpeg")
                {
                    string folder = "images/products/";
                    folder += Guid.NewGuid().ToString() + "_" + obj.Gorsel.FileName;
                    obj.GorselURL = folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await obj.Gorsel.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                else
                {
                    TempData["error"] = "Sadece PNG, JPG ya da JPEG dosyası yükleyebilirsiniz.";
                    return View();
                }
                _db.tblUrun.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Ürün ekleme başarılı";
                return RedirectToAction("Index");
            }
            else if (obj.Gorsel == null)
            {
                TempData["error"] = "Görsel ekleyin!";
                return View();
            }
            return View();
        }

        public IActionResult UrunDuzenle(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
            {
                return NotFound();
            }
            var urunFromDb = _db.tblUrun.Find(id);
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
                _db.tblUrun.Update(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                TempData["success"] = "Ürün düzenleme başarılı";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult UrunSil(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblUrun.Find(id);
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
        public IActionResult UrunSilPOST(Guid? id)
        {
            var obj = _db.tblUrun.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.tblUrun.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Ürün silme başarılı";
            return RedirectToAction("Index");

        }
    }
}
