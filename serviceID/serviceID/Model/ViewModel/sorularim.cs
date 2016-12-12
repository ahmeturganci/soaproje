using System.Runtime.Serialization;

namespace serviceID.Model.ViewModel
{
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
}