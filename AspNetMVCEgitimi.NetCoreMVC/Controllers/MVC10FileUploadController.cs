using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NetCoreMVC.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya) // .net core da dosya yükleme için IFormFile interface i kullanılıyor. Burada ekrandaki form içindeki file upload a verilen name değeri(dosya) ne ise parametreye onu yazmalıyız yoksa dosya yüklenmez!
        {
            if (dosya is not null)
            {
                var uzanti = Path.GetExtension(dosya.FileName); // formdan gönderilen dosyanın uzantısını kontrol edebilmemizi sağlar.
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                var klasorVarmi = Directory.Exists(klasor); // belirtilen yolda yükleme yapacağımız klasör var mı?
                if (klasorVarmi == false)
                {
                    var sonuc = Directory.CreateDirectory(klasor); // ana dizine yükleme klasörü oluştur.
                    TempData["Message"] = " - Klasör Oluşturuldu";
                }
                if (uzanti == ".jpg" ||uzanti == ".jpeg" ||uzanti == ".png" ||uzanti == ".gif" ||uzanti == ".webp")
                {

                }
                else
                    TempData["Message"] = " Sadece .jpg, .jpeg, png, gif, webp dosyaları yükleyebilirsiniz!";
            }
            return View();
        }
        [HttpPost]
        public ActionResult ResimSil(string resimYolu)
        {
            if (System.IO.File.Exists(resimYolu))
            {
                System.IO.File.Delete(resimYolu);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
