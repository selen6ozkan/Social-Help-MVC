using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using WebApplication8.Security;

namespace WebApplication8.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        welfareDBEntities1 db=new welfareDBEntities1();   
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<events_table> events =db.events_table.ToList();
            List<users_table> list2 = db.users_table.ToList();
           
            return View(events);
        }
        

        [MyAuthorization(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult EventDetail(int? id)
        {
            events_table e = db.events_table.FirstOrDefault(x => x.events_id == id);

            return View(e);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult EventDetail(events_table e)
        {
            events_table events = db.events_table.FirstOrDefault(x => x.events_id == e.events_id);

            return RedirectToAction("Index");
        }
        [HttpGet]

        [MyAuthorization(Roles = "ADMIN")]
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

        public ActionResult EventAdd()
        {
           ViewBag.events=db.events_table.ToList();
           
            return View();
        }
        [HttpPost]
        
        public ActionResult EventAdd(events_table e, string user_name,int? events_id)
        {
            users_table u = db.users_table.FirstOrDefault(x=>x.user_name == user_name);
            events_table ev = db.events_table.FirstOrDefault(x => x.events_id == events_id);
            e.event_status = "Beklemede";
            e.user_id = u.user_id;
          
            db.events_table.Add(e);
            _ = db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
} 