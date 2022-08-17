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

            IEnumerable<Tedarikci> tedarikci = _db.tblTedarikci.ToList();
            IEnumerable<Yetkili> yetkililer = _db.tblYetkili.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Tedarikci = tedarikci;
            mymodel.Yetkili = yetkililer;

            return mymodel;
        }

        public IActionResult Index()
        {
            var data = GetData();
            return View(data);
        }

        public IActionResult TedarikciEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TedarikciEkle([FromForm] Tedarikci obj)
        {
            if (ModelState.IsValid)
            {
                //if (obj.Gorsel != null)
                //{
                //    string folder = "images/products/";
                //    folder += Guid.NewGuid().ToString() + "_" + obj.Gorsel.FileName;
                //    obj.GorselURL = folder;
                //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                //    await obj.Gorsel.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                //}

                _db.tblTedarikci.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Yeni tedarikçi eklendi";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult TedarikciDuzenle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TedarikciFromDb = _db.tblTedarikci.Find(id);
            //var categoryFromDbFirst = _db.tblKategori.FirstOrDefault(u=>u.KategoriID==id);
            //var TedarikciFromDb = _db.tblTedarikci.SingleOrDefault(u => u.TedarikciID == id);

            if (TedarikciFromDb == null)
            {
                return NotFound();
            }

            return View(TedarikciFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TedarikciDuzenle([FromForm] Tedarikci obj)
        {
            if (ModelState.IsValid)
            {
                //if (obj.Gorsel != null)
                //{
                //    string folder = "images/products/";
                //    folder += Guid.NewGuid().ToString() + "_" + obj.Gorsel.FileName;
                //    obj.GorselURL = folder;
                //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                //    await obj.Gorsel.CopyToAsync(new FileStream(serverFolder, FileMode.CreateNew));
                //}
                _db.tblTedarikci.Update(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                TempData["success"] = "Tedarikçi kaydı düzenlendi.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult TedarikciSil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblTedarikci.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("TedarikciSil")]
        [ValidateAntiForgeryToken]
        public IActionResult TedarikciSilPOST(int? id)
        {
            var obj = _db.tblTedarikci.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.tblTedarikci.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Tedarikçi kaydı silindi.";
            return RedirectToAction("Index");

        }
    }
}
