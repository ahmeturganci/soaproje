using System.Runtime.Serialization;

namespace serviceID.Model.ViewModel
{
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
}