using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;

namespace MVCLeegProject.Controllers
{
    public class OverzichtController : Controller
    {
        // GET: Overzicht
        public ActionResult Index()
        {
            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            //db.Clients.Find()

            return View();
        }
    }
}