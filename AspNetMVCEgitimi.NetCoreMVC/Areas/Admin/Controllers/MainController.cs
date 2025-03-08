using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")] // bu controller ın admin areası altında çalışacağını ifade ediyoruz
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
