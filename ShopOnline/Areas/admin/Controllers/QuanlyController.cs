using PagedList;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    
    public class QuanlyController : BaseController
    {
        MydataDataContext dataContext = new MydataDataContext();
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Default");
        }
        
        // GET: Quanly
        public ActionResult ADmin(int? page)
        {
            if (page == null) page = 1;
            var all_sach = (from s in dataContext.SanPhams select s).OrderBy(m => m.maSanpham);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

     
        // GET: Quanly/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quanly/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham sp)
        {
            var E_TenSanPham = collection["TenSanPham"];
            var E_HinhChinh = collection["HinhChinh"];
            var E_giaban = Convert.ToInt32(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);

            var E_SoluongTon = Convert.ToInt32(collection["SoluongTon"]);
            if (string.IsNullOrEmpty(E_TenSanPham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sp.tensanPham = E_TenSanPham.ToString();
                sp.HinhChinh = E_HinhChinh.ToString();
                sp.giaban = E_giaban;
                sp.ngaycapnhat = E_ngaycapnhat;
                sp.SoLuongTon = E_SoluongTon;
                dataContext.SanPhams.InsertOnSubmit(sp);
                dataContext.SubmitChanges();
                return RedirectToAction("ADmin");
            }
            return this.Create();
        }

        // GET: Quanly/Edit/5
        public ActionResult Edit(int id)
        {
            var E_Min = dataContext.SanPhams.First(m => m.maSanpham == id);
            return View(E_Min);

        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            var E_Min = dataContext.SanPhams.FirstOrDefault(m => m.maSanpham == id);
            var E_TenSanPham = collection["TenSanPham"];
            var E_HinhChinh = collection["HinhChinh"];
            var E_giaban = Convert.ToInt32(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_SoluongTon = Convert.ToInt32(collection["SoLuongTon"]);
            E_Min.maSanpham = id;
            if (string.IsNullOrEmpty(E_TenSanPham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Min.tensanPham = E_TenSanPham;
                E_Min.HinhChinh = E_HinhChinh;
                E_Min.giaban = E_giaban;
                E_Min.ngaycapnhat = E_ngaycapnhat;
                E_Min.SoLuongTon = E_SoluongTon;
                UpdateModel(E_Min);
                dataContext.SubmitChanges();
                return RedirectToAction("ADmin");
            }
            return this.Edit(id);
        }

        // POST: Quanly/Edit/5


        // GET: Quanly/Delete/5
        public ActionResult Delete(int id)
        {
            var D_Min = dataContext.SanPhams.First(m => m.maSanpham == id);

            return View(D_Min);
        }

        // POST: Quanly/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_Min = dataContext.SanPhams.Where(m => m.maSanpham == id).First();
            dataContext.SanPhams.DeleteOnSubmit(D_Min);
            dataContext.SubmitChanges();

            return RedirectToAction("ADmin");

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
