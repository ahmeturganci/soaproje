using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clientID.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client s;
        public ActionResult Index()
        {
            return View();
            s.Close();
        }
        public JsonResult GirisYap(string kulAd, string sifre)
        {
            ServiceReference1.kullanici k = new ServiceReference1.kullanici();
            k.kullaniciAdi = kulAd;
            k.sifre = sifre;

            int sonuc = s.GirisYap(k);
            if (sonuc != 0)
                return Json("+");
            else
                return Json("-");
            s.Close();
        }
        public JsonResult Kaydol(ServiceReference1.kullanici kul)
        {
            s = new ServiceReference1.Service1Client();
            s.KayitOl(kul);
            return Json("+");
            s.Close();
        }

        public JsonResult Listele()
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.Sorular());
            s.Close();
        }
        public ActionResult Giris()
        {
            s = new ServiceReference1.Service1Client();
            return View();
            s.Close();
        }
        public ActionResult SoruSor()
        {
            s = new ServiceReference1.Service1Client();
            ServiceReference1.soru ss = new ServiceReference1.soru();
            s.SoruEkle(ss);
            return View();
            s.Close();
        }
        public ActionResult Cevaplarim()
        {
            s = new ServiceReference1.Service1Client();
            return View();
            s.Close();
        }


    }
}