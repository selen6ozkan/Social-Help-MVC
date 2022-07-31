using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HelpsController : Controller
    {
        welfareDBEntities db = new welfareDBEntities();
        // GET: Helps
        public ActionResult Index()
        {
            List<events_table> list1 = db.events_table.ToList();
            List<users_table> list2 = db.users_table.ToList();
            List<blood_donation_table> list3 = db.blood_donation_table.ToList();
            List<supply_table> list4 = db.supply_table.ToList();
          
            List<stationary_table> list5 = db.stationary_table.ToList();
            List<education_table> list6 = db.education_table.ToList();
            List<street_animal_table> list7 = db.street_animal_table.ToList();
            List<shelter_table> list8 = db.shelter_table.ToList();
            List<business_help_table> list9 = db.business_help_table.ToList();
            List<financial_support_table> list10 = db.financial_support_table.ToList();
            List<clothes_table> list11 = db.clothes_table.ToList();

            ViewBag.user = list2;
            ViewBag.blood=list3;  
            ViewBag.supply=list4;   
            return View(list1);
           
        }
        public ActionResult Blood_Donation(int? id)
        {
            blood_donation_table e = db.blood_donation_table.FirstOrDefault(x => x.blood_donation_id == id);

            return View(e);
        }
        [HttpPost]
        public ActionResult Blood_Donation(blood_donation_table e)
        {
            blood_donation_table blood = db.blood_donation_table.FirstOrDefault(x => x.blood_donation_id == e.blood_donation_id);

            return RedirectToAction("Index");
        }


        public ActionResult Supply(int? id)
        {
            supply_table supply = db.supply_table.FirstOrDefault(x => x.supply_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Supply(supply_table s)
        {
            supply_table supply = db.supply_table.FirstOrDefault(x => x.supply_id == s.supply_id);
            db.supply_table.Remove(supply);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Stationary(int? id)
        {
            stationary_table stationary = db.stationary_table.FirstOrDefault(x => x.stationary_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Stationary(stationary_table s)
        {
            stationary_table stationary = db.stationary_table.FirstOrDefault(x => x.stationary_id == s.stationary_id);
            db.stationary_table.Remove(stationary);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Education(int? id)
        {
            education_table education = db.education_table.FirstOrDefault(x => x.education_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Education(education_table s)
        {
            education_table education = db.education_table.FirstOrDefault(x => x.education_id == s.education_id);
            db.education_table.Remove(education);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Animal(int? id)
        {
            street_animal_table animal = db.street_animal_table.FirstOrDefault(x => x.street_animal_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Animal(street_animal_table s)
        {
            street_animal_table animal = db.street_animal_table.FirstOrDefault(x => x.street_animal_id == s.street_animal_id);
            db.street_animal_table.Remove(animal);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Shelter(int? id)
        {
            shelter_table shelter = db.shelter_table.FirstOrDefault(x => x.shelter_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Shelter(shelter_table s)
        {
            shelter_table shelter = db.shelter_table.FirstOrDefault(x => x.shelter_id == s.shelter_id);
            db.shelter_table.Remove(shelter);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Business(int? id)
        {
            business_help_table business = db.business_help_table.FirstOrDefault(x => x.business_help_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Business(business_help_table s)
        {
            business_help_table business = db.business_help_table.FirstOrDefault(x => x.business_help_id == s.business_help_id);
            db.business_help_table.Remove(business);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Financial_Support(int? id)
        {
            financial_support_table financial = db.financial_support_table.FirstOrDefault(x => x.financial_support_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Financial_Support(financial_support_table s)
        {
            financial_support_table financial = db.financial_support_table.FirstOrDefault(x => x.financial_support_id == s.financial_support_id);
            db.financial_support_table.Remove(financial);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Clothes(int? id)
        {
            clothes_table clothes = db.clothes_table.FirstOrDefault(x => x.clothes_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Clothes(clothes_table s)
        {
            clothes_table clothes = db.clothes_table.FirstOrDefault(x => x.clothes_id == s.clothes_id);
            db.clothes_table.Remove(clothes);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}