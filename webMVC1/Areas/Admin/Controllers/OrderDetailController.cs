using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new OderDetailDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

    }
}