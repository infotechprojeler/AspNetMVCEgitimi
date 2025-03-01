using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC06CRUDController : Controller
    {
        // GET: MVC06CRUDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MVC06CRUDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MVC06CRUDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MVC06CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MVC06CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MVC06CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MVC06CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
