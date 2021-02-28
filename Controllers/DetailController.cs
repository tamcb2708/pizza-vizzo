using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult CategoryDetail()
        {
            var model = new DetailDao().ListAll();
            return PartialView(model);
        }
    }
}