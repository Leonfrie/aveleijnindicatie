using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;

namespace MVCLeegProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LocalSaveModel.DomeinBeschrijvingen1.Clear();
            LocalSaveModel.DomeinBeschrijvingen2.Clear();
            LocalSaveModel.DomeinBeschrijvingen3.Clear();
            LocalSaveModel.DomeinBeschrijvingen4.Clear();
            LocalSaveModel.DomeinBeschrijvingen5.Clear();
            LocalSaveModel.DomeinBeschrijvingen6.Clear();
            LocalSaveModel.EersteDeelIndicatie = 0;
            LocalSaveModel.Kinderen = false;
            LocalSaveModel.Zorgmijding = false;
            LocalSaveModel.Points = 0;
            LocalSaveModel.MateBeperking = "";
            LocalSaveModel.TweedeDeelIndicatie = "";
            LocalSaveModel.Volwassene = false;
            return View();
        }

        public ActionResult categories()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult doelen()
        {

            return View();
        }
    }
}