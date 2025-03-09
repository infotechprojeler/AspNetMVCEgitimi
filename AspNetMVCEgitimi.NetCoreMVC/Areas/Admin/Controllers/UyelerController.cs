using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimi.NetCoreMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UyelerController : Controller
    {
        private readonly UyeContext _context; // _context e sağ klik > ampüle tıkla > açılan menüden generate constructor a tıkla

        public UyelerController(UyeContext context) // constructor metodu bu parametreyi görünce yeni bir context örneği oluşturur.
        {
            _context = context; // oluşturduğu context nesnesini bu satırda üstte boş olarak tanımladığımız _context nesnesini doldurmak için kullanır.
        }

        // GET: UyelerController
        public ActionResult Index()
        {
            var model = _context.Uyeler;
            return View(model);
        }

        // GET: UyelerController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            // var model = _context.Uyeler.Find(id); // 1. yöntem - senkron
            var model = await _context.Uyeler.FindAsync(id); // 2. yöntem - asenkron
            return View(model);
        }

        // GET: UyelerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UyelerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // senkron ekleme
                    //_context.Uyeler.Add(collection);
                    //_context.SaveChanges();

                    // asenkron ekleme
                    await _context.Uyeler.AddAsync(collection);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception hata) // (Exception hata) ile oluşan hatayı yakalarız.
                {
                    ModelState.AddModelError("", "Hata Oluştu! " + hata.InnerException);
                }
            }
            return View(collection);
        }

        // GET: UyelerController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            //var model = _context.Uyeler.Find(id);
            // var model = _context.Uyeler.FirstOrDefault(x => x.Id == id);
            var model = await _context.Uyeler.FirstOrDefaultAsync(x => x.Id == id);

            return View(model);
        }

        // POST: UyelerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(collection); // ef de Update metodunun asenkron versiyonu yok!
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: UyelerController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        // POST: UyelerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Uye collection)
        {
            try
            {
                _context.Uyeler.Remove(collection); // Remove metodunun async versiyonu yok
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
