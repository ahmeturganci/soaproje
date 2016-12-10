using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using serviceID.Model.ViewModel;
using serviceID.Model.DataModel;

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

        public List<sorularim> SoruAra(string soruBaslik)
        {
            return KullaniciIslem.SoruAra(soruBaslik);
        }

        public string SoruEkle(soru soru)
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

        public List<soruView> SoruListele()
        {
            return KullaniciIslem.SoruListele();
        }

        public List<string> KategoriListele()
        {
            return KullaniciIslem.KategoriListele();
        }

        public List<string> EtiketListele()
        {
            return KullaniciIslem.EtiketListele();
        }

        public List<sorularim> Sorularim()
        {
            return KullaniciIslem.Sorularim();
                 
        }

        public List<cevaplarim> Cevaplarim(int soruId)
        {
            return KullaniciIslem.Cevaplarim(soruId);
        }

        public List<yorumlarim> Yorumlarim(int cevapId)
        {
            return KullaniciIslem.Yorumlarim(cevapId);
        }

        public sorularim hangiSorum(int soruId)
        {
            return KullaniciIslem.hangiSorum(soruId);
        }

        public char FavoriSoruEkle(int soruId,int kullaniciId)
        {
            return KullaniciIslem.FavoriSoruEkle(soruId, kullaniciId);
        }
    }
}
