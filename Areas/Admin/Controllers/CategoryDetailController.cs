using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Areas.Admin.Controllers
{
    public class CategoryDetailController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoryDetailDao();
            var model = dao.ListAllPaging();
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
            var user = new CategoryDetailDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDetailDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "CategoryDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Them thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDetailDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "CategoryDetail");
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
            new CategoryDetailDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}