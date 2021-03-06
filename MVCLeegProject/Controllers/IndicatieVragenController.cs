﻿using MVCLeegProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;

namespace MVCLeegProject.Controllers
{
    public class IndicatieVragenController : Controller
    {

        string clientnr = "";
        Client client2;

        DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

        // GET: Plus18
        public ActionResult Index()
        {
            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                Volwassene = LocalSaveModel.Volwassene
            };

            return View(_localSaveModel);
        }

        // GET: Plus18
        public ActionResult Main(bool volwassene)
        {
            LocalSaveModel.Volwassene = volwassene;

            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                Volwassene = LocalSaveModel.Volwassene
            };

            return View(_localSaveModel);
        }
        
        public ActionResult TweedeDeelIndicatie()
        {
            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                DomeinBeschrijvingen1 = LocalSaveModel.DomeinBeschrijvingen1,
                DomeinBeschrijvingen2 = LocalSaveModel.DomeinBeschrijvingen2,
                DomeinBeschrijvingen3 = LocalSaveModel.DomeinBeschrijvingen3,
                DomeinBeschrijvingen4 = LocalSaveModel.DomeinBeschrijvingen4,
                DomeinBeschrijvingen5 = LocalSaveModel.DomeinBeschrijvingen5,
                DomeinBeschrijvingen6 = LocalSaveModel.DomeinBeschrijvingen6,
                Points = LocalSaveModel.Points,
                MateBeperking = LocalSaveModel.MateBeperking,
                Kinderen = LocalSaveModel.Kinderen,
                Zorgmijding = LocalSaveModel.Zorgmijding,
                EersteDeelIndicatie = LocalSaveModel.EersteDeelIndicatie
            };

            return View(_localSaveModel);
        }

        [HttpPost]
        public ActionResult ShowResults(string _type)
        {
            LocalSaveModel.TweedeDeelIndicatie = _type;

            return new EmptyResult();
        }

        public ActionResult ShowResults()
        {
            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                DomeinBeschrijvingen1 = LocalSaveModel.DomeinBeschrijvingen1,
                DomeinBeschrijvingen2 = LocalSaveModel.DomeinBeschrijvingen2,
                DomeinBeschrijvingen3 = LocalSaveModel.DomeinBeschrijvingen3,
                DomeinBeschrijvingen4 = LocalSaveModel.DomeinBeschrijvingen4,
                DomeinBeschrijvingen5 = LocalSaveModel.DomeinBeschrijvingen5,
                DomeinBeschrijvingen6 = LocalSaveModel.DomeinBeschrijvingen6,
                Points = LocalSaveModel.Points,
                MateBeperking = LocalSaveModel.MateBeperking,
                Kinderen = LocalSaveModel.Kinderen,
                Zorgmijding = LocalSaveModel.Zorgmijding,
                EersteDeelIndicatie = LocalSaveModel.EersteDeelIndicatie,
                TweedeDeelIndicatie = LocalSaveModel.TweedeDeelIndicatie,
                Volwassene = LocalSaveModel.Volwassene
            };

            return View(_localSaveModel);
        }

        [HttpPost]
        public ActionResult AddToDomeinLocal(string _button, bool _buttonChecked)
        {
            var checkBox = db.checkBoxMaps.Where(c => c.checkBox_id.Equals(_button)).First();

            if(_buttonChecked)
            {
                if(checkBox.checkBox_id.Contains("vraag1"))
                    LocalSaveModel.DomeinBeschrijvingen1.Add(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag2"))
                    LocalSaveModel.DomeinBeschrijvingen2.Add(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag3"))
                    LocalSaveModel.DomeinBeschrijvingen3.Add(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag4"))
                    LocalSaveModel.DomeinBeschrijvingen4.Add(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag5"))
                    LocalSaveModel.DomeinBeschrijvingen5.Add(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag6"))
                    LocalSaveModel.DomeinBeschrijvingen6.Add(checkBox.beschrijving);

                LocalSaveModel.Points += checkBox.value;
            }
            else
            {
                if (checkBox.checkBox_id.Contains("vraag1"))
                    LocalSaveModel.DomeinBeschrijvingen1.Remove(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag2"))
                    LocalSaveModel.DomeinBeschrijvingen2.Remove(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag3"))
                    LocalSaveModel.DomeinBeschrijvingen3.Remove(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag4"))
                    LocalSaveModel.DomeinBeschrijvingen4.Remove(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag5"))
                    LocalSaveModel.DomeinBeschrijvingen5.Remove(checkBox.beschrijving);
                if (checkBox.checkBox_id.Contains("vraag6"))
                    LocalSaveModel.DomeinBeschrijvingen6.Remove(checkBox.beschrijving);

                LocalSaveModel.Points -= checkBox.value;
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult AddToExtraLocal(string _beperking, int _kinderenPoints, int _zorgmijdingPoints)
        {
            LocalSaveModel.MateBeperking = _beperking;

            switch (_beperking)
            {
                case "matig":
                    LocalSaveModel.Points += 1;
                    break;

                case "licht":
                    LocalSaveModel.Points += 2;
                    break;

                case "zwaar":
                    LocalSaveModel.Points += 3;
                    break;
            }

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
                LocalSaveModel.Points -= 3;
            }
            if (LocalSaveModel.Zorgmijding && _zorgmijdingPoints == 0)
            {
                LocalSaveModel.Points -= 3;
            }
            //END CALCULATE POINTS CHILDREN & CARE AVOIDANCE

            LocalSaveModel.Kinderen = _kinderenPoints == 0 ? false : true;
            LocalSaveModel.Zorgmijding = _zorgmijdingPoints == 0 ? false : true;

            return new EmptyResult();
        }

        public ActionResult CalculateFirst()
        {
            if(LocalSaveModel.Volwassene)
            { //volwassene
                if(LocalSaveModel.Points <= 91) //max = 181
                {
                    LocalSaveModel.EersteDeelIndicatie = 1;
                }
                else
                {
                    LocalSaveModel.EersteDeelIndicatie = 2;
                }
            }
            else
            { //jeugd
                if (LocalSaveModel.Points >= 134) //max = 178
                {
                    LocalSaveModel.EersteDeelIndicatie = 4;
                }
                else if (LocalSaveModel.Points >= 89 && LocalSaveModel.Points < 134)
                {
                    LocalSaveModel.EersteDeelIndicatie = 3;
                }
                else if (LocalSaveModel.Points >= 45 && LocalSaveModel.Points < 89)
                {
                    LocalSaveModel.EersteDeelIndicatie = 2;
                }
                else if (LocalSaveModel.Points >= 0 && LocalSaveModel.Points < 45)
                {
                    LocalSaveModel.EersteDeelIndicatie = 1;
                }
            }

            _LocalSaveModel _localSaveModel = new _LocalSaveModel
            {
                DomeinBeschrijvingen1 = LocalSaveModel.DomeinBeschrijvingen1,
                DomeinBeschrijvingen2 = LocalSaveModel.DomeinBeschrijvingen2,
                DomeinBeschrijvingen3 = LocalSaveModel.DomeinBeschrijvingen3,
                DomeinBeschrijvingen4 = LocalSaveModel.DomeinBeschrijvingen4,
                DomeinBeschrijvingen5 = LocalSaveModel.DomeinBeschrijvingen5,
                DomeinBeschrijvingen6 = LocalSaveModel.DomeinBeschrijvingen6,
                Points = LocalSaveModel.Points,
                MateBeperking = LocalSaveModel.MateBeperking,
                Kinderen = LocalSaveModel.Kinderen,
                Zorgmijding = LocalSaveModel.Zorgmijding,
                EersteDeelIndicatie = LocalSaveModel.EersteDeelIndicatie
            };

            return View("Eerste-deel-indicatie", _localSaveModel);
        }

        [HttpPost]
        public ActionResult ChangeNiv(int _niv)
        {
            LocalSaveModel.EersteDeelIndicatie = _niv;

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ChangeType(string _type)
        {
            LocalSaveModel.TweedeDeelIndicatie = _type;

            return new EmptyResult();
        }

        public ActionResult SaveClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveConfirm(string clientNummer, string voornaam, string achternaam, DateTime geboorteDatum, string commentaar)
        {
            DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

            clientnr = clientNummer;

            if (ModelState.IsValid)
            {
                Client client = new Client();

                var thisClient = db.Clients.Where(c => c.clientnummer == clientNummer);


                if (!thisClient.Any())
                {
                    client.clientnummer = clientNummer;
                    client.voornaam = voornaam;
                    client.achternaam = achternaam;
                    client.geboortedatum = geboorteDatum;
                    client.Behandelaar = User.Identity.GetUserId();

                    db.Clients.Add(client);
                }

                client2 = client;


                Result result = new Result();

                StringBuilder pickedBuilder = new StringBuilder();

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen1)
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

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen2)
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

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen3)
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

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen4)
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

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen5)
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

                foreach (var item in LocalSaveModel.DomeinBeschrijvingen6)
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
                result.commentaar = commentaar;
                result.Indication = ""+LocalSaveModel.EersteDeelIndicatie+" "+LocalSaveModel.TweedeDeelIndicatie+"";

                db.Results.Add(result);

                Formulier_tt formulier_tt = new Formulier_tt();

                if (db.Formulier_tt.Any(r => r.Clientnummer == client.clientnummer))
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

            return new EmptyResult();
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