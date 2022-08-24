using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret.Controllers
{
    [Route("api/Uruns")]
    [ApiController]
    public class UrunApiController : ControllerBase
    {
        private ApplicationDbContext db { get; }
        public UrunApiController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [Route("GetUrunler")]
        [HttpGet]
        public IEnumerable<Urunler> GetUrunler(string urunAdi)
        {
            return (from c in this.db.tblUrun.Take(6)
                    where c.UrunAdi.StartsWith(urunAdi) || string.IsNullOrEmpty(urunAdi)
                    select c).ToList();
        }
    }
}
