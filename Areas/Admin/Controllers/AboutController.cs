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
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDao();
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
            var user = new AboutDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(About model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Them about thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(About model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "About");
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
            new AboutDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
