using NetFrameworkMVC.Filters;
using NetFrameworkMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace NetFrameworkMVC.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC15FiltersUsing
        public ActionResult Index()
        {            
            return View();
        }
        [UserControl] // aşağıdaki action çalışırken UserControl içindeki kontrolleri yap
        public ActionResult FiltreKullanimi()
        {
            ViewBag.Kullanici = HttpContext.Session["userguid"];
            return View();
        }
        [Authorize] // .net içerisinde yer alan güvenlik filtresi
        public ActionResult UyeGuncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Uye uye = context.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
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
        public ActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            try
            {
                var kullanici = context.Uyeler.Any(u => u.Email == uye.Email && u.Sifre == uye.Sifre);
                if (kullanici)
                {
                    Session["Admin"] = kullanici;
                    FormsAuthentication.SetAuthCookie(uye.Email, true);
                    return RedirectToAction("Index");
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}