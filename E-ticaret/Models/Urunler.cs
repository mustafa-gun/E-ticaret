using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ticaret.Models
{
    public class Urunler
    {
        [Key]
        public Guid UrunID { get; set; }
        [Required]
        public string SKU { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklamasi { get; set; }
        public int UrunKategorisi { get; set; }
        public int UrunFiyati { get; set; }
        public int StokDurumu { get; set; }
        public int RenkSecenekleri { get; set; }
        public int BoyutSecenekleri { get; set; }
        public int Indirim { get; set; }
        public int TedarikciID { get; set; }
        public int GelisFiyati { get; set; }
        [NotMapped]
        public IFormFile Gorsel { get; set; }
        public string GorselURL { get; set; }
    }
}
