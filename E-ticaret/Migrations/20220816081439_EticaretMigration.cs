using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ticaret.Migrations
{
    public partial class EticaretMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AltKategorisiVar",
                table: "tblKategori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblMusteri",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    OdemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SirketNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuncelSiparis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTedarikci", x => x.TedarikciID);
                });

            migrationBuilder.CreateTable(
                name: "tblUrunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKategorisi = table.Column<int>(type: "int", nullable: false),
                    UrunFiyati = table.Column<int>(type: "int", nullable: false),
                    StokDurumu = table.Column<int>(type: "int", nullable: false),
                    RenkSecenekleri = table.Column<int>(type: "int", nullable: false),
                    BoyutSecenekleri = table.Column<int>(type: "int", nullable: false),
                    Indirim = table.Column<int>(type: "int", nullable: false),
                    TedarikciID = table.Column<int>(type: "int", nullable: false),
                    GelisFiyati = table.Column<int>(type: "int", nullable: false),
                    GorselURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUrunler", x => x.UrunID);
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
                name: "tblMusteri");

            migrationBuilder.DropTable(
                name: "tblTedarikci");

            migrationBuilder.DropTable(
                name: "tblUrunler");

            migrationBuilder.DropTable(
                name: "tblYetkili");

            migrationBuilder.DropColumn(
                name: "AltKategorisiVar",
                table: "tblKategori");
        }
    }
}
