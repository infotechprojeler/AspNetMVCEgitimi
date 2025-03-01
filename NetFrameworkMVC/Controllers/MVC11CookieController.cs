using NetFrameworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC11CookieController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC11Cookie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                Response.Cookies.Add(new HttpCookie("userguid", Guid.NewGuid().ToString()));

                var cookieAyarlari = new HttpCookie("username", "Admin")
                {
                    Expires = DateTime.Now.AddMinutes(1) // oluşacak cookie yaşam geçerlilik süresi
                };
                HttpContext.Response.Cookies.Add(cookieAyarlari);
                TempData["Mesaj"] = @"<div class='alert alert-success'>Giriş Başarılı!</div>";
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] == null || HttpContext.Request.Cookies["userguid"] == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            TempData["kullaniciAdi"] = HttpContext.Request.Cookies["username"].Value;
            TempData["kullaniciguid"] = HttpContext.Request.Cookies["userguid"].Value;
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(-1);
            }
            if (HttpContext.Request.Cookies["userguid"] != null)
            {
                HttpContext.Response.Cookies["userguid"].Expires = DateTime.Now.AddSeconds(-1);
            }
            TempData["Mesaj"] = @"<div class='alert alert-danger'>Oturumuz Sonlandırıldı!</div>";
            return RedirectToAction("Index");
        }
    }
}