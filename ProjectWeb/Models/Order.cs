//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.DetailsOrders = new HashSet<DetailsOrder>();
        }
    
        public int ID_DonHang { get; set; }
        public Nullable<int> ID_Account { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> TongTien { get; set; }
        public Nullable<int> TrangThai { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsOrder> DetailsOrders { get; set; }
    }
}
