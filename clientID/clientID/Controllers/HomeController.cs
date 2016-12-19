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
            //if (Request.Cookies["idUserID"] == null)
            //{
            //    Response.Redirect("/Home/Giris");
            //}
            if (Session["kId"] == null)
            {
                Response.Redirect("/Home/Giris");
            }
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        public ActionResult SoruGoster()
        {
            return View();
        }
        public ActionResult SoruSor()
        {
            return View();
        }

        public JsonResult GirisYap(string kulAd, string sifre)
        {
            using (s = new ServiceReference1.Service1Client())
            {
                ServiceReference1.kullanici k = new ServiceReference1.kullanici();
                k.kullaniciAdi = kulAd;
                k.sifre = sifre;
                int kId = s.GirisYap(k);

                s.Close();

                if (k != null && kId != 0)
                {
                    //Response.Cookies["idUserID"].Value = k.kullaniciId.ToString();
                    //Response.Cookies["idUserID"].Expires = DateTime.Now.AddDays(1);
                    //Response.Cookies["idUserName"].Value = k.kullaniciAdi.ToString();
                    //Response.Cookies["idUserName"].Expires = DateTime.Now.AddDays(1);

                    //HttpCookie aCookie = new HttpCookie("lastVisit");
                    //aCookie.Value = DateTime.Now.ToString();
                    //aCookie.Expires = DateTime.Now.AddDays(1);
                    //Response.Cookies.Add(aCookie);
                    Session.Add("kId", kId);
                    return Json("+");

                }
                else
                    return Json("- Giriş yapılamadı.");


            }
        }

        public ActionResult Cikis()
        {
            //Response.Cookies["idUserID"].Value = null;
            //Response.Cookies["idUserID"].Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies["idUserName"].Value = null;
            //Response.Cookies["idUserName"].Expires = DateTime.Now.AddDays(-1);

            //HttpCookie aCookie = new HttpCookie("lastVisit");
            //aCookie.Value = DateTime.Now.ToString();
            //aCookie.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Add(aCookie);
            Session.Remove("kId");
            return View("Giris");

        }

        public JsonResult Kaydol(ServiceReference1.kullanici kul)
        {
            using (s = new ServiceReference1.Service1Client())
            {
                kul = new ServiceReference1.kullanici()
                {
                    kullaniciAdi = kul.kullaniciAdi,
                    sifre = kul.sifre,
                    email = kul.email
                };
                int sonuc = s.KayitOl(kul);
                s.Close();
                if (sonuc == 0)
                    return Json("+");
                else
                    return Json("-");
            }



        }

        public JsonResult KategoriCek()
        {
            s = new ServiceReference1.Service1Client();
            return Json(s.KategoriListele());
            s.Close();
        }

        public JsonResult SoruEkle(ServiceReference1.soru sr)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
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
                s.Close();
                if (sonuc == "+")
                    return Json("+");
                else return Json("-");
            }

        }

        public JsonResult KategoriEkle(ServiceReference1.kategori ktg)
        {
            using (s = new ServiceReference1.Service1Client())
            {
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
        }

        public JsonResult SorulariListele()
        {
            using (s = new ServiceReference1.Service1Client())
            {
                var sonuc = s.Sorularim();
                s.Close();

                return Json(sonuc);
            }
        }

        public JsonResult SoruCek(int soruId)
        {
            using (s = new ServiceReference1.Service1Client())
            {
                ServiceReference1.sorularim ss = s.hangiSorum(soruId);
                s.Close();
                return Json(ss);//soru
            }

        }

        public JsonResult CevapCek(int soruId)

        {
            using (s = new ServiceReference1.Service1Client())
            {
                var cevapListe = s.Cevaplarim(soruId);
                s.Close();
                return Json(cevapListe);
            }

        }
        public JsonResult YorumCek(int cevapId)
        {
            s = new ServiceReference1.Service1Client();
            var yorumListe = s.Yorumlarim(cevapId);
            s.Close();
            return Json(yorumListe);

        }

        public JsonResult CevapVer(ServiceReference1.cevap c)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                c = new ServiceReference1.cevap()
                {
                    cevap1 = c.cevap1,
                    soruId = c.soruId

                };
                c.cevapTarihi = DateTime.Now;
                c.kullaniciId = kId;
                bool sonuc = s.SoruyaCevapYaz(c);
                s.Close();
                if (sonuc)
                    return Json("+", kId.ToString());
                else
                    return Json("-", kId.ToString());
            }
        }

        public JsonResult KulCek()
        {
            int kId = int.Parse(Session["kId"].ToString());
            if (kId != 0)
                return Json(kId.ToString());
            else
                return Json("-");
        }

        public JsonResult YorumYap(ServiceReference1.yorum y)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                y = new ServiceReference1.yorum()
                {
                    yorum1 = y.yorum1,
                    kullaniciId = kId,
                    cevapId = y.cevapId
                };
                y.yorumTarihi = DateTime.Now;
                bool sonuc = s.CevabaYorumYaz(y);
                s.Close();
                if (sonuc)
                    return Json("+");
                else
                    return Json("-");
            }
        }

        public JsonResult FavoriEkle(int soruId)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                var favSonuc = s.FavoriSoruEkle(soruId, kId);
                s.Close();

                return Json(favSonuc);
            }
        }

        public JsonResult FavoriSoruKontrol(int soruId)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                var favSonuc = s.FavoriSoruKontrol(soruId, kId);
                s.Close();

                return Json(favSonuc);
            }
        }

        public JsonResult CevapBegen(int cevapId, int begeniTurId)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                s.Close();
                var sonuc = s.BegeniCevap(cevapId, kId, begeniTurId);
                return Json(sonuc);
            }

        }

        public JsonResult BegeniCek(int cevapId)
        {
            using (s = new ServiceReference1.Service1Client())
            {

                var sonuc = s.BegeniSayisi(cevapId);
                s.Close();
                return Json(sonuc);


            }

        }

        public JsonResult SoruAra(string baslik)
        {
            using (s = new ServiceReference1.Service1Client())
            {
                s.Close();
                return Json(s.SoruAra(baslik));
            }
        }

        public JsonResult CevapOnay(int sId, int cId)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                var sss = s.CevapOnayla(kId, sId, cId);
                s.Close();
                return Json(sss);
            }
        }


        public JsonResult SifreDegistir(string eski, string yeni)
        {
            int kId = int.Parse(Session["kId"].ToString());
            using (s = new ServiceReference1.Service1Client())
            {
                s.Close();
                var sonuc = s.SifreGuncelle(eski, yeni, kId);
                return Json(sonuc);

            }

        }

    }
}