using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clientID.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        idService.Service1Client s = new idService.Service1Client();
        public ActionResult Giris()
        {
            
            return View();
        }
        public JsonResult GirisYap(string kulAd,string sifre)
        {
            string sonuc=s.GirisYap(kulAd,sifre);
            return Json("+");
        }
        public JsonResult Kaydol(idService.kullanici kul)
        {
            s.KayitOl(kul);
            return Json("+");
        }

    }
}