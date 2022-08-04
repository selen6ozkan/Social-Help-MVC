using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class SupplyController : Controller
    {
        // GET: Supply
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<supply_table> supply = db.supply_table.ToList();
            return View(supply);

        }
        public ActionResult supplyAdd()
        {
            ViewBag.supply = db.supply_table.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult supplyAdd(supply_table e, string user_name, int? supply_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            supply_table b = db.supply_table.FirstOrDefault(x => x.supply_id == supply_id);
            e.help_type_id = 9;
            e.user_id = u.user_id;
            db.supply_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            supply_table k = db.supply_table.FirstOrDefault(x => x.supply_id == id);

            return RedirectToAction("supplyAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            supply_table r = db.supply_table.FirstOrDefault(x => x.supply_id == id);
            db.supply_table.Remove(r);
            db.SaveChanges();

        }
    }
}