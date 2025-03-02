using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC14AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Web uygulamalarımızda bazı durumlarda config dosyasında veri saklayıp(örneğin email ayarlarını burada tutabiliriz) uygulama içerisinden bu verilere ulaşıp kullanmamız gerekebiliyor, bu durumda burada yazdığımız kodlarla verileri ihtiyaç duyduğumuz yerde çekebiliriz.
            ViewData["Email"] = _configuration["Email"]; // TempData ile appsettings deki Email bilgisini okuyup view a gönderdik
            ViewData["MailSunucu"] = _configuration["MailSunucu"];
            ViewData["KullaniciAdi"] = _configuration["MailKullanici:UserName"]; // json daki MailKullanici altındaki Username değerine : ile ulaşıyoruz
            ViewData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value;// GetSection metoduyla da veriyi çekebiliriz
            return View();
        }
    }
}
