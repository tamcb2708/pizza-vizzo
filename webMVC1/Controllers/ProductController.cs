using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;

namespace webMVC1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            var product = new ProductDao();
            ViewBag.category = product.ListCategory(12);
            ViewBag.por = product.ListAllT(4);
            return View();
        }
        public ActionResult Category(long id, int page = 1 ,int pageSize = 8)
        {
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.cate = new CategoryDao().ListAll();
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryID(id,ref totalRecord, page,pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxpage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Maxpage = maxpage;
            ViewBag.Next = page+1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 8)
        {
           
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            int maxpage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Maxpage = maxpage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public JsonResult ListName(string q)
        {
           var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status=true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductDetail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new CategoryDao().ViewDetails(product.CategoryID.Value);
            ViewBag.OurChef = new OurChefDao().ListOurChef(4);
            ViewBag.pro = new ProductDao().ListFooterT(4);
            ViewBag.cat = new ProductDao().ListCategory(12);
            return View(product);
        }
    }
}