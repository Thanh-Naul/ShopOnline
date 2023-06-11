using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class Giohang
    {
        MydataDataContext Data = new MydataDataContext();
        public int maSanPham { get; set; }

        [Display(Name= "Tên Sản Phẩm")]
        public string tensanpham { get; set; }

        [Display(Name = "ảnh Chính")]
        public string HinhCHinh { get; set; }

        [Display(Name = "Gía bán")]
        public Double giaban { get; set; }

        [Display(Name = "Số Lượng")]
        public int isoluong { get; set; }

        [Display(Name = "Thành Tiền")]
        public Double dThanhTien
        {
            get
            {
                return  isoluong * giaban;
                //if (double.IsNaN(thanhTien) || double.IsInfinity(thanhTien))
                //{
                //    // Xử lý trường hợp giá trị không hợp lệ ở đây, ví dụ:
                //    thanhTien = 0; // Gán giá trị mặc định hoặc giá trị khác tuỳ theo yêu cầu của bạn
                //}
                //return thanhTien;

            }
        }
        public Giohang(int id)
        {
            this.maSanPham = id;
            SanPham sanPham = Data.SanPhams.Single(n => n.maSanpham == maSanPham);
            tensanpham = sanPham.tensanPham;
            HinhCHinh = sanPham.HinhChinh;
            giaban = double.Parse(sanPham.giaban.ToString());
            isoluong = 1;
        }
    }
}