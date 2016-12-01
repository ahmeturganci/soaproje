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
        //ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
        //servis yazıldıktan sonra bu kısıma adapte edilecektir.
        public ActionResult Giris()
        {
            
            return View();
        }
        //public JsonResult GirisYap(string kulAd,string sifre)
        //{
        //    string sonuc=s.GirisYap(kulAd,sifre);
        //    return Json("+");
        //}
        //public JsonResult Kaydol(ServiceReference1.kullanici kul)
        //{
        //    s.KayitOl(kul);
        //    return Json("+");
        //}

    }
}