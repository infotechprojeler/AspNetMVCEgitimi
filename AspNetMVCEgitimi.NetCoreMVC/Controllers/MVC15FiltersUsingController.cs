using AspNetMVCEgitimi.NetCoreMVC.Extensions;
using AspNetMVCEgitimi.NetCoreMVC.Filters;
using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {            
            return View();
        }
        [UserControl]
        public ActionResult FiltreKullanimi()
        {
            ViewBag.Kullanici = HttpContext.Session.GetString("UserGuid"); // HttpContext.Session["userguid"]; // .net core da session okuma farklı!
            return View();
        }
        [Authorize] // .net içerisinde yer alan güvenlik filtresi
        public ActionResult UyeGuncelle(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Bilgisi Gereklidir!");
            }
            Uye uye = context.Uyeler.Find(id);
            if (uye == null)
            {
                return NotFound("Verilen Id ile Eşleşen Üye Bulunamadı!");
            }
            return View(uye);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UyeGuncelle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                context.Entry(uye).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Uye uye)
        {
            try
            {
                var kullanici = context.Uyeler.FirstOrDefault(u => u.Email == uye.Email && u.Sifre == uye.Sifre);
                if (kullanici != null)
                {
                    HttpContext.Session.SetJson("uye", kullanici);
                    // Session["Admin"] = kullanici; // .net core da çalışmıyor
                    // FormsAuthentication.SetAuthCookie(uye.Email, true); // .net core da çalışmıyor
                    // Adım 1
                    var haklar = new List<Claim>() // kullanıcı hakları tanımladık
                    {
                        new(ClaimTypes.Email, kullanici.Email), // claim = hak(kullanıcıya tanımlalan haklar)
                        new(ClaimTypes.Role, "Admin")
                    };
                    // Adım 2
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcı için bir kimlik oluşturduk
                    // Adım 3
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi); // üstte tanımladığımız kullaniciKimligi nesnesindeki bilgilerle yetki prensipleri-kuralları gibi bir nesne daha oluşturuyoruz.
                    // Adım 4
                    await HttpContext.SignInAsync(claimsPrincipal); // yukardaki yetkilerle sisteme giriş yaptık
                    return RedirectToAction("UyeGuncelle");
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(uye);
        }
        [HttpPost]
        public async Task<ActionResult> LogoutAsync()
        {
            //FormsAuthentication.SignOut(); // .net core da çalışmıyor
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
