using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{

    public class Blood_DonationController : Controller
    {
        welfareDBEntities1 db = new welfareDBEntities1();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        // GET: Blood_Donation
        public ActionResult Index()
        {
            List<blood_donation_table> bd=db.blood_donation_table.ToList();
            return View(bd);
        }
        public ActionResult donationAdd()
        {
            ViewBag.bd = db.blood_donation_table.ToList();

            return View();
        }
        [HttpPost]  
        public ActionResult donationAdd(blood_donation_table e, string user_name, int? blood_donation_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            blood_donation_table bd = db.blood_donation_table.FirstOrDefault(x => x.blood_donation_id == blood_donation_id);
            e.blood_donation_status = "Beklemede";
            e.help_type_id = 1;
            e.user_id = u.user_id;
            db.blood_donation_table.Add(e);
             db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            blood_donation_table k = db.blood_donation_table.FirstOrDefault(x => x.blood_donation_id == id);

            return RedirectToAction("donationAdd", k);
        }

        // [MyAuthorization(Roles = "ADMIN")]
        [AllowAnonymous]
        public void Delete(int id)
        {
            blood_donation_table r = db.blood_donation_table.FirstOrDefault(x => x.blood_donation_id == id);
            db.blood_donation_table.Remove(r);
            db.SaveChanges();

        }


    }
}