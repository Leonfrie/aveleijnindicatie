//using MVCLeegProject.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MVCLeegProject.Controllers
//{
//    public class Onder18Controller : Controller
//    {
//        // GET: Onder18
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Onder18(QuizJeugdVM model)
//        {
//            return View();
//        }


//        public ActionResult Onder18Confirm()
//        {
//            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

//            ResultVM result = new ResultVM();
//            IndicatieNiveau iN = new IndicatieNiveau();
//            IndicatieBehoeften iB = new IndicatieBehoeften();

//            iN = db.IndicatieNiveaux.Find(ViewBag.indicatieN);
//            iB = db.IndicatieBehoeftens.Find(ViewBag.indicatieB);


//            result.IndicatieB_id = iB.indicatieB_id;
//            result.Wet = iB.wet;
//            result.Kenmerken_inwoner = iB.kenmerken_inwoner;
//            result.Doel_ondersteuning = iB.doel_ondersteuning;
//            result.Ondersteuning = iB.ondersteuning;

//            result.IndicatieN_id = iN.indicatieN_id;
//            result.GedragsProblematiek = iN.gedragsProblematiek;
//            result.Context = iN.context;
//            result.Escalatie = iN.escalatie;
//            result.Motivatie = iN.motivatie;
//            result.OndersteuningN = iN.ondersteuning;
//            result.Veranderingen = iN.veranderingen;


//            return View(result);
//        }

//        [HttpPost]
//        public ActionResult Onder18()
//        {
//            return View();
//        }

//    }
//}