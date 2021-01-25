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
    public class DetailController : BaseController
    {
        // GET: Admin/Detail
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DetailDao();
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
            var user = new DetailDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(Detail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DetailDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Detail");
                }
                else
                {
                    ModelState.AddModelError("", "Them detail thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Detail model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DetailDao();

                if (!string.IsNullOrEmpty(model.Name))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Detail");
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
            new DetailDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new DetailDao().ChangeStatus(id);
            return Json(new
            {
                status = result

            });
        }
    }
}