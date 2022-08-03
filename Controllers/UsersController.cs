using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        welfareDBEntities1 db = new welfareDBEntities1();
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<users_table> users = db.users_table.ToList();
            return View(users);
        }
    }
}