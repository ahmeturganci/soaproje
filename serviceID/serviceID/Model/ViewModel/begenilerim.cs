

using System.Runtime.Serialization;

namespace serviceID.Model.ViewModel
{
    [DataContract]
    public class begenilerim
    {
        private int begeniTuruId = 0;
        private int begeniTuruSayisi = 0;
        [DataMember]
        public int BegeniTuruId
        {
            get
            {
                return begeniTuruId;
            }

            set
            {
                begeniTuruId = value;
            }
        }
        [DataMember]
        public int BegeniTuruSayisi
        {
            get
            {
                return begeniTuruSayisi;
            }

            set
            {
                begeniTuruSayisi = value;
            }
        }
    }
}