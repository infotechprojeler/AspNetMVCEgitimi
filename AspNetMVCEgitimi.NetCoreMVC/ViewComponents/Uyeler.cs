using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.ViewComponents
{
    public class Uyeler : ViewComponent
    {
        private readonly UyeContext _context;

        public Uyeler(UyeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string secili)
        {
            // _context.uyeler ile istersek burada da data çekme işlemi yapıp komponente view içerisine yazarak gönderebiliriz.
            ViewBag.Secili = secili;
            return View();
        }
    }
}
