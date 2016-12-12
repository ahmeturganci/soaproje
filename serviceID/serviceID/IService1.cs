using System.Collections.Generic;
using System.ServiceModel;
using serviceID.Model.DataModel;
using serviceID.Model.ViewModel;

namespace serviceID
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
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
        List<sorularim> SoruAra(string soruBaslik);
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
        [OperationContract]
        char BegeniCevap(int cevapId,int kullaniciId, int begeniTuruId); // + başarılı, - silindi, / güncellendi, * başarısız, ? db hata
        [OperationContract]
        List<begenilerim> BegeniSayisi(int cevapId);
        [OperationContract]
        char CevapOnayla(int kullaniciId,int soruId, int cevapId);
    }
}
