//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace serviceID.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class begeni
    {
        public begeni()
        {
            this.cevaps = new HashSet<cevap>();
        }
    
        public int begeniId { get; set; }
        public Nullable<int> begeniSayisi { get; set; }
        public Nullable<int> tiksintiSayisi { get; set; }
    
        public virtual ICollection<cevap> cevaps { get; set; }
    }
}
