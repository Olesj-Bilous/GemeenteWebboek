using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class PersoonDetailViewModel
    {
        //Personal data
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string FamilieNaam { get; set; }
        public string Straatnaam { get; set; }
        public string HuisNr { get; set; }
        public string? BusNr { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public string? TelefoonNr { get; set; }
        public DateTime? GeboorteDatum { get; set; }
        public Geslacht Geslacht { get; set; }

        //User data
        public string LoginNaam { get; set; }
        public bool Geblokkeerd { get; set; }
        public int LoginTal { get; set; }
        public int LoginFaalTal { get; set; }
    }
}
