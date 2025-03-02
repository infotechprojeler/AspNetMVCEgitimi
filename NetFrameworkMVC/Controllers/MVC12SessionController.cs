using NetFrameworkMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC12SessionController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC12Session
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                Session["deger"] = "Admin"; // session a değer atama
                Session["userguid"] = Guid.NewGuid().ToString();
                Session["kullanici"] = kullanici;
                TempData["Mesaj"] = @"<div class='alert alert-success'>Giriş Başarılı!</div>";
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult SessionOku()
        {
            TempData["SessionBilgi"] = Session["deger"]; // session daki veriye ulaşma
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger");
            Session["userguid"] = null;
            Session["kullanici"] = null;
            HttpContext.Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}