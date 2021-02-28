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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult create()
        {
            SetViewbag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDao();
            var product =  dao.GetByID(id);
            SetViewbag(product.CategoryID);
            var pro = dao.ViewDetail(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult create(Product model)
        {
            if(ModelState.IsValid)
            {

                var dao = new ProductDao();
               
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Them product thanh cong");
                }
            }
            SetViewbag();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                if (!string.IsNullOrEmpty(model.Name))
                {
                    var result = dao.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cap nhap thanh cong");
                    }
                }
            }
            SetViewbag(model.CategoryID);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewbag(long? selectedId=null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAllPaging(), "ID", "Name", selectedId);

        }

    }
}