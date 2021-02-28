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
    public class OurChefController : BaseController
    {
        // GET: Admin/OurChef
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new OurChefDao();
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
            var user = new OurChefDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(OurChefs model)
        {
            if (ModelState.IsValid)
            {
                var dao = new OurChefDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "OurChef");
                }
                else
                {
                    ModelState.AddModelError("", "Them OurChef thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(OurChefs model)
        {
            if (ModelState.IsValid)
            {
                var dao = new OurChefDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "OurChef");
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
            new OurChefDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}