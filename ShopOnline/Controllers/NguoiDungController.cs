﻿using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class NguoiDungController : Controller
    {
        MydataDataContext DataContext = new MydataDataContext();
        [HttpGet]
        public ActionResult dangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangKy(FormCollection collection, khachhang kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            var email = collection["email "];
            var diachi = collection["diachi "];
            var dienthoai = collection["dienthoai "];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["NhaMKXN"] = "Phải nhập mật khẩu xác nhận";
            }
            else
            {
                if (!matkhau.Equals(matkhau))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";
                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tendangnhap;
                    kh.matkhau = matkhau;
                    kh.email = email;
                    kh.diachi = diachi;
                    kh.dienthoai = dienthoai;
                    kh.ngaysinh = DateTime.Parse(ngaysinh);

                    return RedirectToAction("Dangnhap");
                }

            }


            return this.dangKy();
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            khachhang kh = DataContext.khachhangs.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);
            if (kh != null)
            {
                ViewBag.Thongbao = "Đăng Nhập Thành Công";
                Session["TaiKhoan"] = kh;
            }
            return RedirectToAction("ListShop", "Shop");
        }
    }
}