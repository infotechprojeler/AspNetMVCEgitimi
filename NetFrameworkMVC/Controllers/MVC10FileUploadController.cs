﻿using System.IO; // dosya işlemleri kütüphanesi
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVC.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        // GET: MVC10FileUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya) // Ön yüzde file upload elementine name olarak ne isim verdiysek onu kullanmalıyız
        {
            if (dosya != null)
            {
                var uzanti = Path.GetExtension(dosya.FileName); // Dosya uzantı kontrolü yapmak istersek
                var klasor = Server.MapPath("/Images");// Resmi yükleyeceğimiz klasör(Eğer projede bu klasör yoksa oluşturmalıyız yoksa hata verir!)
                var klasorVarmi = Directory.Exists(klasor); // sunucuda bu klasör var mı?
                TempData["Message"] = "klasorVarmi : " + klasorVarmi;
                if (klasorVarmi == false) // eğer sunucuda bu konumda klasör yoksa
                {
                    var sonuc = Directory.CreateDirectory(klasor); // ana dizine Images klasörü oluştur
                    TempData["Message"] += " - Klasör Oluşturuldu.. " + sonuc;
                }
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif")// Sadece bu uzantılardaki dosyaları kabul et
                {

                    // 1. Yöntem Random(Rastgele) İsimle Dosya Yükleme
                    //var randomFileName = Path.GetRandomFileName(); // rasgele dosya ismi oluşturma metodu
                    //var fileName = Path.ChangeExtension(randomFileName, ".jpg"); // dosya adı ve uzantısını değiştirip birleştirdik
                    //var path = Path.Combine(klasor, fileName); // klasör ve resim adını birleştirdik
                    //dosya.SaveAs(path); // resmi farklı kaydet metoduyla sunucuya yüklüyoruz.
                    //TempData["Resim"] = fileName;
                    
                    // 2. Yöntem - Resmi Kendi Adıyla Yükleme
                    //var dosyaAdi = Path.GetFileName(dosya.FileName);
                    //var yol = Path.Combine(klasor, dosyaAdi);
                    //dosya.SaveAs(yol);
                    //TempData["Resim"] = dosyaAdi;
                    
                    // 3. Yönetem - Resmi direk sunucuya yollama
                    dosya.SaveAs(Server.MapPath("/Images/" + dosya.FileName));
                    TempData["Resim"] = dosya.FileName;

                    return RedirectToAction("Index");
                }
                else
                    TempData["message"] = @"Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz! ";
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