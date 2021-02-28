using BotDetect.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.Common;
using webMVC1.DAO;
using webMVC1.EF;
using webMVC1.Models;

namespace webMVC1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Logout()
        {
            Session[CommonContanst.USER_SESSION] = null;
            return Redirect("/");

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonContanst.USER_SESSION, userSession);
                    return RedirectToAction("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError(" ", "Tài Khoản không tồn tại");
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
                    ModelState.AddModelError(" ", "Đăng  Nhập Không Đúng");

                }
            }
            return View("model");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "registerCapcha", " mã xác nhận không đúng!")]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.PassWord = Encryptor.MD5Hash(model.PassWord);
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreateDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ModelState.Clear();
                        ViewBag.Success = "Đăng ký thành công";
                        model = new Register();
                    }
                    else
                    {
                        ModelState.AddModelError("", "đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }



    }
}