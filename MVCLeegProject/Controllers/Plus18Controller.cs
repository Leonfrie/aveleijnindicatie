using MVCLeegProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;

namespace MVCLeegProject.Controllers
{
    public class Plus18Controller : Controller
    {
        // GET: Plus18
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult Plus18Send(int totaalWaarde)
        //{

        //    // Zet resultaat van quiz in ViewBag


        //    ViewBag.vraag1 = model.vraag1;

        //    ViewBag.vraag2 = model.vraag2;

        //    ViewBag.vraag3 = model.vraag3;

        //    ViewBag.vraag4 = model.vraag4;

        //    ViewBag.vraag5 = model.vraag5;

        //    ViewBag.vraag6 = model.vraag6;

        //    ViewBag.vraag7 = model.vraag7;

        //    ViewBag.vraag8 = model.vraag8;

        //    ViewBag.vraag9 = model.vraag9;

        //    int totaalB = model.vraag1 + model.vraag2 + model.vraag3;
        //    int totaalN = model.vraag4 + model.vraag5 + model.vraag6 + model.vraag7 + model.vraag8 + model.vraag9;

        //    ViewBag.TotaalB = totaalB;
        //    ViewBag.TotaalN = totaalN;



        //    return RedirectToAction("Plus18Check");
        //}


        public ActionResult Plus18Check()
        {

            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            ResultVM result = new ResultVM();

            IndicatieNiveau iN = new IndicatieNiveau();
            IndicatieBehoeften iB = new IndicatieBehoeften();

            iN = db.IndicatieNiveaux.Find(ViewBag.indicatieN);
            iB = db.IndicatieBehoeftens.Find(ViewBag.indicatieB);

            result.IndicatieB_id = ViewBag.indicatieB_id;
            result.Wet = iB.wet;
            result.Kenmerken_inwoner = iB.kenmerken_inwoner;
            result.Doel_ondersteuning = iB.doel_ondersteuning;
            result.Ondersteuning = iB.ondersteuning;

            result.IndicatieN_id = iN.indicatieN_id;
            result.GedragsProblematiek = iN.gedragsProblematiek;
            result.Context = iN.context;
            result.Escalatie = iN.escalatie;
            result.Motivatie = iN.motivatie;
            result.OndersteuningN = iN.ondersteuning;
            result.Veranderingen = iN.veranderingen;

            //TODO: Advies 
            if (ViewBag.totaalN)
            {

            }

            return View(result);
        }

    }
}