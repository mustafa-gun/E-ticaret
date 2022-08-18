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
    }
}
