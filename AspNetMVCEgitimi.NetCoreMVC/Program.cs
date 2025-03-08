using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // oturum a�ma k�t�phanesi

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

            builder.Services.AddDbContext<UyeContext>(); // .net core da db context i programa tan�tma

            // Uygulamada Authentication servisini kullan:
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/MVC15FiltersUsing/Login"; // Admin oturum acma sayfam�z� belirttik
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // uygulama e�er geli�tirme a�amas�nda de�ilse (lokalde �al��m�yorsak)
            {
                app.UseExceptionHandler("/Home/Error"); // global hata yakalamay� aktif et, olu�an hatalarda kullan�c�lar� bu sayfaya y�nlendir
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // uygulamaya gelen http istekleri https g�venli sistemine y�nlendirilsin
            app.UseStaticFiles(); // uygulamam�z statik dosyalar� (wwwroot alt�ndaki js,css,resim vb) desteklesin

            app.UseRouting(); // uygulama routing yap�s�n� kullans�n

            app.UseSession(); // uygulama session kullanabilsin

            app.UseAuthorization(); // uygulamada yetkilendirme kullan�labilsin

            // Uygulamaya area ekledikten sonra a�a��daki route ayar�n� ekliyoruz.
            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
                );

            app.MapControllerRoute( // kullan�lacak routing yap�s� ayarlar�
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er adres �ubu�unda Home/About vb �eklinde bir �ey yazm�yorsa varsay�lan olarak Home/Index sayfas�n� ekrana getir.

            app.Run(); // yukar�daki ayarlarla beraber uygulamay� �al��t�r.
        }
    }
}
