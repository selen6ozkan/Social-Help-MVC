using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class Financial_SupportController : Controller
    {
        // GET: Financial_Support
        welfareDBEntities3 db = new welfareDBEntities3();
        [HttpGet]
        [Authorize(Roles = "ADMIN,KULLANICI")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<financial_support_table> financial = db.financial_support_table.ToList();
            return View(financial); 

        }
        public ActionResult financialAdd()
        {
            ViewBag.financial = db.financial_support_table.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult financialAdd(financial_support_table e, string user_name, int? financial_support_id)
        {
            users_table u = db.users_table.FirstOrDefault(x => x.user_name == user_name);
            financial_support_table b = db.financial_support_table.FirstOrDefault(x => x.financial_support_id == financial_support_id);
            e.help_type_id = 6;
            e.user_id = u.user_id;
            db.financial_support_table.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public RedirectToRouteResult Update(int id)
        {
            financial_support_table k = db.financial_support_table.FirstOrDefault(x => x.financial_support_id == id);

            return RedirectToAction("financialAdd", k);
        }
        [AllowAnonymous]
        public void Delete(int id)
        {
            financial_support_table r = db.financial_support_table.FirstOrDefault(x => x.financial_support_id == id);
            db.financial_support_table.Remove(r);
            db.SaveChanges();

        }

    }
}