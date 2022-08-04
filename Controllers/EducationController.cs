using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
  
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {

            List<education_table> edu = db.education_table.ToList();
            return View(edu);
        }
        public ActionResult educationAdd()
        {
            List<SelectListItem> edu = new List<SelectListItem>()
            {
                        new SelectListItem{ Text="İlkokul"},
                        new SelectListItem{ Text="Ortaokul"},
                        new SelectListItem{ Text="Lise"},
                        new SelectListItem{ Text="Üniversite"},
                      
             };
            TempData["edu"] = edu;
            ViewBag.edu = db.education_table.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult educationAdd(education_table e, string user_name, int? education_id)
        {

            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            education_table b = db.education_table.FirstOrDefault(x => x.education_id == education_id);
            e.help_type_id = 4;
            e.user_id = u.user_id;
            db.education_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            education_table k = db.education_table.FirstOrDefault(x => x.education_id == id);

            return RedirectToAction("educationAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            education_table r = db.education_table.FirstOrDefault(x => x.education_id == id);
            db.education_table.Remove(r);
            db.SaveChanges();

        }

    }
}