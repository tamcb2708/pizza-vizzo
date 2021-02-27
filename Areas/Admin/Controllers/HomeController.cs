using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.order = new OderDao().ListOrder(6);
            ViewBag.orderdatail = new OderDetailDao().ListOrderDetail(6);
            return View();
    
        }
    }
}