namespace E_ticaret.Models
{
    public class Tedarikci
    {
        public int TedarikciID { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        public int PostaKodu { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Eposta { get; set; }
        public string URL { get; set; }
        public int OdemeSekli { get; set; }
        public int Indirim { get; set; }
        public string SirketNotu { get; set; }
        public string GuncelSiparis { get; set; }
    }
}
