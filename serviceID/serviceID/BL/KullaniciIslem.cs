using System;
using System.Collections.Generic;
using System.Linq;
using serviceID.Model.DataModel;
using serviceID.Model.ViewModel;
using System.Security.Cryptography;
using System.Text;

namespace serviceID.BL
{

    public class KullaniciIslem
    {
        public static string MD5Sifrele(string metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        public static int KayitOl(kullanici kullanici)
        {
            try
            {
                idDBEntities db = new idDBEntities();

                var kul = (from k in db.kullanicis
                           where k.kullaniciAdi == kullanici.kullaniciAdi
                           select k).SingleOrDefault();

                if (kul == null)
                {
                    kullanici.sifre = MD5Sifrele(kullanici.sifre);
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
                    kullanici.sifre = MD5Sifrele(kullanici.sifre);
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
        public static List<sorularim> SoruAra(string soruBaslik)
        {
            List<sorularim> sr = new List<sorularim>();
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var soruSorgu = (from p in db.sorus
                                     where p.baslik.Contains(soruBaslik)
                                     select new
                                     {
                                         p.soruIcerik,
                                         p.baslik,
                                         p.yayinTarihi,
                                         p.onayDurumu,
                                         p.kullanici.kullaniciAdi,
                                         p.kategori.kategoriAd,
                                         p.soruId
                                     });
                    if (soruSorgu != null) {
                        foreach (var i in soruSorgu)
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
                }
            }
            catch
            {
                sr = null; ;
            }
            return sr;
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

                    var tblSorgu = from p in db.sorus orderby p.yayinTarihi descending
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
        public static sorularim hangiSorum(int soruId)
        {
            sorularim ss=null;
            using (idDBEntities db = new idDBEntities())
            {
                try
                {
                    var tblHangiSoruSorgu = (from p in db.sorus where p.soruId == soruId select p).FirstOrDefault();

                    ss= new sorularim
                    {
                        Icerik = tblHangiSoruSorgu.soruIcerik,
                        Baslik = tblHangiSoruSorgu.baslik,
                        YayinTarihi = tblHangiSoruSorgu.yayinTarihi.ToString(),
                        OnayDurum = tblHangiSoruSorgu.onayDurumu.ToString(),
                        KullaniciAd = tblHangiSoruSorgu.kullanici.kullaniciAdi,
                        KategoriAd = tblHangiSoruSorgu.kategori.kategoriAd,
                        SoruId = tblHangiSoruSorgu.soruId
                    };
                }
                catch
                {

                }
            }
            return ss;
        }
        public static char FavoriSoruEkle(int soruId, int kullaniciId)
        {
            char res = '*';
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var favSoru = (from p in db.favoris where p.soruId == soruId && p.kullaniciId == kullaniciId select p).SingleOrDefault();
                    if (favSoru == null)
                    {
                        favori f = new favori();
                        f.soruId = soruId;
                        f.kullaniciId = kullaniciId;
                        db.favoris.Add(f);
                        db.SaveChanges();
                        res = '+';
                    }
                    else
                    {
                        db.favoris.Remove(favSoru);
                        db.SaveChanges();
                        res = '-';
                    }
                }
            }
            catch (Exception)
            {
                res = '?';
            }
            return res;
        }
        public static char BegeniCevap(int cevapId, int kullaniciId,int begeniTuruId)
        {
            char res = '*';
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var tblBegeni = (from p in db.begenis where p.cevapId == cevapId && p.kullaniciId == kullaniciId select p).SingleOrDefault();
                    if (tblBegeni == null)
                    {
                        begeni b = new begeni();
                        b.cevapId = cevapId;
                        b.kullaniciId = kullaniciId;
                        b.begeniTuruId = begeniTuruId;
                        db.begenis.Add(b);
                        db.SaveChanges();
                        res = '+';
                    }
                    else if(tblBegeni!=null && tblBegeni.begeniTuruId!=begeniTuruId)
                    {
                        tblBegeni.begeniTuruId = begeniTuruId;
                        db.SaveChanges();
                        res = '/';
                    }
                    else
                    {
                        db.begenis.Remove(tblBegeni);
                        db.SaveChanges();
                        res = '-';
                    }
                }
            }
            catch
            {
                res = '?';
            }
            return res;
        }
        public static List<begenilerim> BegeniSayisi(int cevapId)
        {
            List<begenilerim> bg = new List<begenilerim>();
            try
            {
                using (idDBEntities db = new idDBEntities()) {
                    var tblBegeniler = from p in db.begenis
                                       where p.cevapId == cevapId
                                       group p.begeniTuruId by p.begeniTuruId;
                    foreach (var item in tblBegeniler)
                    {
                        begenilerim bb = new begenilerim
                        {
                            BegeniTuruId = (int)item.Key,
                            BegeniTuruSayisi = item.Count()
                        };
                        bg.Add(bb);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return bg;
        }
        public static char CevapOnayla(int kullaniciId, int soruId, int cevapId)
        {
            char res = '*';
            try
            {
                using (idDBEntities db = new idDBEntities())
                {
                    var tblCevap =(dynamic)null;
                    var tblSoru = (from p in db.sorus where p.soruId == soruId && p.kullaniciId == kullaniciId select p).SingleOrDefault();//sadece soruyu soran kullanıcı
                    if(tblSoru!=null) //tblsoru null ise tblcevap için gereksiz sorgulama yapılmamas
                        tblCevap = (from p in db.cevaps where p.cevapId == cevapId select p).SingleOrDefault();// bu cevabı onaylayabilir
                    if (tblSoru != null && tblCevap != null) // tblcevap kontrolü öyle bir cevap yoksa ve aşağıdaki durumların patlama kontrolü
                    {
                        if (tblCevap.onayDurumu == false)
                        {
                            tblCevap.onayDurumu = true;
                            db.SaveChanges();
                            res = '+';
                        }
                        else
                        {
                            tblCevap.onayDurumu = false;
                            db.SaveChanges();
                            res = '-';
                        }
                    }
                    else
                        res = '/';
                }
            }
            catch (Exception)
            {

                return '?';
            }
            return res;
        }
    }
}