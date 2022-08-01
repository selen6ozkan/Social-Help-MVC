using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using System.Web.Security;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
     
        public ActionResult Login(users_table u)
        {
            welfareDBEntities db = new welfareDBEntities();
            users_table user = db.users_table.FirstOrDefault(x => x.user_name == u.user_name && x.user_password == u.user_password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.user_name, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı Adı veya Şifre hatalı";
                return View();
            }


        }
        public ActionResult LogOut()
        {
            string name = FormsAuthentication.FormsCookieName;
            HttpCookie authcookie = HttpContext.Request.Cookies[name];
            FormsAuthenticationTicket t = FormsAuthentication.Decrypt(authcookie.Value);
            string tname = t.Name;

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }

}