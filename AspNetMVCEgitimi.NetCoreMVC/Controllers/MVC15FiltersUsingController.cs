using AspNetMVCEgitimi.NetCoreMVC.Filters;
using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
