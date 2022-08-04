using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ClothesController : Controller
    {
        // GET: Clothes
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<clothes_table> clths = db.clothes_table.ToList();
            return View(clths);
           
        }
        public ActionResult clothesAdd()
        {

            List<SelectListItem> clothes = new List<SelectListItem>()
            {
                        new SelectListItem{ Text="Üst Giyim"},
                        new SelectListItem{ Text="Alt Giyim"},
                        new SelectListItem{ Text="Ayakkabı"},
                        
             };
            TempData["clothes"] = clothes;

            ViewBag.clths = db.clothes_table.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult clothesAdd(clothes_table e, string user_name, int? clothes_id)
        {

            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            clothes_table b = db.clothes_table.FirstOrDefault(x => x.clothes_id == clothes_id);
            e.help_type_id = 3;
            e.user_id = u.user_id;
            db.clothes_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            clothes_table k = db.clothes_table.FirstOrDefault(x => x.clothes_id == id);

            return RedirectToAction("clothesAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            clothes_table r = db.clothes_table.FirstOrDefault(x => x.clothes_id == id);
            db.clothes_table.Remove(r);
            db.SaveChanges();

        }



    }
}