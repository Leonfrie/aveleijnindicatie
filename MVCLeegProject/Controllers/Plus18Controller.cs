using MVCLeegProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


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
        public ActionResult AddToDomeinLocal(string _button, bool _buttonChecked)
        { 
            var checkBox = db.checkBoxMaps.Where(c => c.checkBox_id.Equals(_button)).First();

            var category

            if(_buttonChecked)
            {
                LocalSaveModel.DomeinBeschrijvingen.Add(checkBox.beschrijving);
                LocalSaveModel.Points += checkBox.value;
            }
            else
            {
                LocalSaveModel.DomeinBeschrijvingen.Remove(checkBox.beschrijving);
                LocalSaveModel.Points -= checkBox.value;
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult AddToExtraLocal(string _beperking, int _kinderenPoints, int _zorgmijdingPoints)
        {
            LocalSaveModel.MateBeperking = _beperking;

            //START CALCULATE POINTS CHILDREN & CARE AVOIDANCE
            if(!LocalSaveModel.Kinderen)
            {
                LocalSaveModel.Points += _kinderenPoints;
            }
            if (!LocalSaveModel.Zorgmijding)
            {
                LocalSaveModel.Points += _zorgmijdingPoints;
            }
            if(LocalSaveModel.Kinderen && _kinderenPoints == 0)
            {
                LocalSaveModel.Points -= 6;
            }
            if (LocalSaveModel.Zorgmijding && _zorgmijdingPoints == 0)
            {
                LocalSaveModel.Points -= 4;
            }
            //END CALCULATE POINTS CHILDREN & CARE AVOIDANCE

            LocalSaveModel.Kinderen = _kinderenPoints == 0 ? false : true;
            LocalSaveModel.Zorgmijding = _zorgmijdingPoints == 0 ? false : true;

            return new EmptyResult();
        }

        public ActionResult CalculateFirst()
        {
            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                DomeinBeschrijvingen = LocalSaveModel.DomeinBeschrijvingen,

                Points = LocalSaveModel.Points,
                MateBeperking = LocalSaveModel.MateBeperking,
                Kinderen = LocalSaveModel.Kinderen,
                Zorgmijding = LocalSaveModel.Zorgmijding
            };

            return View("Eerste-deel-indicatie", _localSaveModel);
        }
        // Save form info to database
        // 
        [HttpPost]
        public ActionResult SaveConfirm(_LocalSaveModel model)
        {
            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            

            if (ModelState.IsValid)
            {
                Client client = new Client();

                var thisClient = db.Clients.Where(c => c.clientnummer == model.Clientnummer);


                if(!thisClient.Any())
                {
                    client.clientnummer = model.Clientnummer;
                    client.voornaam = model.Voornaam;
                    client.achternaam = model.Achternaam;
                    client.geboortedatum = model.Geboortedatum;
                    client.Behandelaar = User.Identity.ToString();

                    db.Clients.Add(client);
                }
                

                Result result = new Result();

                StringBuilder pickedBuilder = new StringBuilder();

                foreach(var item in model.DomeinBeschrijvingen)
                {

                    if (pickedBuilder.Length == 0)
                    {
                        pickedBuilder.Append(item);
                    }
                    else
                    {
                        pickedBuilder.Append("," + item);
                    }

                    
                }


                result.pickedBoxes = pickedBuilder.ToString();
                result.commentaar = model.Commentaar;


                Formulier_tt formulier_tt = new Formulier_tt();

                if(db.Formulier_tt.Any(r => r.Clientnummer == client.clientnummer))
                {
                    formulier_tt.result_id = result.result_id;
                    formulier_tt.Clientnummer = client.clientnummer;
                    formulier_tt.endTime = DateTime.UtcNow;
                    formulier_tt.startTime = DateTime.UtcNow;
                }
                else
                {
                    formulier_tt.result_id = result.result_id;
                    formulier_tt.Clientnummer = client.clientnummer;
                    formulier_tt.startTime = DateTime.UtcNow;
                }


                db.Formulier_tt.Add(formulier_tt);

                db.SaveChanges();


                
            }
            
            



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