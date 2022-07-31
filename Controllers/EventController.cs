using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        welfareDBEntities db=new welfareDBEntities();   
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<events_table> list1 =db.events_table.ToList();
            List<users_table> list2 = db.users_table.ToList();
            ViewBag.user = list2;
            return View(list1);
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult EventDetail(int id)
        {
            events_table e = db.events_table.FirstOrDefault(x => x.events_id == id);

            return View(e);
        }
        [HttpPost]
        public ActionResult EventDetail(events_table e)
        {
            events_table events = db.events_table.FirstOrDefault(x => x.events_id == e.events_id);

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "ADMIN")]
        public ActionResult EventDelete(int id)
        {
            //events_table s = n.events_table.FirstOrDefault(x => x.events_id == id);
            return View();
        }
        [HttpPost]
        public ActionResult EventDelete(events_table s)
        {
            events_table events = db.events_table.FirstOrDefault(x => x.events_id == s.events_id);
            //db.events_table.Remove(events);
            //db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
} 