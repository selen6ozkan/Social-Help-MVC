using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ShelterController : Controller
    {
        // GET: Shelter


        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<shelter_table> shelter = db.shelter_table.ToList();
            return View(shelter);

        }
        public ActionResult shelterAdd()
        {
            ViewBag.shelter = db.shelter_table.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult shelterAdd(shelter_table e, string user_name, int? shelter_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            shelter_table b = db.shelter_table.FirstOrDefault(x => x.shelter_id == shelter_id);
            e.help_type_id = 8;
            e.user_id = u.user_id;
            db.shelter_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            shelter_table k = db.shelter_table.FirstOrDefault(x => x.shelter_id == id);

            return RedirectToAction("shelterAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            shelter_table r = db.shelter_table.FirstOrDefault(x => x.shelter_id == id);
            db.shelter_table.Remove(r);
            db.SaveChanges();

        }

    }
}