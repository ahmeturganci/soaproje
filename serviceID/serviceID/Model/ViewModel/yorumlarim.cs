using System.Runtime.Serialization;

namespace serviceID.Model.ViewModel
{
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