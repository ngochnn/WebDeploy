using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWeb.Models
{
    [Serializable]
    public class Cart
    {
        public string TenSanPham { get; set; }
        public int ID_SanPham { set; get; }
        public string HinhAnh { get; set; }
        public int? GiaGoc { get; set; }
        public int SoLuong { get; set; }
        public int? ThanhTien
        { get { return SoLuong * GiaGoc; } }
    }
}