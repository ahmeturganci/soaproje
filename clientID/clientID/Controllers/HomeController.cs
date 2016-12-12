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
        public ActionResult Giris()
        {
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
        public JsonResult KategoriCek()
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.KategoriListele());
            s.Close();
        }
        public ActionResult SoruSor()
        {
            return View();
        }
        public JsonResult SoruEkle(ServiceReference1.soru sr)
        {
            s = new ServiceReference1.Service1Client();
            sr = new ServiceReference1.soru()
            {
                baslik = sr.baslik,
                soruIcerik = sr.soruIcerik,
                kategoriId = sr.kategoriId

            };

            sr.kullaniciId = kId;
            sr.onayDurumu = false;
            sr.yayinTarihi = DateTime.Now;


            string sonuc = s.SoruEkle(sr);
            if (sonuc == "+")
                return Json("+");
            else return Json("-");
            s.Close();
        }
        public ActionResult Cevaplarim()
        {
            s = new ServiceReference1.Service1Client();
            return View();
            s.Close();
        }
        public JsonResult KategoriEkle(ServiceReference1.kategori ktg)
        {
            s = new ServiceReference1.Service1Client();
            ktg = new ServiceReference1.kategori()
            {
                kategoriAd = ktg.kategoriAd
            };
            bool sonuc = s.KategoriEkle(ktg);
            if (sonuc)
                return Json("+");
            else
                return Json("-");
        }
        public JsonResult SorulariListele()
        {
            s = new ServiceReference1.Service1Client();
            var sonuc = s.Sorularim();
            return Json(sonuc);
            s.Close();
        }

        public ActionResult SoruGoster()
        {
            return View();
        }
        public JsonResult SoruCek(int soruId)
        {
            s = new ServiceReference1.Service1Client();
            ServiceReference1.sorularim ss = s.hangiSorum(soruId);
            return Json(ss);//soru
            s.Close();
        }
        public JsonResult CevapCek(int soruId)

        {
            s = new ServiceReference1.Service1Client();
            var cevapListe = s.Cevaplarim(soruId);
            //foreach (var item in cevapListe)
            //{
                
            //}
            return Json(cevapListe);
            s.Close();
        }
        public JsonResult YorumCek(int cevapId)
        {
            s = new ServiceReference1.Service1Client();
            var yorumListe = s.Yorumlarim(cevapId);
            //foreach (var item in yorumListe)
            //{
                
            //}
            return Json(yorumListe);
            s.Close();
        }
        public JsonResult CevapVer(ServiceReference1.cevap c)
        {
            s = new ServiceReference1.Service1Client();
            c = new ServiceReference1.cevap()
            {
                cevap1 = c.cevap1,
                soruId = c.soruId

            };
            c.cevapTarihi = DateTime.Now;
            c.kullaniciId = kId;
            bool sonuc = s.SoruyaCevapYaz(c);
            if (sonuc)
                return Json("+", kId.ToString());
            else
                return Json("-", kId.ToString());

            s.Close();




        }
        public JsonResult KulCek()
        {
            if (kId != 0)
                return Json(kId.ToString());
            else
                return Json("-");
        }
        public JsonResult YorumYap(ServiceReference1.yorum y)
        {
            s = new ServiceReference1.Service1Client();
            y = new ServiceReference1.yorum()
            {
                
                yorum1 = y.yorum1,
                kullaniciId = kId,
                cevapId =y.cevapId

            };
            
            y.yorumTarihi = DateTime.Now;
            bool sonuc = s.CevabaYorumYaz(y);
            if (sonuc)
                return Json("+");
            else
                return Json("-");
            s.Close();
        }

        public JsonResult FavoriEkle(int soruId)
        {
            s = new ServiceReference1.Service1Client();

            var favSonuc= s.FavoriSoruEkle(soruId, kId); 
            return Json(favSonuc);
            s.Close();

        }
        public JsonResult Begen(int cevapId, int kullaniciId, int begeniTurId)
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.BegeniCevap(cevapId, kullaniciId, begeniTurId));
            s.Close();
        }
        public JsonResult BegeniCek(int cevapId)
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.BegeniSayisi(cevapId));
            s.Close();
        }
    }
}