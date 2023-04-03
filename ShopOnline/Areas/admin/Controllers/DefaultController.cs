using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        MydataDataContext ul = new MydataDataContext(); 
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"]!= null)
            {
                return RedirectToAction("ADmin", "Quanly");
            }    
            return View();
        }
        // GET: admin/Default
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            string username = UserName;
            string password = Password;
            var acc = ul.Users.SingleOrDefault(x =>  x.UserName == username && x.Password == password);
            if (acc != null)
            {
                Session["user"]= acc;
                //đăng nhập thành công
                return RedirectToAction("ADmin", "Quanly");
            }
            else
            {
                return View();
            }    
          
        }
       
    }
}