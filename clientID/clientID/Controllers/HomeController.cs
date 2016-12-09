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

        public JsonResult SorulariListele()
        {
            s = new ServiceReference1.Service1Client();
            var sonuc = s.Sorularim();
            return Json(sonuc);
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
                kategoriId=sr.kategoriId

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


        public int parcala(string s)
        {
           
                char[] arr = s.ToArray();
                string res = "";
                string res2 = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    res += arr[i];
                    if (arr[i] == ',')
                    {
                        res = res.TrimEnd(',');
                        for (int j = i + 1; j < arr.Length; j++)
                        {
                            res2 += arr[j];
                        }
                        break;
                    }
                }
                
            
            return Convert.ToInt16(res);
        }
    }
}