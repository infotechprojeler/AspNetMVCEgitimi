using System.Web.Configuration;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC14AppSetting
        public ActionResult Index()
        {
            // Web uygulamalarımızda bazı durumlarda config dosyasında veri saklayıp(örneğin email ayarlarını burada tutabiliriz) uygulama içerisinden bu verilere ulaşıp kullanmamız gerekebiliyor, bu durumda burada yazdığımız kodlarla verileri ihtiyaç duyduğumuz yerde çekebiliriz.
            ViewBag.MailinGidecegiAdres = WebConfigurationManager.AppSettings["EmailAdresi"];
            ViewBag.MailKullaniciAdi = WebConfigurationManager.AppSettings["EmailUsername"];
            ViewBag.MailSifre = WebConfigurationManager.AppSettings["EmailPassword"];
            return View();
        }
    }
}