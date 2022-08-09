using Microsoft.EntityFrameworkCore;
using E_ticaret.Models;
namespace E_ticaret.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<AltKategori> AltKategoris { get; set; }
    }
}
