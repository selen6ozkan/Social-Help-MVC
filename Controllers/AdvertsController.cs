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
        welfareDBEntities3 db = new welfareDBEntities3();
        // GET: Adverts
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()

        {

            ViewModel viewModel = new ViewModel();
            viewModel.Blood = db.blood_donation_table.ToList();
            viewModel.Business = db.business_help_table.ToList();
            viewModel.Clothes = db.clothes_table.ToList();
            viewModel.Education = db.education_table.ToList();
            viewModel.Event = db.events_table.ToList();
            viewModel.Financial = db.financial_support_table.ToList();
            viewModel.Shelter = db.shelter_table.ToList();
            viewModel.Stationary = db.stationary_table.ToList();
            viewModel.Animal = db.street_animal_table.ToList();
            viewModel.Supply = db.supply_table.ToList();
            viewModel.User = db.users_table.ToList();

            return View(viewModel);
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