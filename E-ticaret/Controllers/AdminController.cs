﻿using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
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

        public IActionResult Kategoriler()
        {
            var getMenu = GetAllMenu();
            return View(getMenu);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblKategori.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Kategoriler");
            }
            return View(obj);
        }

        //GET
        public IActionResult EditKategori(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblKategori.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditKategori(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblKategori.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Kategoriler");
            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblKategori.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.tblKategori.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.tblKategori.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Kategoriler");

        }

        // ALT KATEGORİ CONTROLLER
        //GET
        public IActionResult CreateAltKategori()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAltKategori(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblKategori.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Kategoriler");
            }
            return View(obj);
        }

        //GET
        public IActionResult EditAltKategori(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblAltKategori.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAltKategori(AltKategori obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblAltKategori.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Alt kategori güncellemesi başarılı.";
                return RedirectToAction("Kategoriler");
            }
            return View(obj);
        }
        public IActionResult DeleteAltKategori(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.tblKategori.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAltKategoriPOST(int? id)
        {
            var obj = _db.tblKategori.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.tblKategori.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Kategoriler");

        }
    }

}
