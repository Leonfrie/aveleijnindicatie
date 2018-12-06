using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLeegProject.Models
{
    public class LocalSaveModel
    {
        public static int? Points = 0;
        public static List<string> DomeinBeschrijvingen1 = new List<string>();
        public static List<string> DomeinBeschrijvingen2 = new List<string>();
        public static List<string> DomeinBeschrijvingen3 = new List<string>();
        public static List<string> DomeinBeschrijvingen4 = new List<string>();
        public static List<string> DomeinBeschrijvingen5 = new List<string>();
        public static List<string> DomeinBeschrijvingen6 = new List<string>();
        public static string MateBeperking;
        public static bool Kinderen;
        public static bool Zorgmijding;
        public static int EersteDeelIndicatie;
        public static string TweedeDeelIndicatie;
        public static bool Volwassene = false;
    }

    public class _LocalSaveModel
    {
        public int? Points;
        public List<string> DomeinBeschrijvingen1 = new List<string>();
        public List<string> DomeinBeschrijvingen2 = new List<string>();
        public List<string> DomeinBeschrijvingen3 = new List<string>();
        public List<string> DomeinBeschrijvingen4 = new List<string>();
        public List<string> DomeinBeschrijvingen5 = new List<string>();
        public List<string> DomeinBeschrijvingen6 = new List<string>();
        public string MateBeperking;
        public bool Kinderen;
        public bool Zorgmijding;
        public string Voornaam;
        public string Achternaam;
        public DateTime Geboortedatum;
        public string Clientnummer;
        public string Commentaar;
        public int EersteDeelIndicatie;
        public string TweedeDeelIndicatie;
        public bool Volwassene = false;
    }
}