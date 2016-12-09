﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using serviceID.Model.DataModel;
using serviceID.Model.ViewModel;
namespace serviceID.BL
{

    public class KullaniciIslem
    {
        public static int KayitOl(kullanici kullanici)
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

                    return 0; // kayıt başarılı
                }
                else
                    return 1; // kayıt başarısız
            }
            catch
            {
                return 2; // işlem başarısız
            }
        }
        public static int GirisYap(kullanici kullanici)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var kul = (from k in db.kullanicis
                               where k.kullaniciAdi == kullanici.kullaniciAdi && k.sifre == kullanici.sifre
                               select k).SingleOrDefault();
                    if (kul == null)
                    {
                        return 0;
                    }
                    else
                        return kul.kullaniciId;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static string SoruEkle(soru soru)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    db.sorus.Add(soru);
                    db.SaveChanges();
                    return "+";
                }
            }
            catch
            {
                return "-";
            }
        }
        public static bool KategoriEkle(kategori kategori)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    db.kategoris.Add(kategori);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool EtiketEkle(etiket etiket)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    db.etikets.Add(etiket);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool SoruyaCevapYaz(cevap cevap)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    db.cevaps.Add(cevap);
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }
        public static bool CevabaYorumYaz(yorum yorum)
        {
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    db.yorums.Add(yorum);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static soru SoruAra(string soruBaslik)
        {
            soru s = null;
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var soruSorgu = (from p in db.sorus where p.baslik.Contains(soruBaslik) select p).FirstOrDefault();
                    if (soruSorgu != null)
                        s = soruSorgu;
                    else
                        s = null;
                }
            }
            catch
            {
                s = null; ;
            }
            return s;
        }
        public static List<soruView> Sorular()
        {
            List<soruView> sorular = new List<soruView>();

            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var sorularSorgu = db.sorus;
                    foreach (soru s in sorularSorgu)
                    {
                        //sıkıntılar var düzeltilecek.
                        soruView ss = new soruView()
                        {
                            baslik = s.baslik,
                            etiketId = s.etiketId,
                            kategoriId = s.kategoriId,
                            kullaniciId = s.kullaniciId,
                            onayDurumu = s.onayDurumu,
                            soruIcerik = s.soruIcerik,
                            soruId = s.soruId,
                            yayinTarihi = s.yayinTarihi
                        };
                        sorular.Add(ss);

                    }
                }
            }
            catch
            {

            }
            return sorular;
        }
        public static List<soruView> SoruListele()
        {
            idDBEntities db = new idDBEntities();
            var tblSoru = db.sorus;
            return soruView.MapData(db.sorus.ToList());
        }
        public static List<string> KategoriListele()
        {
            List<string> kategoriler = new List<string>();
            using (idDBEntities db = new idDBEntities())
            {
                try
                {
                    var tblKategori = db.kategoris;
                    foreach (kategori item in tblKategori)
                    {
                        kategoriler.Add(item.kategorId + "," + item.kategoriAd);
                    }
                }
                catch
                {
                }
            }
            return kategoriler;
        }
        public static List<string> EtiketListele()
        {
            List<string> etiketler = new List<string>();
            using (idDBEntities db = new idDBEntities())
            {
                try
                {
                    var tblEtiket = db.etikets;
                    foreach (etiket item in tblEtiket)
                    {
                        etiketler.Add(item.etiketAd);
                    }
                }
                catch
                {
                }
            }
            return etiketler;
        }
        public static List<sorularim> Sorularim()
        {
            List<sorularim> sr = new List<sorularim>();
            using (idDBEntities db = new idDBEntities())
            {
                try
                {

                    var tblSorgu = from p in db.sorus
                                   select new
                                   {
                                       p.soruIcerik,
                                       p.baslik,
                                       p.yayinTarihi,
                                       p.onayDurumu,
                                       p.kullanici.kullaniciAdi,
                                       p.kategori.kategoriAd,
                                       p.soruId
                                   };
                    foreach (var i in tblSorgu)
                    {
                        sorularim ss = new sorularim
                        {
                            Icerik = i.soruIcerik,
                            Baslik = i.baslik,
                            YayinTarihi = i.yayinTarihi.ToString(),
                            OnayDurum = i.onayDurumu.ToString(),
                            KullaniciAd = i.kullaniciAdi,
                            KategoriAd = i.kategoriAd,
                            SoruId = i.soruId
                        };
                        sr.Add(ss);

                    }
                }
                catch
                {

                }
            }
            return sr;
        }
        public static List<cevaplarim> Cevaplarim(int soruId)
        {
            List<cevaplarim> cv = new List<cevaplarim>();
            try
            {
                using (idDBEntities db=new idDBEntities())
                {
                    var tblCevap = from p in db.cevaps
                                   where p.soruId == soruId
                                   select new
                                   {
                                       p.cevap1,
                                       p.cevapTarihi,
                                       p.kullanici.kullaniciAdi,
                                       p.cevapId
                                   };
                    foreach (var item in tblCevap)
                    {
                        cevaplarim cc = new cevaplarim
                        {
                            Cevap = item.cevap1,
                            CevapTarihi = item.cevapTarihi.ToString(),
                            KullaniciAdi = item.kullaniciAdi,
                            CevapId=item.cevapId
                        };
                        cv.Add(cc);
                    }
                }
            }
            catch
            {
            }
            return cv;
        }
        public static List<yorumlarim> Yorumlarim(int cevapId)
        {
            List<yorumlarim> yr = new List<yorumlarim>();
            try
            {
                using (idDBEntities db=new idDBEntities())
                {
                    var tblYorum = from p in db.yorums
                                   where p.cevapId == cevapId
                                   select new
                                   {
                                       p.yorum1,
                                       p.yorumTarihi,
                                       p.kullanici.kullaniciAdi
                                   };
                    foreach (var item in tblYorum)
                    {
                        yorumlarim yy = new yorumlarim()
                        {
                            Yorum = item.yorum1,
                            YorumTarihi = item.yorumTarihi.ToString(),
                            KullaniciAdi = item.kullaniciAdi
                        };
                        yr.Add(yy);
                    }
                }
            }
            catch (Exception)
            {
            }
            return yr;
        }
    }
}