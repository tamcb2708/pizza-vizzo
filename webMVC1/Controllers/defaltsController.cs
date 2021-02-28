using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.Common;
using webMVC1.DAO;
using webMVC1.EF;
using webMVC1.Models;

namespace webMVC1.Controllers
{
    public class defaltsController : Controller
    {
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult aboutcompany()
        {
            return View();
        }
        // GET: defalts
        public ActionResult Termsofservice()
        {
            return View();
        }
        public ActionResult Privacypolicy()
        {
            return View();
        }
        public ActionResult Tag()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Send(string email)
        {
            var feedback = new Email();
            feedback.Email1 = email;
            feedback.CreateDate = DateTime.Now;
            var id = new emailDao().InsertFeddBack(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.pizza = productDao.ListPizza(4);
            ViewBag.popularMenu = productDao.ListPopularMenu(10);
            ViewBag.footer = productDao.ListFooter(8);
            ViewBag.footerT = productDao.ListFooterT(5);
            ViewBag.ourchef = new OurChefDao().ListOurChef(3);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);

        }
        [ChildActionOnly]
        public ActionResult FooterMenu()
        {
            var model = new MenuDao().ListByGroupId(3);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        public ActionResult Servicesdetails()
        {
            ViewBag.CategoryDetail = new FAQDao().ListAll();
            return View();
        }
        public ActionResult Testimonials()
        {
            ViewBag.ourchefA = new OurChefDao().ListOurChefA(3);
            return View();
        }
        public ActionResult Services()
        {
            ViewBag.an = new ServicedetailDao().ListA(6);
            ViewBag.footer = new ProductDao().ListFooter(8);
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult HeadCart()
        {
            var cart = Session[CommonContanst.CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}