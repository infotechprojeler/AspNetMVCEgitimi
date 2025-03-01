using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        // GET: MVC16HttpContext
        public ActionResult Index()
        {
            var mesaj = "RouteData controller : " + RouteData.Values["controller"];
            mesaj += "<hr/>RouteData Action : " + RouteData.Values["action"];
            mesaj += "<hr/>RouteData Id : " + RouteData.Values["id"];
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.QueryString["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}