﻿using MVCLeegProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;
using System.Linq;

namespace MVCLeegProject.Controllers
{
    public class Plus18Controller : Controller
    {

        DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

        // GET: Plus18
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PostCheckBoxes(CheckBoxesModel model)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowNumberOfIndication(List<string> values)
        {
            List<string> stringArray = new List<string>();

            foreach(var item in values)
            {
                stringArray.Add(db.checkBoxMaps.Where(b => b.checkBox_id == item).FirstOrDefault().beschrijving);
            }

            /*ResultCheckBoxModel result = new ResultCheckBoxModel
            {
                beschrijving = 
            };*/
            
            return View();
        }


        public ActionResult Plus18Send(ResultVM model)
        {

            // Zet resultaat van quiz in ViewBag


            /*ViewBag.indicatieB_id = model.IndicatieB_id;

            ViewBag. = model.vraag2;

            ViewBag.vraag3 = model.vraag3;

            ViewBag.vraag4 = model.vraag4;

            ViewBag.vraag5 = model.vraag5;

            ViewBag.vraag6 = model.vraag6;

            ViewBag.vraag7 = model.vraag7;

            ViewBag.vraag8 = model.vraag8;

            ViewBag.vraag9 = model.vraag9;

            int totaalB = model.vraag1 + model.vraag2 + model.vraag3;
            int totaalN = model.vraag4 + model.vraag5 + model.vraag6 + model.vraag7 + model.vraag8 + model.vraag9;

            ViewBag.TotaalB = totaalB;
            ViewBag.TotaalN = totaalN;*/



            return RedirectToAction("Plus18Check");
        }


        public ActionResult Plus18Check()
        {

            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            ResultVM result = new ResultVM();


            result.IndicatieB_id = ViewBag.indicatieB_id;
            result.Wet = ViewBag.wet;
            result.Kenmerken_inwoner = ViewBag.kenmerken_inwoner;
            result.Doel_ondersteuning = ViewBag.doel_ondersteuning;
            result.Ondersteuning = ViewBag.ondersteuning;

            result.IndicatieN_id = ViewBag.indicatieN_id;
            result.GedragsProblematiek = ViewBag.gedragsProblematiek;
            result.Context = ViewBag.context;
            result.Escalatie = ViewBag.escalatie;
            result.Motivatie = ViewBag.motivatie;
            result.OndersteuningN = ViewBag.ondersteuning;
            result.Veranderingen = ViewBag.veranderingen;

            //TODO: Advies 
            if (ViewBag.totaalN)
            {

            }

            return View(result);
        }

    }
}