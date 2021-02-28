using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.Areas.Admin.Models;
using webMVC1.Common;
using webMVC1.DAO;

namespace webMVC1.Areas.Admin.Controllers
{

    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Login model)

        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result==1)
                {
                    var user = dao.GetById(model.UserName);            
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonContanst.USER_SESSION,userSession);
                    return RedirectToAction("index", "Home");
                }
                else if(result==0)
                {
                    ModelState.AddModelError(" ", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError(" ", "Tài Khoản Bị Khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError(" ", "Mật Khẩu Sai");
                }
                else
                {
                    ModelState.AddModelError(" ", "Đăng Nhập Không Đúng");

                }
            }       
                return View("index");
          
          
        }

    }

 
}