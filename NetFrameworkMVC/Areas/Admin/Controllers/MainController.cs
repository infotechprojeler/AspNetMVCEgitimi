using System.Web.Mvc;

namespace NetFrameworkMVC.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Admin/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}