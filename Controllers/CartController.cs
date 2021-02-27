using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMVC1.DAO;
using webMVC1.Models;
using System.Web.Script.Serialization;
using webMVC1.EF;
using System.Net.Mail;
using System.Configuration;
using Commom;

namespace webMVC1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult checkout()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult checkout(string shipName,string shipEmail,string shipMobile,string shipAddress)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = shipAddress;
            order.ShipEmail = shipEmail;
            order.ShipName = shipName;
            order.ShipMoblie = shipMobile;
            try
            {
                var id = new OderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OderDetail();
                    orderDetail.ProductID = item.Pro.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Pro.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    total += (item.Pro.Price.GetValueOrDefault(0) * item.Quantity);
                }
               
            }
            catch(Exception )
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult checkoutTempleate(string shipName, string shipEmail, string shipMobile, string shipAddress)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = shipAddress;
            order.ShipEmail = shipEmail;
            order.ShipName = shipName;
            order.ShipMoblie = shipMobile;
            try
            {
                var id = new OderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OderDetail();
                    orderDetail.ProductID = item.Pro.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Pro.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    total += (item.Pro.Price.GetValueOrDefault(0) * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", shipMobile);
                content = content.Replace("{{Email}}", shipEmail);
                content = content.Replace("{{Address}}", shipAddress);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(shipEmail, "Order from", content);
                new MailHelper().SendMail(toEmail, "Order from", content);
            }
            catch (Exception)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Pro.ID == item.Pro.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productID,int quantity,string size)
        {
            var product = new ProductDao().ViewDetail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.Pro.ID==productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Pro.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Size = size;
                    item.Pro = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Pro = product;
                item.Size = size;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                Session[CartSession] = list;
                list.Add(item);
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            }) ; 
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Pro.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }





    }
}