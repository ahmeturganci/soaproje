using serviceID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using serviceID.Model.ViewModel;
using serviceID.Model.DataModel;


namespace serviceID
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);
     

        [OperationContract]
        int GirisYap(kullanici kullanici); //int sebebi kullanicid return etmek için
        [OperationContract]
        int KayitOl(kullanici kul); // 0 başarılı, 1 başarısız, 2 hata var
        [OperationContract]
        string SoruEkle(soru soru);
        [OperationContract]
        bool KategoriEkle(kategori kategori);
        [OperationContract]
        bool EtiketEkle(etiket etiket);
        [OperationContract]
        bool SoruyaCevapYaz(cevap cevap);
        [OperationContract]
        bool CevabaYorumYaz(yorum yorum);
        [OperationContract]
        bool SoruFavoriEkle(favori fav);
        [OperationContract]
        List<soruView> Sorular();
        [OperationContract]
        List<sorularim> SoruAra(string soruBaslik);
        [OperationContract]
        List<soruView> SoruListele();
        [OperationContract]
        List<string> KategoriListele();
        [OperationContract]
        List<string> EtiketListele();
        [OperationContract]
        List<sorularim> Sorularim();
        [OperationContract]
        List<cevaplarim> Cevaplarim(int soruId);
        [OperationContract]
        List<yorumlarim> Yorumlarim(int cevapId);
        [OperationContract]
        sorularim hangiSorum(int soruId);
        [OperationContract]
        char FavoriSoruEkle(int soruId, int kullaniciId); // json için + başarılı , - silindi , ? db hata , * başarısız
    }
    [DataContract]
    public class sorularim
    {
        private string baslik = "";
        private string icerik = "";
        private string yayinTarihi = "";
        private string kategoriAd = "";
        private string etiketAd = "";
        private string kullaniciAd = "";
        private string onayDurum = "";
        private int soruId = 0;

        [DataMember]
        public string Baslik
        {
            get
            {
                return baslik;
            }

            set
            {
                baslik = value;
            }
        }
        [DataMember]
        public string Icerik
        {
            get
            {
                return icerik;
            }

            set
            {
                icerik = value;
            }
        }
        [DataMember]
        public string YayinTarihi
        {
            get
            {
                return yayinTarihi;
            }

            set
            {
                yayinTarihi = value;
            }
        }
        [DataMember]
        public string KategoriAd
        {
            get
            {
                return kategoriAd;
            }

            set
            {
                kategoriAd = value;
            }
        }
        [DataMember]
        public string EtiketAd
        {
            get
            {
                return etiketAd;
            }

            set
            {
                etiketAd = value;
            }
        }
        [DataMember]
        public string KullaniciAd
        {
            get
            {
                return kullaniciAd;
            }

            set
            {
                kullaniciAd = value;
            }
        }
        [DataMember]
        public string OnayDurum
        {
            get
            {
                return onayDurum;
            }

            set
            {
                onayDurum = value;
            }
        }
        [DataMember]
        public int SoruId
        {
            get
            {
                return soruId;
            }

            set
            {
                soruId = value;
            }
        }
    }
    [DataContract]
    public class cevaplarim
    {
        private string cevap = "";
        private string kullaniciAdi = "";
        private string cevapTarihi = "";
        private int cevapId = 0;
        [DataMember]
        public string Cevap
        {
            get
            {
                return cevap;
            }

            set
            {
                cevap = value;
            }
        }
        [DataMember]
        public string KullaniciAdi
        {
            get
            {
                return kullaniciAdi;
            }

            set
            {
                kullaniciAdi = value;
            }
        }
        [DataMember]
        public string CevapTarihi
        {
            get
            {
                return cevapTarihi;
            }

            set
            {
                cevapTarihi = value;
            }
        }
        [DataMember]
        public int CevapId
        {
            get
            {
                return cevapId;
            }

            set
            {
                cevapId = value;
            }
        }
    }
    [DataContract]
    public class yorumlarim
    {
        private string yorum = "";
        private string yorumTarihi = "";
        private string kullaniciAdi = "";
        [DataMember]
        public string Yorum
        {
            get
            {
                return yorum;
            }

            set
            {
                yorum = value;
            }
        }
        [DataMember]
        public string YorumTarihi
        {
            get
            {
                return yorumTarihi;
            }

            set
            {
                yorumTarihi = value;
            }
        }
        [DataMember]
        public string KullaniciAdi
        {
            get
            {
                return kullaniciAdi;
            }

            set
            {
                kullaniciAdi = value;
            }
        }
    }
}
