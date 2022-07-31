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
        public ActionResult Index()
        {
            List<events_table> list1 =db.events_table.ToList();

            List<users_table> list2 = db.users_table.ToList();
            ViewBag.user = list2;
            return View(list1);
        }
    }
}