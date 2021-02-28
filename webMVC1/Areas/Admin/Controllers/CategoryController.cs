using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using PagedList;
using webMVC1.EF;


namespace webMVC1.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoryDao();
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
            var user = new CategoryDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(Categorys model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
               
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Them category thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Categorys model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Category");
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
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}