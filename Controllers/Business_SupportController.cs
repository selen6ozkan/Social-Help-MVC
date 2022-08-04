using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class Business_SupportController : Controller
    {
        // GET: Business_Support
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {

            List<business_help_table> bh = db.business_help_table.ToList();
            return View(bh);
        }
        public ActionResult businessAdd()
        {
            List<SelectListItem> job = new List<SelectListItem>()
            {
                        new SelectListItem{ Text="Avukat"},
                        new SelectListItem{ Text="Doktor"},
                        new SelectListItem{ Text="Mühendis"},
                        new SelectListItem{ Text="Pilot"},
                        new SelectListItem{ Text="Öğretmen"},
                        new SelectListItem{ Text="Veteriner"},
                        new SelectListItem{ Text="Diş Hekimi" },
                        new SelectListItem{ Text="Aşcı"},
                        new SelectListItem{ Text="Bankacı"},
                        new SelectListItem{ Text="Sekreter"},
             };
            TempData["job"] = job;

            ViewBag.year = new SelectList(Enumerable.Range(0, 30));
            ViewBag.bh = db.business_help_table.ToList();
            return View();  
        }
        [HttpPost]  
        public ActionResult businessAdd(business_help_table e, string user_name, int? business_help_id)
        {

            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            business_help_table b= db.business_help_table.FirstOrDefault(x => x.business_help_id == business_help_id);
            e.help_type_id = 2;
            e.user_id = u.user_id;
            db.business_help_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            business_help_table k = db.business_help_table.FirstOrDefault(x => x.business_help_id == id);

            return RedirectToAction("businessAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            business_help_table r = db.business_help_table.FirstOrDefault(x=>x.business_help_id==id);
            db.business_help_table.Remove(r);
            db.SaveChanges();

        }

    }
}