using Microsoft.EntityFrameworkCore;
using E_ticaret.Models;
namespace E_ticaret.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Kategori> tblKategori { get; set; }
        public DbSet<AltKategori> tblAltKategori { get; set; }
        public DbSet<Musteri> tblMusteri { get; set; }
        public DbSet<Tedarikci> tblTedarikci { get; set; }
        public DbSet<Urunler> tblUrun { get; set; }
        public DbSet<Yetkili> tblYetkili { get; set; }

    }
}
