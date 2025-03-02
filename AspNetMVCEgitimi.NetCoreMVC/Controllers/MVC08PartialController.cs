using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC08PartialController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC08Partial
        public ActionResult Index()
        {
            return View(context.Uyeler.ToList());
        }
    }
}
