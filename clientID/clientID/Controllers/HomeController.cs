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
        public static int kId = 0;
        public ActionResult Index()
        {
            if (Request.Cookies["idUserID"] == null)
            {
                Response.Redirect("/Home/Giris");

            }
            return View();
        }
        public JsonResult GirisYap(string kulAd, string sifre)
        {
            s = new ServiceReference1.Service1Client();
            ServiceReference1.kullanici k = new ServiceReference1.kullanici();
            k.kullaniciAdi = kulAd;
            k.sifre = sifre;

            kId = s.GirisYap(k);

            if (k != null && kId != 0)
            {
                Response.Cookies["idUserID"].Value = k.kullaniciId.ToString();
                Response.Cookies["idUserID"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["idUserName"].Value = k.kullaniciAdi.ToString();
                Response.Cookies["idUserName"].Expires = DateTime.Now.AddDays(1);

                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);
                return Json("+");

            }
            else
                return Json("- Giriş yapılamadı.");
            s.Close();
        }
        public JsonResult Cikis()
        {
            Response.Cookies["idUserID"].Value = null;
            Response.Cookies["idUserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["idUserName"].Value = null;
            Response.Cookies["idUserName"].Expires = DateTime.Now.AddDays(-1);

            HttpCookie aCookie = new HttpCookie("lastVisit");
            aCookie.Value = DateTime.Now.ToString();
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
            return Json("+");

        }
        public JsonResult Kaydol(ServiceReference1.kullanici kul)
        {
            s = new ServiceReference1.Service1Client();
            kul = new ServiceReference1.kullanici()
            {
                kullaniciAdi = kul.kullaniciAdi,
                sifre = kul.sifre,
                email = kul.email
            };
            kId = s.KayitOl(kul);

            if (kId == 0)
                return Json("+");
            else
                return Json("-");
            s.Close();
        }

        public JsonResult Listele()
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.SoruListele());


            s.Close();
        }
        public ActionResult Giris()
        {
            return View();
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