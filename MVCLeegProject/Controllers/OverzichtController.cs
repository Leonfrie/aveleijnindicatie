using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCLeegProject.Models;

namespace MVCLeegProject.Controllers
{
    public class OverzichtController : Controller
    {
        // GET: Overzicht
        public ActionResult Index()
        {
            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            var r1 = db.Clients.Where(c => c.Behandelaar == User.Identity.GetUserId());
            

            return View(r1);
        }


        public ActionResult Inzien(string id)
        {
            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();



            var r1 = db.Formulier_tt.Where( f => f.Clientnummer == id);

            var r2 = r1.Where(r => r.endTime == null);

            return View(r2);
        }


    }
}