using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC06CRUDController : Controller
    {
        UyeContext context = new UyeContext(); // klasik yöntemle nesne örneği alma
        private readonly UyeContext _uyeContext; // dependency injection ile nesne örneği alma

        public MVC06CRUDController(UyeContext uyeContext) // üstteki _uyeContext e sağ tıklayıp ampule basıp generate constructor diyerek bu bloğu oluşturuyoruz. Kendimiz elle yazarak da oluşturabiliriz.
        {
            _uyeContext = uyeContext; // yukarıda boş nesne olarak tanımlanan _uyeContext nesnesinin içini bu kurucu metot devreye girdiği anda otomatik olarak bir nesne oluşturup yukardaki boş olanı dolduruyoruz.
        }

        // GET: MVC06CRUDController
        ////public ActionResult Index()
        ////{
        ////    //return View(context.Uyeler.ToList());
        ////    return View(_uyeContext.Uyeler.ToList()); // DI ile kullanım örneği
        ////}
        public async Task<ActionResult> Index() // Bir metodu asenkron yapınca ActionResult ı async ile işaretleyip Task(görev) olarak tanımlıyoruz. Asenkron metotların uzantısı Async yapılıyor.
        {
            return View(await _uyeContext.Uyeler.ToListAsync()); // içinde asenkron işlem yapılan metotların da asenkron olması gerekir! Altı kızaran yerin üzerine gelip açılan menüden make method async e basarsak bizim için işlemi yapacaktır.
        }

        // GET: MVC06CRUDController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Geçersiz İstek! Id Bilgisi Gereklidir!");
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return NotFound("Id Bilgisiyle Eşleşen Bir Kayıt Bulunamadı!");
            }
            return View(kayit);
        }

        // GET: MVC06CRUDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Uyeler.Add(collection);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }            
            return View(collection);
        }

        // GET: MVC06CRUDController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Geçersiz İstek! Id Bilgisi Gereklidir!");
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return NotFound("Id Bilgisiyle Eşleşen Bir Kayıt Bulunamadı!");
            }
            return View(kayit);
        }

        // POST: MVC06CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Uyeler.Update(collection); // ef core da kayıt güncelleme için update metodunu kullanıyoruz
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(collection);
        }

        // GET: MVC06CRUDController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Geçersiz İstek! Id Bilgisi Gereklidir!");
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return NotFound("Id Bilgisiyle Eşleşen Bir Kayıt Bulunamadı!");
            }
            return View(kayit);
        }

        // POST: MVC06CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Uye collection)
        {
            try
            {
                if (collection.Id == 1)
                {
                    return BadRequest("Admin Kullanıcısı Silinemez!");
                }
                else
                {
                    context.Uyeler.Remove(collection);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }                
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }
    }
}
