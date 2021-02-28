using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.Common;
using System.Web.Routing;

namespace webMVC1.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session =(UserLogin) Session[CommonContanst.USER_SESSION];
            if(session==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
            }   
            base.OnActionExecuting(filterContext);
        }
    }
}