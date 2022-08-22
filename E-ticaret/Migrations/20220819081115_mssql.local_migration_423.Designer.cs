﻿// <auto-generated />
using System;
using E_ticaret.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_ticaret.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220819081115_mssql.local_migration_423")]
    partial class mssqllocal_migration_423
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_ticaret.Models.AltKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AltKategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UstKategoriID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblAltKategori");
                });

            modelBuilder.Entity("E_ticaret.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriID"), 1L, 1);

                    b.Property<int>("AltKategorisiVar")
                        .HasColumnType("int");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriID");

                    b.ToTable("tblKategori");
                });

            modelBuilder.Entity("E_ticaret.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriID"), 1L, 1);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CepTelefonu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostaKodu")
                        .HasColumnType("int");

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulke")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriID");

                    b.ToTable("tblMusteri");
                });

            modelBuilder.Entity("E_ticaret.Models.Tedarikci", b =>
                {
                    b.Property<int>("TedarikciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TedarikciID"), 1L, 1);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuncelSiparis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Indirim")
                        .HasColumnType("int");

                    b.Property<int>("OdemeSekli")
                        .HasColumnType("int");

                    b.Property<int>("PostaKodu")
                        .HasColumnType("int");

                    b.Property<string>("SirketAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SirketNotu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TedarikciID");

                    b.ToTable("tblTedarikci");
                });

            modelBuilder.Entity("E_ticaret.Models.Urunler", b =>
                {
                    b.Property<int>("UrunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunID"), 1L, 1);

                    b.Property<int>("BoyutSecenekleri")
                        .HasColumnType("int");

                    b.Property<int>("GelisFiyati")
                        .HasColumnType("int");

                    b.Property<string>("GorselURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Indirim")
                        .HasColumnType("int");

                    b.Property<int>("RenkSecenekleri")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StokDurumu")
                        .HasColumnType("int");

                    b.Property<int>("TedarikciID")
                        .HasColumnType("int");

                    b.Property<string>("UrunAciklamasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrunAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UrunFiyati")
                        .HasColumnType("int");

                    b.Property<int>("UrunKategorisi")
                        .HasColumnType("int");

                    b.HasKey("UrunID");

                    b.ToTable("tblUrunler");
                });

            modelBuilder.Entity("E_ticaret.Models.Yetkili", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yetkiler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YetkiliAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YetkiliSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblYetkili");
                });
#pragma warning restore 612, 618
        }
    }
}
