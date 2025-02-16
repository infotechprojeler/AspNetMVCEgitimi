using NetFrameworkMVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC06CRUDController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC06CRUD
        public ActionResult Index()
        {
            return View(context.Uyeler.ToList());
        }

        // GET: MVC06CRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // GET: MVC06CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUD/Create
        [HttpPost]
        public ActionResult Create(Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    context.Uyeler.Add(collection);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            
            return View(collection);
        }

        // GET: MVC06CRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return HttpNotFound(); // eğer gelen id ile veritabanında eşleşen bir kayıt bulunamazsa geriye notfound - bulunamadı hatası döndür.
            }
            return View(kayit);
        }

        // POST: MVC06CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Uye collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    context.Entry(collection).State = EntityState.Modified; // ekrandan gönderilen üyeyi dbcontext de güncellenecek olarak işaretle
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(collection);
        }

        // GET: MVC06CRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var kayit = context.Uyeler.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // POST: MVC06CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var kayit = context.Uyeler.Find(id);
                context.Uyeler.Remove(kayit);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
