    using ShopOnline.Models;
using ShopOnline.Models.PayMent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
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
            List<Giohang> lstgiohang = Session["GioHang"] as List<Giohang>;
            if (lstgiohang == null )
            {
                lstgiohang = new List<Giohang>();
                Session["GioHang"] = lstgiohang;

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
            //CultureInfo culture = new CultureInfo("vi-VN"); // Đặt định dạng cho tiền tệ và số
            //string formattedValue = tt.ToString("N2", culture); // Chuyển đổi và định dạng theo yêu cầu của vùng quốc gia
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
            if (Session["khachhang"] == null|| Session["khachhang"].ToString()== "")
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
        [HttpPost]
        public ActionResult Dathang(FormCollection collection)
        {

            donhang dh = new donhang();
            khachhang kh = (khachhang)Session["khachhang"];
            SanPham s = new SanPham();
            List<Giohang> gh = Laygiohang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["ngaygiao"]);
            dh.makh = kh.makh;
            dh.ngaydat = DateTime.Now;
            //dh.thanhtoan = false;
            dh.ngaygiao = DateTime.Parse(ngaygiao);
            dh.Tongtien = (int)SumTin();
            Session["TongTien"] = dh.Tongtien;




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

            //return RedirectToAction("XacNhanDonhang", "GioHang");
            return RedirectToAction("Payment", "GioHang");
            //return RedirectToAction("ListShop", "Shop");


        }
      

        public ActionResult Payment()
        {
            double a = double.Parse(Session["TongTien"].ToString());
            double total = a * 100;

            string url = ConfigurationManager.AppSettings["Url"];
            string returnUrl = ConfigurationManager.AppSettings["Returnurl"];
            string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

            PayLib pay = new PayLib();

            pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
            pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
            pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
            pay.AddRequestData("vnp_Amount", total.ToString()); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
            pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
            pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
            pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
            pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            return Redirect(paymentUrl);
        }

        public ActionResult PaymentConfirm()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"]; //Chuỗi bí mật
                var vnpayData = Request.QueryString;
                PayLib pay = new PayLib();

                //lấy toàn bộ dữ liệu được trả về
                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }

                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; //hash của dữ liệu trả về

                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?

                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        //Thanh toán thành công
                        ViewBag.Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;
                        
                    }
                    else
                    {
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                    }
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View();
        }
       
    }
} 