using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC18ViewComponentsController : Controller
    {
        private readonly UyeContext _context;

        public MVC18ViewComponentsController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Uyeler);
        }
    }
}
