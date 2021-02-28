using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Areas.Admin.Controllers
{
    public class EmailController : BaseController
    {
        // GET: Admin/Email
        public ActionResult Index()
        {
            var dao = new emailDao();
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
            var user = new emailDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(Email model)
        {
            if (ModelState.IsValid)
            {
                var dao = new emailDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Email");
                }
                else
                {
                    ModelState.AddModelError("", "Them Email thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Email model)
        {
            if (ModelState.IsValid)
            {
                var dao = new emailDao();

                if (!string.IsNullOrEmpty(model.Email1))
                {
                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Email");
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
            new emailDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}