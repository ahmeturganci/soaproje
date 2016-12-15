using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace clientID.Controllers
{
    public class ProfilController : Controller
    {

        ServiceReference1.Service1Client s;
        public ActionResult Index()
        {
            return View();
        }
        


    }
}