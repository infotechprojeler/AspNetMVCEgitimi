using AspNetMVCEgitimi.NetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC06CRUDController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC06CRUDController
        public ActionResult Index()
        {
            return View(context.Uyeler.ToList());
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
