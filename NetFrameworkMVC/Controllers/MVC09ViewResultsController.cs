using NetFrameworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC09ViewResults
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public ActionResult Yonlendir()
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            // return Redirect("/Home"); // işlem sonucunda anasayfaya yönlendir
            return Redirect("https://www.google.com.tr/");// işlem sonucunda google a yönlendir
        }
        public ActionResult ActionaYonlendir()
        {
            // return RedirectToAction("Index");// işlem sonucunda Action a yönlendir
            // return RedirectToAction("Yonlendir");
            return RedirectToAction("Index", "Home");
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial()
        {
            return PartialView("_KategorilerPartial");
        }
        public PartialViewResult PartialdaModelKullanimi()
        {
            var kullanicilar = context.Uyeler.ToList();
            return PartialView("_PartialModelKullanimi", kullanicilar);
        }
        public ActionResult JsResult()
        {
            return JavaScript("console.log('JavaScript Result')");
        }
        public JsonResult JsonResult()
        {
            var kullanicilar = context.Uyeler.ToList();
            return Json(kullanicilar, JsonRequestBehavior.AllowGet);
        }
        public ContentResult XmlContentResult()
        {
            var kullanicilar = context.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in kullanicilar)
            {
                xml += $@"<kullanici>
                            <Id>{item.Id}</Id>
                            <Ad>{item.Ad}</Ad>
                            <Soyad>{item.Soyad}</Soyad>
                            <KullaniciAdi>{item.KullaniciAdi}</KullaniciAdi>
                            <Email>{item.DogumTarihi}</Email>
                        </kullanici>";
            }
            xml += "</kullanicilar>";
            return Content(xml, "application/xml");
        }
    }
}