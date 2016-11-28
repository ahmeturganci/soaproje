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
        public static string KullaniciKaydet( Kullanici kul)
        {

            try
            {
                using (EntityModel db = new EntityModel())
                {
                    kullanici k = new kullanici();
                    k.kullaniciAdi = kul.kullaniciAdi;
                    k.email = kul.email;
                    k.sifre = kul.sifre;//encrption yapılacak
                }
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
                using (EntityModel db = new EntityModel())
                {
                    var kul = (from k in db.kullanicis
                               where k.kullaniciAdi == kulAd && k.sifre == sifre
                               select k).SingleOrDefault();
                    if (kul == null)
                    {
                        return "Şifre ya da kullanıcı adı yanlış.";
                    }
                    else
                        return "Giriş başarılı!";
                }
            }
            catch (Exception ex)
            {
                return "İşlem başarısız" + ex.Message;
            }
        }
    }
}