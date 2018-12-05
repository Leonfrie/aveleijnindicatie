using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLeegProject.Models
{
    public class ResultVM
    {



        public string IndicatieB_id { get; set; }
        public string Wet { get; set; }
        public string Kenmerken_inwoner { get; set; }
        public string Doel_ondersteuning { get; set; }
        public string Ondersteuning { get; set; }

        public string IndicatieN_id { get; set; }
        public string GedragsProblematiek { get; set; }
        public string Context { get; set; }
        public string Escalatie { get; set; }
        public string Motivatie { get; set; }
        public string OndersteuningN { get; set; }
        public string Veranderingen { get; set; }



    }
}