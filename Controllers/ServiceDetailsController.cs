using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Controllers
{
    public class ServiceDetailsController : Controller
    {
        // GET: ServiceDetails
        public ActionResult Index()
        {
            ViewBag.CategoryDetail = new ServicedetailDao().ListAll();
            return View();
        }
    }
}