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
           
           
            return View(events);
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
            e.event_status="Beklemde";
            e.user_id = u.user_id;
            db.events_table.Add(e);
            _ = db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            events_table k = db.events_table.FirstOrDefault(x => x.events_id == id);
          
            return RedirectToAction("EventAdd", k);
        }

        [AllowAnonymous]
        public void Delete(int id)
        {
            events_table r = db.events_table.FirstOrDefault(x => x.events_id == id);
            db.events_table.Remove(r);
             db.SaveChanges();
           
        }


    }
} 