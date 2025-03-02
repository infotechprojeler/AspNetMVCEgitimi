using AspNetMVCEgitimi.NetCoreMVC.Models;

namespace AspNetMVCEgitimi.NetCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(); // uygulamada session servislerini aktif et

            builder.Services.AddDbContext<UyeContext>(); // .net core da db context i programa tanýtma

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // uygulama eðer geliþtirme aþamasýnda deðilse (lokalde çalýþmýyorsak)
            {
                app.UseExceptionHandler("/Home/Error"); // global hata yakalamayý aktif et, oluþan hatalarda kullanýcýlarý bu sayfaya yönlendir
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // uygulamaya gelen http istekleri https güvenli sistemine yönlendirilsin
            app.UseStaticFiles(); // uygulamamýz statik dosyalarý (wwwroot altýndaki js,css,resim vb) desteklesin

            app.UseRouting(); // uygulama routing yapýsýný kullansýn

            app.UseSession(); // uygulama session kullanabilsin

            app.UseAuthorization(); // uygulamada yetkilendirme kullanýlabilsin

            app.MapControllerRoute( // kullanýlacak routing yapýsý ayarlarý
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer adres çubuðunda Home/About vb þeklinde bir þey yazmýyorsa varsayýlan olarak Home/Index sayfasýný ekrana getir.

            app.Run(); // yukarýdaki ayarlarla beraber uygulamayý çalýþtýr.
        }
    }
}
