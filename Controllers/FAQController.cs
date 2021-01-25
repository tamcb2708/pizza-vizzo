using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.EF;

namespace webMVC1.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult Index()
        {
            var model = new FAQDao().GetActiveContact();
            ViewBag.anser = new FAQDao().ListAll();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string name,string email,int phone_number, string msg_subject, string message)
        {
            var feedback = new questionandanswer();
            feedback.Name = name;
            feedback.Email = email;
            feedback.Phone = phone_number;
            feedback.Subject = msg_subject;
            feedback.Question = message;
            feedback.CreateDate = DateTime.Now;
            var id = new FAQDao().InsertFeddBack(feedback);
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