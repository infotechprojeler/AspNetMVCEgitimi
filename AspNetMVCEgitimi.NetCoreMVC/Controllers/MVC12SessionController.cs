using AspNetMVCEgitimi.NetCoreMVC.Extensions;
using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC12SessionController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                // .net core da aşağıdaki kodlar desteklenmiyor
                //Session["deger"] = "Admin"; // session a değer atama
                //Session["userguid"] = Guid.NewGuid().ToString();
                //Session["kullanici"] = kullanici;
                HttpContext.Session.SetString("Kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz
                HttpContext.Session.SetString("Sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);
                HttpContext.Session.SetString("UserGuid", Guid.NewGuid().ToString());
                HttpContext.Session.SetJson("uye", kullanici); // kendi yazdığımız nesneyi json a dönüştürüp session da saklayabilmemizi sağlayan extension metodu.
                TempData["Mesaj"] = @"<div class='alert alert-success'>Giriş Başarılı!</div>";
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult SessionOku()
        {
            if (HttpContext.Session.GetString("Kullanici") == null || HttpContext.Session.GetString("UserGuid") == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            // TempData["SessionBilgi"] = Session["deger"]; // session daki veriye ulaşma - .net core da kaldırıldı
            TempData["SessionBilgi"] = HttpContext.Session.GetString("Kullanici");
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger");
            //Session["userguid"] = null; // bunlar da .net core da kaldırıldı.
            //Session["kullanici"] = null;
            //HttpContext.Session.RemoveAll();
            HttpContext.Session.Clear(); // sessionları genel temizleme
            return RedirectToAction("Index");
        }
    }
}
