using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var mesaj = "RouteData controller : " + RouteData.Values["controller"];
            mesaj += "<hr/>RouteData Action : " + RouteData.Values["action"];
            mesaj += "<hr/>RouteData Id : " + RouteData.Values["id"];
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.Query["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
