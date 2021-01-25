using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;
using PagedList;
namespace webMVC1.Areas.Admin.Controllers
{
    public class MenuDetailController : Controller
    {
        // GET: Admin/MenuDetail
        public ActionResult Index(string searchString, int page = 1, int pageSize = 1)
        {
            var dao = new MenuDetailDao();
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
            var user = new MenuDetailDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(MenuType model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDetailDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "MenuDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Them menutype thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(MenuType model)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDetailDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "MenuDetail");
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
            new MenuDetailDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}