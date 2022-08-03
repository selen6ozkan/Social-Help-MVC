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
        welfareDBEntities1 db = new welfareDBEntities1();
        [HttpGet]
        [AllowAnonymous]

        public ActionResult Register()
        {
            List<users_table> users = db.users_table.ToList();

            List<SelectListItem> cinsiyet = new List<SelectListItem>()
            {
                        new SelectListItem{ Text="Kadın"},
                        new SelectListItem{ Text="Erkek"},
                        
             };
            TempData["cinsiyet"] = cinsiyet;


            return View(users);
        }
        [HttpPost]  
        [AllowAnonymous]
        public ActionResult Register(users_table _user)
        {
       
            if (ModelState.IsValid)
            {
                var check = db.users_table.FirstOrDefault(s => s.user_mail == _user.user_mail);
                if (check == null)
                {
                    _user.user_password = GetMD5(_user.user_password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.users_table.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Bu e-mail zaten var.";
                    return View();
                }


            }

            return View(db);

        }

        private string GetMD5(string user_password)
        {
            throw new NotImplementedException();
        }
    }
}