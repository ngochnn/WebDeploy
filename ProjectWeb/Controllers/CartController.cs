using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
    public class CartController : Controller
    {
        dbshopgameEntities db = new dbshopgameEntities();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var listitem = new List<Cart>();
            if (cart != null)
            {
                listitem = (List<Cart>)cart;
            }
            return View(listitem);
        }

        //public ActionResult AddItem(int Idsp, int SoLuong)
        //{
        //    var cart = Session[CartSession];
        //    if(cart!=null)
        //    {
        //        var list = (List<Cart>)cart;
        //        if(list.Exists(m=>m.ID_SanPham==Idsp))
        //        {
        //            foreach (var item in list)
        //            {
        //                if (item.ID_SanPham == Idsp)
        //                {
        //                    item.SoLuong += SoLuong;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            //tạo mới đối tượng cart item
        //            var item = new Cart();
        //            item.ID_SanPham = Idsp;
        //            item.SoLuong = SoLuong;
        //            list.Add(item);
        //        }
        //        Session[CartSession] = list;

        //    }
        //    else
        //    {
        //        //tạo mới đối tượng cart item
        //        var item = new Cart();
        //        item.ID_SanPham = Idsp;
        //        item.SoLuong = SoLuong;
        //        var list = new List<Cart>();
        //        list.Add(item);     

        //        //Gán vào session
        //        Session[CartSession] = list;
        //    }
        //    return RedirectToAction("Index", "Cart", new { proid = Idsp });

        //}

        public ActionResult AddItem(int Idsp)
        {

            if (Session[CartSession] == null)
            {
                Session[CartSession] = new List<Cart>();
                Session["count"] = 0;
            }
            List<Cart> listitem = Session[CartSession] as List<Cart>;
            if (listitem.Exists(m => m.ID_SanPham == Idsp)) // kiem tra xem san pham da co chua
            {
                //Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
               Cart card = listitem.FirstOrDefault(m => m.ID_SanPham == Idsp);
                card.SoLuong++;


            }
            else
            {
                Product sp = db.Products.Find(Idsp);  //neu sp chua co trong gio hang them san pham moi vao gio hang

                Cart newItem = new Cart()
                {
                    ID_SanPham = Idsp,
                    TenSanPham = sp.TenSanPham,
                    SoLuong = 1,
                    HinhAnh = sp.HinhAnh,
                    GiaGoc = sp.GiaGoc,

                };  // Tạo ra 1 CartItem mới

                listitem.Add(newItem);  // Thêm CartItem vào giỏ 
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;//session gio hang tang len 1
            }

            //Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Index", "Cart", new { proid = Idsp });

        }
        public ActionResult Deleted(int SPID)
        {
            List<Cart> DeletedItem = Session[CartSession] as List<Cart>;
            Cart itemXoa = DeletedItem.FirstOrDefault(m => m.ID_SanPham == SPID);
            if (itemXoa != null)
                DeletedItem.Remove(itemXoa);
            {
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            }
            return RedirectToAction("Index", "Cart");

        }
                public ActionResult Updated(int id, int Soluongmoi)
        {
            // tìm carditem muon sua
            List<Cart> gioHang = Session["CartSession"] as List<Cart>;
            Cart itemSua = gioHang.FirstOrDefault(m => m.ID_SanPham == id);
            if (itemSua != null)
            {
                itemSua.SoLuong = Soluongmoi;
            }
            return RedirectToAction("Index");

        }

    }
}
