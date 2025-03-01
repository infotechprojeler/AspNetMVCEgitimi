using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimi.NetCoreMVC.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // OnConfiguring metodu .net core da veritabanı ayarlarını yapılandırabildiğimiz metottur.
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=UyeDatabase; integrated security=True; trustservercertificate=True;"); // optionsBuilder üzerinden veritabanı olarak UseSqlServer diyerek sql server kullanacağımızı belirttik. UseSqlServer metoduna string tırnaklarıyla sql connection stringini gönderebiliriz.
            base.OnConfiguring(optionsBuilder);
        }
        // Visual studioda PMC-package manager console ekranını açmak için üst menüden Tools > Nuget package manager > package manager console a tıklayarak aşağıda komut yazım bölümünü aktif edebiliriz.

        // Ef Core da Veritabanı oluşturma:
        // PMC penceresinde add-migration InitialCreate yazıp enter a basıyoruz ve bizim için migrations klasörünü veritabanı oluşturacak InitialCreate adlı class ı oluşturuyor.

        // 2. Adım: PMC penceresinde update-database komutunu yazıp bekliyoruz done komutu gelirse işlem başarılıdır, değilse hata mesajları gelir onları okuyarak çözüm üretmeliyiz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uye>().HasData(
                new Uye
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Ad = "Admin",
                    Soyad = "User",
                    DogumTarihi = DateTime.Now,
                    KullaniciAdi = "admin",
                    Sifre = "123",
                    SifreTekrar = "123",
                    TcKimlikNo = "12345678901",
                    Telefon = "1234567890"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
