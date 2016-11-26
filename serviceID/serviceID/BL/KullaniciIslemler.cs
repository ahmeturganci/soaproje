using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using serviceID.Model.DataModel;
using serviceID.Model.ViewModel;

namespace serviceID.BL
{
    public class KullaniciIslemler
    {
        public static string KullaniciKaydet( Kullanici kullanici)
        {

            try
            {

                return "Başarılı";
            } 
            catch (Exception ex)
            {

                
                return "Basarisiz" + ex.Message;
            }
        }
        public static string GirisYap(string kulAd,string sifre)
        {
            try
            {

                EntityModel db = new EntityModel();
                // Sınıfı Oluşturamıyorum
                var kul = (from k in db.tblKullanici
                           where k.KullaniciAdi == kulAdi && k.Sifre == sifre
                           select k).SingleOrDefault();
                if (kul == null)
                {
                    return "Şifre ya da kullanıcı adı yanlış.";
                }
                else
                    return "Giriş başarılı!";
            }
            catch (Exception ex)
            {
                return "İşlem başarısız" + ex.Message;
            }
        }
    }
}