using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret.Controllers
{
    public class VeriTasimaController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new();
            ViewBag.Rnd1 = rnd.Next(1, 13);
            ViewBag.Rnd2 = rnd.Next(1, 13);

            DateTime CurrentDate = DateTime.Now;
            ViewBag.CurrentDate = CurrentDate.ToString("dd/MM/yyyy");
            
            //Student student = new()
            //{
            //    StudentId = 101,
            //    Name = "Dillip",
            //    Branch = "CSE",
            //    Section = "A",
            //    Gender = "Male"
            //};

            //Address address = new()
            //{
            //    StudentId = 101,
            //    City = "Mumbai",
            //    State = "Maharashtra",
            //    Country = "India",
            //    Pin = "400097"
            //};

            //StudentDetailsViewModel studentDetailsViewModel = new()
            //{
            //    Student = student,
            //    Address = address,
            //    Title = "Veri Taşıma Index Sayfası",
            //    Header = "Veri Taşıma"
            //};

            //ViewData["Data1"] = "ViewData verisi";
            //ViewBag.Data2 = "ViewBag verisi";
            //TempData["Data3"] = "TempData verisi";
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
