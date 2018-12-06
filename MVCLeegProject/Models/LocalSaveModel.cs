using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLeegProject.Models
{
    public class LocalSaveModel
    {
        public static int Points = 0;
        public static List<string> DomeinBeschrijvingen = new List<string>();
        public static string MateBeperking;
        public static bool Kinderen;
        public static bool Zorgmijding;
    }

    public class _LocalSaveModel
    {
        public int Points;
        public List<string> DomeinBeschrijvingen = new List<string>();
        public string MateBeperking;
        public bool Kinderen;
        public bool Zorgmijding;
    }
}