using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using serviceID.Model;

using serviceID.BL;

namespace serviceID
{
   
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GirisYap(string kulAd, string sifre)
        {
            return KullaniciIslem.GirisYap(kulAd, sifre);
        }
        public void KayitOl(kullanici kul)
        {
            KullaniciIslem.KayitOl(kul);
        }
    }
}
