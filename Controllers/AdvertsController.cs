using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class AdvertsController : Controller
    {
        welfareDBEntities db = new welfareDBEntities();
        // GET: Adverts
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()

        {
            
            List<users_table> users = db.users_table.ToList();
            List<adverts_table> adverts = db.adverts_table.ToList();

            List<help_type_table> helps = db.help_type_table.ToList();

            ViewBag.user = helps;
            ViewBag.user = users;
            return View(adverts);
        }

        public ActionResult AdvertAdd()
        {
            ViewBag.users = db.users_table.ToList();
            ViewBag.helps = db.help_type_table.ToList();
            
            return View();
        }
        [HttpPost]

        public ActionResult AdvertAdd(adverts_table e)
        {
            db.adverts_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}