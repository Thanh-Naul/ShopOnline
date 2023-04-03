using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        //controller này sẽ viết ghi đè 1 phương thức
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["user"] == null )//chưa đăng nhập 
            {
                //thì trả về trang đăng nhập admin
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new {Controller ="Default", Action ="Login"} )
                    );
            } 
            base.OnActionExecuting(filterContext);

                    
        }
       
    }
}