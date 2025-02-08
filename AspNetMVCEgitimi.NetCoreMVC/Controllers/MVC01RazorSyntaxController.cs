using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
