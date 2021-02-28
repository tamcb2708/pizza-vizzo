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
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index()
        {
            var dao = new ContactDao();
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
            var user = new ContactDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    ModelState.AddModelError("", "Them contact thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();

                if (!string.IsNullOrEmpty(model.content))
                {


                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Contact");
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
            new ContactDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContactDao().ChangeStatus(id);
            return Json(new
            {
                status = result

            });
        }
    }
}
