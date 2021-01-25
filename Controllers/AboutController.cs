using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var about = new OurChefDao();
            ViewBag.ourchefT = about.ListOurChefT(1);
            ViewBag.ourchef = about.ListOurChef(3);
            ViewBag.ourchefA = about.ListOurChefA(3);
            ViewBag.footer = new ProductDao().ListFooter(6);
            ViewBag.about = new AboutDao().ListAbout(6);
            return View();
        }
    }
}