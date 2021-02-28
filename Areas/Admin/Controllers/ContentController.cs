using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new ContentDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Them content thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Content");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cap nhap thanh cong");
                    }
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}