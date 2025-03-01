using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetMVCEgitimi.NetCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SifreTekrar = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Uyeler",
                columns: new[] { "Id", "Ad", "DogumTarihi", "Email", "KullaniciAdi", "Sifre", "SifreTekrar", "Soyad", "TcKimlikNo", "Telefon" },
                values: new object[] { 1, "Admin", new DateTime(2025, 3, 1, 11, 50, 42, 332, DateTimeKind.Local).AddTicks(414), "admin@admin.com", "admin", "123", "123", "User", "12345678901", "1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uyeler");
        }
    }
}
