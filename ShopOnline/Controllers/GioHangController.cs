    using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class GioHangController : Controller
    {
        MydataDataContext dt = new MydataDataContext(); 
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstgiohang = Session["Giohang"] as List<Giohang>;
            if (lstgiohang == null )
            {
                lstgiohang = new List<Giohang>();
                Session["Giohang"] = lstgiohang;

            }   
            return lstgiohang;
        }
        // GET: GioHang
        public ActionResult Themgiohang(int id, string strUrl )
        {
            List<Giohang> lstgiohang = Laygiohang();
            Giohang sanpham = lstgiohang.Find(n => n.maSanPham == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                lstgiohang.Add(sanpham);
                return Redirect(strUrl);

            }
            else
            {
                sanpham.isoluong++;
                return Redirect(strUrl);
            }    
            

        }

        private int TongSoluong ()
        {
            int tsl = 0;
            List<Giohang> lstgiohang = Session["GioHang"] as List<Giohang>;
            if( lstgiohang != null )
            {
                tsl = lstgiohang.Sum(n => n.isoluong);
            }    
            return tsl;
        }
        private int SumSanPham()
        {
            int tsl = 0;
            List<Giohang> lstgiohang = Session["GioHang"] as List<Giohang>;
            if (lstgiohang != null)
            {
                tsl = lstgiohang.Count;
            }
            return tsl;
        }

        private double SumTin ()
        {
            double tt = 0;
            List<Giohang> lstgiohang = Session["GioHang"] as List<Giohang>;
            if(lstgiohang != null)
            {
                tt = lstgiohang.Sum(n => n.dThanhTien);
            }
            return tt;
        }
        public ActionResult GioHang()
        {
            List<Giohang> lstgiohang = Laygiohang();
            ViewBag.TongSoluong = TongSoluong();
            ViewBag.SumTin = SumTin();
            ViewBag.SumSanPham = SumSanPham();
            return View(lstgiohang);
        }
        public ActionResult GioHangPartial()
        {
            List<Giohang> lstgiohang = Laygiohang();
            ViewBag.TongSoluong = TongSoluong();
            ViewBag.SumTin = SumTin();
            ViewBag.SumSanPham = SumSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<Giohang> lstgiohang = Laygiohang();
            Giohang sanpham = lstgiohang.SingleOrDefault(n => n.maSanPham == id);
            if(sanpham != null)
            {
                lstgiohang.RemoveAll(n => n.maSanPham == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang (int id, FormCollection collection)
        {
            List<Giohang> lstgiohang = Laygiohang();
            Giohang sanpham = lstgiohang.SingleOrDefault(n => n.maSanPham == id);
            if (sanpham != null)
            {
                sanpham.isoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaALLGiohang()
        {
            List<Giohang> lstgiohang = Laygiohang();
            lstgiohang.Clear();
            return RedirectToAction("GioHang");
        }
        [HttpGet ]

        //dat hang
        public ActionResult Dathang()
        {
            if (Session["TaiKhoan"] == null|| Session["TaiKhoan"].ToString()== "")
            {
                return RedirectToAction("Dangnhap", "NguoiDung");

            }    
            if (Session["Giohang"]==null)
            {
                return RedirectToAction("ListShop", "Shop");
            }
            List<Giohang> lstgiohang = Laygiohang();
            ViewBag.TongSoluong = TongSoluong();
            ViewBag.SumTin = SumTin();
            ViewBag.SumSanPham = SumSanPham();
            return View(lstgiohang);
        }
        public ActionResult Dathang(FormCollection collection)
        {
            donhang dh = new donhang();
            khachhang kh = (khachhang)Session["TaiKhoan"];
            SanPham s = new SanPham();
            List<Giohang> gh = new List<Giohang>();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["ngaygiao"]);
            dh.makh = kh.makh;
            dh.ngaydat = DateTime.Now;
            dh.ngaygiao = DateTime.Parse(ngaygiao);
            dh.giaohang = false;
            dh.thanhtoan = false;
            dt.donhangs.InsertOnSubmit(dh);
            dt.SubmitChanges();
            foreach(var item in gh)
            {
                chitietdonhang ctdh  = new chitietdonhang();
                ctdh.madon = dh.madon;
                ctdh.maSanpham = item.maSanPham;
                ctdh.soluong = item.isoluong;
                ctdh.gia = (decimal)item.giaban;
                s = dt.SanPhams.Single(n => n.maSanpham == item.maSanPham);
                s.SoLuongTon -= ctdh.soluong;
                dt.SubmitChanges();
                dt.chitietdonhangs.InsertOnSubmit(ctdh);
            }
            dt.SubmitChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacNhanDonhang", "GioHang");
        }
        public ActionResult XacNhanDonhang()
        {
            return View();
        }
    }
}