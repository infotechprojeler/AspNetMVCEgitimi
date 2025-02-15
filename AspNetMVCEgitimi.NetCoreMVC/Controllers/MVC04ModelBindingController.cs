using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult KullaniciDetay()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            return View(kullanici); // yukarıda tanımladığımız kullanici nesnesini sayfaya model datası olarak gönder.
        }
        [HttpPost]
        public ActionResult KullaniciDetay(Kullanici kullanici) // Burada belirttiğimiz kullanici nesnesi view sayfasındaki model kullanan form içerisindeki verileri model binding yöntemiyle yakalıyor.
        {
            // todo: burada gelen kullanici nesnesini veritabanına kaydedebiliriz.
            return View(kullanici); // sayfadan gelen kullanici nesnesini sayfaya model datası olarak gönder.
        }
        public ActionResult AdresDetay()
        {
            var model = new Adres { Ilce = "Şişli", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" };
            return View(model);
        }
        [HttpPost]
        public ActionResult AdresDetay(Adres adres)
        {
            // Projelerde bu noktada yakaladığımız adres nesnesini veritabanına kaydederiz.
            return View(adres);
        }
        public ActionResult KullaniciAdresDetay()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            var model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = new Adres { Ilce = "Şişli", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" }
            };
            return View(model);
        }
    }
}
