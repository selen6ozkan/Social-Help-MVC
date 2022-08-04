using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]

        public ActionResult Register()
        {
            List<users_table> users = db.users_table.ToList();

            return View(users);
        }
        [HttpPost]  
        [AllowAnonymous]
        public ActionResult Register(FormCollection form)
        {


            welfareDBEntities3 db=new welfareDBEntities3();
            users_table users = new users_table(); 
            users.user_name = form["user_name"].Trim();
            users.user_mail = form["user_mail"].Trim();
            users.user_phone = form["user_phone"].Trim();
            users.user_password = form["user_password"].Trim();
            users.user_type_id = 1003;
            db.users_table.Add(users);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [Authorize(Roles = "ADMIN")]
        [AllowAnonymous]
        public void Delete(int? id)
        {
            users_table r = db.users_table.FirstOrDefault(x => x.user_id == id);
            db.users_table.Remove(r);
            db.SaveChanges();

        }

    }
}