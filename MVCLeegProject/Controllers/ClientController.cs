using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLeegProject.Models;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace MVCLeegProject.Controllers
{
    public class ClientController : Controller
    {

        DB_A42A9B_Aveleijn2018Entities4 db = new DB_A42A9B_Aveleijn2018Entities4();

        // GET: Client
        public ActionResult Index()
        {
            if(db.Clients.ToList() == null)
            {
                return View();
            }
            else
            {
                return View(db.Clients.OrderBy(s => s.voornaam).ThenBy(s => s.achternaam));
            }
        }

        public ActionResult Search(string searchString)
        {
            if (db.Clients.ToList() == null)
            {
                return View();
            }
            else
            {

                if(!String.IsNullOrEmpty(searchString))
                {
                    return View(db.Clients.Where(v => v.voornaam.Contains(searchString) || v.achternaam.Contains(searchString)).ToList());
                }
                else
                {
                    return View(db.Clients.OrderBy(s => s.voornaam).ThenBy(s => s.achternaam));
                }
            }
        }


        public ActionResult CheckClient(string id)
        {
            if (id == "")
            {
                return RedirectToAction("Index");
            }

            Client client = db.Clients.Where(c => c.clientnummer == id).First();

            return View("CheckClient", client);
        }

        public ActionResult CheckLastClient()
        {
            string userid = User.Identity.GetUserId();
            Client client = db.Clients.Where(c => c.Behandelaar == userid).OrderByDescending(c => c.clientnummer).First();

            List<Client> clients = new List<Client>();

            //foreach(var item in client)
            //{
            //    clients.Add(item);
            //}


            return View("CheckLastClient", client);
        }
    }
}