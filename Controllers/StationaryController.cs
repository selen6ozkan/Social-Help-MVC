using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
namespace WebApplication8.Controllers
{
    public class StationaryController : Controller
    {
        // GET: Stationary

        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<stationary_table> stationary = db.stationary_table.ToList();
            return View(stationary);

        }
        public ActionResult stationaryAdd()
        {


            List<SelectListItem> packet = new List<SelectListItem>()
            {
                        new SelectListItem{ Text="Kalem,Silgi,Defter"},
                        new SelectListItem{ Text="Kitap,Dergi"},
                        new SelectListItem{ Text="Boya,Resim Defteri"},
                        new SelectListItem{ Text="Okul Çantası,Beslenme"},
                       
             };
            TempData["packet"] = packet;

            ViewBag.stationary = db.stationary_table.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult stationaryAdd(stationary_table e, string user_name, int? stationary_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            stationary_table b = db.stationary_table.FirstOrDefault(x => x.stationary_id == stationary_id);
            e.help_type_id = 7;









            e.user_id = u.user_id;
            db.stationary_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            stationary_table k = db.stationary_table.FirstOrDefault(x => x.stationary_id == id);

            return RedirectToAction("stationaryAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            stationary_table r = db.stationary_table.FirstOrDefault(x => x.stationary_id == id);
            db.stationary_table.Remove(r);
            db.SaveChanges();

        }
    }
}