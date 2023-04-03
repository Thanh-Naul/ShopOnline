using Antlr.Runtime.Tree;
using PagedList;
using ShopOnline.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ShopController : Controller
    {
        MydataDataContext DataContext = new MydataDataContext();
        [HttpGet]
       
        //public ActionResult Menu(int ? page)
        //{
        //    // 1. Tham số int? dùng để thể hiện null và kiểu int
        //    // page có thể có giá trị là null và kiểu int.
        //    // 1. Tham số int? dùng để thể hiện null và kiểu int
        //    // page có thể có giá trị là null và kiểu int.
        //    if (page == null) page = 1;
        //    // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
        //    // theo BookID mới có thể phân trang.
        //    var all_Shop = (from s in DataContext.SanPhams select s).OrderBy(m => m.maSanpham);
        //    int pageSize = 6;
        //    int pageNum = page ?? 6;
        //    return View(all_Shop.ToPagedList(pageSize, pageNum));
        //}
        // GET: Shop
      
        public ActionResult ListShop(int? page)
        {

            if (page == null) page = 1;
            var all_Shop = (from s in DataContext.SanPhams select s).OrderBy(m => m.maSanpham);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_Shop.ToPagedList(pageNum, pageSize));
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            var D_Shop = DataContext.SanPhams.Where(m => m.maSanpham == id).FirstOrDefault();
            return View(D_Shop);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham sh )
        {
            var E_TenSanPham = collection["TenSanPham"];
            var E_HinhChinh = collection["HinhChinh"];
            var E_giaban = Convert.ToInt32(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            
            var E_SoluongTon = Convert.ToInt32(collection["SoluongTon "]);
            if (string.IsNullOrEmpty(E_TenSanPham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sh.tensanPham = E_TenSanPham.ToString();
                sh.HinhChinh = E_HinhChinh.ToString();
                sh.giaban = E_giaban;
                sh.ngaycapnhat = E_ngaycapnhat;
                sh.SoLuongTon = E_SoluongTon;
                DataContext.SanPhams.InsertOnSubmit(sh);
                DataContext.SubmitChanges();
                return RedirectToAction("listbook");
            }
            return this.Create();
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            var E_Shop = DataContext.SanPhams.FirstOrDefault(m => m.maSanpham == id);
            return View(E_Shop);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_Shop = DataContext.SanPhams.FirstOrDefault(m => m.maSanpham == id);
            var E_TenSanPham = collection["TenSanPham"];
            var E_HinhChinh = collection["HinhChinh"];
            var E_giaban = Convert.ToInt32(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_SoluongTon = Convert.ToInt32(collection["SoLuongTon"]);
            E_Shop.maSanpham = id;
            if (string.IsNullOrEmpty(E_TenSanPham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Shop.tensanPham = E_TenSanPham;
                E_Shop.HinhChinh = E_HinhChinh;
                E_Shop.giaban = E_giaban;
                E_Shop.ngaycapnhat = E_ngaycapnhat;
                E_Shop.SoLuongTon = E_SoluongTon;
                UpdateModel(E_Shop);
                DataContext.SubmitChanges();
                return RedirectToAction("ListShop");
            }
            return this.Edit(id);
        }
        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/assets/" + file.FileName));
            return "/Content/assets/" + file.FileName;
        }
    }
}
