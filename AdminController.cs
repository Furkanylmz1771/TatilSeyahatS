using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatilVeSeyahatSitesi.Models.Siniflar;

namespace TatilVeSeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();

        [Authorize]     // Eğer kişi yetkisi olan bir sayfaya giriş yapmaya çalışıyorsa 
                         // ancak oturum acmadıysa Web.config sayfasına yönlendirilir.
                       
        // <authentication mode ="Forms">
       //	<forms loginUrl = "/GirisYap/Login/" ></ forms >
      //</ authentication >


        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }



        [HttpGet]       // Sayfa yüklenince birşey yapma sadece sayfanın boş halini döndür
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]      // Sayfada birşey yaptığımda onu bana döndür
        public ActionResult YeniBlog(Blog p)        // Yeni blog ekleme
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult BlogSil(int id)         // Blog silme
        {
            var b = c.Blogs.Find(id);            //id'den gelen değeri bul
            c.Blogs.Remove(b);                // b'den gelen değeri sil
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);     // BlogGetir sayfasını döndür döndürüken bl'Den gelen değerleri de getir.
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)         // Blog silme
        {
            var b = c.Yorumlars.Find(id);            //id'den gelen değeri bul
            c.Yorumlars.Remove(b);                // b'den gelen değeri sil
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }




        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);     // BlogGetir sayfasını döndür döndürüken bl'Den gelen değerleri de getir.
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
          yrm.Mail = y.Mail;
          yrm.Yorum = y.Yorum;
            c.SaveChanges();    
            return RedirectToAction("YorumListesi");
        }

    }
}