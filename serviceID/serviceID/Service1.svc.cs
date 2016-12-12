using System;
using System.Collections.Generic;
using serviceID.Model.DataModel;
using serviceID.BL;
using serviceID.Model.ViewModel;

namespace serviceID
{
   
    public class Service1 : IService1
    {

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

        public char BegeniCevap(int cevapId, int kullaniciId, int begeniTuruId)
        {
            return KullaniciIslem.BegeniCevap(cevapId, kullaniciId, begeniTuruId);
        }

        public List<begenilerim> BegeniSayisi(int cevapId)
        {
            return KullaniciIslem.BegeniSayisi(cevapId);
        }
    }
}
