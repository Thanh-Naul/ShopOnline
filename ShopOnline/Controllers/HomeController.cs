using PagedList;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        MydataDataContext db = new MydataDataContext();
      
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}