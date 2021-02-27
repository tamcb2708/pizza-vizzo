using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webMVC1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
              name: "About Company",
              url: "about-company",
              defaults: new { controller = "defalts", action = "aboutcompany", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
          );
            routes.MapRoute(
              name: "Search",
              url: "tim-kiem",
              defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
          );
            routes.MapRoute(
            name: "View",
            url: "Users",
            defaults: new { controller = "defalts", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "webMVC1.Controllers" }
        );
            routes.MapRoute(
            name: "Termsofservice",
            url: "terms-of-service",
            defaults: new { controller = "defalts", action = "Termsofservice", id = UrlParameter.Optional },
            namespaces: new[] { "webMVC1.Controllers" }
        );


            routes.MapRoute(
              name: "Privacypolicy",
              url: "privacy-policy",
              defaults: new { controller = "defalts", action = "Privacypolicy", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
          );

            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "Users", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
          );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
              name: "Success",
              url: "hoan-thanh",
              defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
              name: "Checkout",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional },
              namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
                name: "Gallery",
                url: "gallery",
                defaults: new { controller = "Gallery", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
                name: "Shop",
                url: "shop",
                defaults: new { controller = "Shop", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
                name: "Team",
                url: "team",
                defaults: new { controller = "Team", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
                name: "Service-Details",
                url: "services-details",
                defaults: new { controller = "ServiceDetails", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
               name: "Error",
               url: "bao-loi",
               defaults: new { controller = "defalts", action = "Error404", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
                name: "Product Menu",
                url: "menu/{MetaKeywords}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
               name: "ProductDetail",
               url: "chi-tiet/{id}",
               defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
                name: "Menu",
                url: "menu",
                defaults: new { controller = "Product", action = "Menu", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
            routes.MapRoute(
               name: "FAQ",
               url: "faq",
               defaults: new { controller = "FAQ", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Controllers" }
           );
            routes.MapRoute(
               name: "Admin",
               url: "Admin",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "webMVC1.Areas.Admin.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "defalts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "webMVC1.Controllers" }
            );
        }
    }
}
