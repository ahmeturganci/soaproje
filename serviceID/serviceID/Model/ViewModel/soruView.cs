using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        
               
       }
}