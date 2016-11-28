using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using serviceID.Model.DataModel;
using serviceID.Model.ViewModel;

namespace serviceID.Model.ViewModel
{
    public class Kullanici
    {
        public int kullaniciId { get; set; }
        public string kullaniciAdi { get; set; }
        public string email { get; set; }
        public string sifre { get; set; }

        public static Kullanici MapData(kullanici k)
        {
            Kullanici kul = new Kullanici()
            {
                kullaniciId = k.kullaniciId,
                email = k.email,
                sifre = k.sifre
            };
            return kul;
        }
        public static kullanici MapData(Kullanici k)
        {
            kullanici tk = new kullanici()
            {
                kullaniciId = k.kullaniciId,
                email = k.email,
                sifre = k.sifre
            };
            return tk;
        }
        public static List<Kullanici> MapData(List<kullanici> kulList)
        {
            List<Kullanici> liste = new List<Kullanici>();

            foreach (var k in kulList)
            {
                liste.Add(MapData(k));
            }

            return liste;
        }

        public static List<kullanici> MapData(List<Kullanici> kulList)
        {
            List<kullanici> liste = new List<kullanici>();

            foreach (var k in kulList)
            {
                liste.Add(MapData(k));
            }

            return liste;
        }
    }
}