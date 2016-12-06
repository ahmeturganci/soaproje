using serviceID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using serviceID.Model.ViewModel;


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
        bool SoruEkle(soru soru);
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
        soru SoruAra(string soruBaslik);
        



    }
}
