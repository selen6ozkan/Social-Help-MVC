using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class Animal_SupportController : Controller
    {
        // GET: Animal_Support
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<street_animal_table> animal = db.street_animal_table.ToList();
            return View(animal);

        }
        public ActionResult animalAdd()
        {
            ViewBag.financial = db.street_animal_table.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult animalAdd(street_animal_table e, string user_name, int? street_animal_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            street_animal_table b = db.street_animal_table.FirstOrDefault(x => x.street_animal_id == street_animal_id);
            e.help_type_id = 10;
            e.user_id = u.user_id;
            db.street_animal_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            street_animal_table k = db.street_animal_table.FirstOrDefault(x => x.street_animal_id == id);

            return RedirectToAction("animalAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            street_animal_table r = db.street_animal_table.FirstOrDefault(x => x.street_animal_id == id);
            db.street_animal_table.Remove(r);
            db.SaveChanges();

        }
    }
}