using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using serviceID.Model;

namespace serviceID.BL
{
    public class KullaniciIslem
    {
        public static string KayitOl(kullanici kullanici)
        {

            try
            {
                idDBEntities db = new idDBEntities();

                var kul = (from k in db.kullanicis
                           where k.kullaniciId == kullanici.kullaniciId
                           select k).SingleOrDefault();

                if (kul == null)
                {
                    db.kullanicis.Add(kullanici);
                    db.SaveChanges();

                    return "İşlem başarılı.";
                }
                else
                {
                    kul.kullaniciAdi = kullanici.kullaniciAdi;
                    kul.email = kullanici.email;
                    kul.sifre = kullanici.sifre;
                    db.SaveChanges();

                    return "İşlem başarılı.";
                }
            }
            catch (Exception ex)
            {
                return "İşlem başarısız!" + ex.Message;
            }
        }
        public static string GirisYap(string kulAd, string sifre)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
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