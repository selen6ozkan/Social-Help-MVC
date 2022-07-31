using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication8.Controllers
{
    public class AdvertsController : Controller
    {
        // GET: Adverts
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}