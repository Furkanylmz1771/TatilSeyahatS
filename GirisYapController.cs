using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatilVeSeyahatSitesi.Models.Siniflar;

namespace TatilVeSeyahatSitesi.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]  // Sayfada bir veri işlemi gerçekleştiği zaman

        public ActionResult Login(Admin ad)                 // Giriş işlemi
        {
            var bilgiler =c.Admins.FirstOrDefault(x=>x.Kullanici==ad.Kullanici&& x.Sifre==ad.Sifre);    // Giriş kontrol    
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()            // Çıkış işlemi
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }

    }
}