using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models
{
    public class Yetkili
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Eposta { get; set; }
        public string YetkiliAdi { get; set; }
        public string YetkiliSoyadi { get; set; }
        public string Yetkiler { get; set; }
        public string Sifre { get; set; }

    }

    public class Musteri
    {
        public Guid MusteriID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Ilce { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public int PostaKodu { get; set; }
        public string CepTelefonu { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
