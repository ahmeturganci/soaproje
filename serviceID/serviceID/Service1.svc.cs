using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using serviceID.Model;
using serviceID.Model.ViewModel;

using serviceID.BL;

namespace serviceID
{
   
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public int GirisYap(kullanici kullanici)
        {
            return KullaniciIslem.GirisYap(kullanici);
        }

        public bool KategoriEkle(kategori kategori)
        {
            return KullaniciIslem.KategoriEkle(kategori);
        }

        public int KayitOl(kullanici kul)
        {
            return KullaniciIslem.KayitOl(kul);
        }

        public soru SoruAra(string soruBaslik)
        {
            return KullaniciIslem.SoruAra(soruBaslik);
        }

        public bool SoruEkle(soru soru)
        {
            return KullaniciIslem.SoruEkle(soru);
        }

        public List<soruView> Sorular()
        {
            return KullaniciIslem.Sorular();
        }

        public bool SoruyaCevapYaz(cevap cevap)
        {
            return KullaniciIslem.SoruyaCevapYaz(cevap);
        }

        public bool CevabaYorumYaz(yorum yorum)
        {
            return KullaniciIslem.CevabaYorumYaz(yorum);
        }

        public bool EtiketEkle(etiket etiket)
        {
            return KullaniciIslem.EtiketEkle(etiket);
        }

        public bool SoruFavoriEkle(favori fav)
        {
            throw new NotImplementedException();
        }
    }
}
