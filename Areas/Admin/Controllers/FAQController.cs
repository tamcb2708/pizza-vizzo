using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Areas.Admin.Controllers
{
    public class FAQController : BaseController
    {
        // GET: Admin/FAQ
        public ActionResult Index()
        {
            var dao = new FAQDao();
            var model = dao.ListAllPaging();
            return View(model);
        }
    
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new FAQDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(questionandanswer model)
        {
            if (ModelState.IsValid)
            {
                var dao = new FAQDao();

                if (!string.IsNullOrEmpty(model.Question))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "FAQ");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cap nhap thanh cong");
                    }
                }
            }
            return View();
        }
    }
}