using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class ProfielStatusLijstViewModel
    {
        //persoondata
        public string Voornaam { get; set; }
        public string FamilieNaam { get; set; }

        //profielstatus
        public bool Goedgekeurd { get; set; } = false;
        public DateTime? GoedkeuringTijdstip { get; set; }
        public DateTime AanmaakTijdstip { get; set; }
    }
}
