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
    
    public partial class etiket
    {
        public etiket()
        {
            this.soruEtikets = new HashSet<soruEtiket>();
        }
    
        public int etiketId { get; set; }
        public string etiketAd { get; set; }
    
        public virtual ICollection<soruEtiket> soruEtikets { get; set; }
    }
}
