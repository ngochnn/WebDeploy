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
    
    public partial class DetailsOrder
    {
        public int ID_CTDonHang { get; set; }
        public int ID_SanPham { get; set; }
        public int ID_DonHang { get; set; }
        public Nullable<int> SoLuongMua { get; set; }
        public Nullable<int> GiaBan { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
