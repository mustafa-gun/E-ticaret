using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticaret.Migrations
{
    public partial class newMige : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAltKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltKategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UstKategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAltKategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblKategori",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltKategorisiVar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKategori", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "tblMusteri",
                columns: table => new
                {
                    MusteriID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<int>(type: "int", nullable: false),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMusteri", x => x.MusteriID);
                });

            migrationBuilder.CreateTable(
                name: "tblTedarikci",
                columns: table => new
                {
                    TedarikciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeSekli = table.Column<int>(type: "int", nullable: false),
                    Indirim = table.Column<int>(type: "int", nullable: false),
                    SirketNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelSiparis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTedarikci", x => x.TedarikciID);
                });

            migrationBuilder.CreateTable(
                name: "tblUrun",
                columns: table => new
                {
                    UrunID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKategorisi = table.Column<int>(type: "int", nullable: false),
                    UrunFiyati = table.Column<int>(type: "int", nullable: false),
                    StokDurumu = table.Column<int>(type: "int", nullable: false),
                    RenkSecenekleri = table.Column<int>(type: "int", nullable: false),
                    Indirim = table.Column<int>(type: "int", nullable: false),
                    TedarikciID = table.Column<int>(type: "int", nullable: false),
                    GelisFiyati = table.Column<int>(type: "int", nullable: false),
                    GorselURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUrun", x => x.UrunID);
                });

            migrationBuilder.CreateTable(
                name: "tblYetkili",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YetkiliSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yetkiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblYetkili", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAltKategori");

            migrationBuilder.DropTable(
                name: "tblKategori");

            migrationBuilder.DropTable(
                name: "tblMusteri");

            migrationBuilder.DropTable(
                name: "tblTedarikci");

            migrationBuilder.DropTable(
                name: "tblUrun");

            migrationBuilder.DropTable(
                name: "tblYetkili");
        }
    }
}
