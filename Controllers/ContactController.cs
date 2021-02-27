using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContact();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string name, int phone, string address, string email, string yeucau)
        {
            var feedback = new FeedBack();
            feedback.Name = name;
            feedback.Phone = phone;
            feedback.Address = address;
            feedback.Email = email;
            feedback.Content = yeucau;
            feedback.CreateDate = DateTime.Now;
            var id = new ContactDao().InsertFeddBack(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

    }
}