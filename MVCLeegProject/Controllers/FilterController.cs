using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLeegProject.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index(int type)
        {
            return View();
        }
    }
}