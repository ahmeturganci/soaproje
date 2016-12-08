using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using serviceID.Model.DataModel;

namespace serviceID.Model.ViewModel
{
    public class soruView
    {
        public int soruId { get; set; }
        public Nullable<int> kategoriId { get; set; }
        public Nullable<int> etiketId { get; set; }
        public string baslik { get; set; }
        public Nullable<System.DateTime> yayinTarihi { get; set; }
        public Nullable<bool> onayDurumu { get; set; }
        public Nullable<int> kullaniciId { get; set; }
        public string soruIcerik { get; set; }

        public static soruView MapData(soru s)
        {
            soruView gonderi = new soruView()
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
            return gonderi;
        }// ne nereye dicek anladık sanırım 

        public static soru MapData(soruView s)
        {
            soru tgonderi = new soru()
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
            return tgonderi;
        }

        public static List<soruView> MapData(List<soru> soruList)
        {
            List<soruView> listee = new List<soruView>();

            foreach (var k in soruList)
            {
                listee.Add(MapData(k));
            }

            return listee;
        }

        public static List<soru> MapData(List<soruView> soruList)
        {
            List<soru> liste = new List<soru>();

            foreach (var k in soruList)
            {
                liste.Add(MapData(k));
            }

            return liste;
        }
     
    }
}