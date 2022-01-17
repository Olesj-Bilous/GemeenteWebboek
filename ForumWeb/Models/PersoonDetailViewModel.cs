using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class PersoonDetailViewModel
    {
        //Personal data
        public int Id { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage ="Max {1} teken voor {0}")]
        public string Voornaam { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string FamilieNaam { get; set; }
        public string Straatnaam { get; set; }
        public string HuisNr { get; set; }
        public string? BusNr { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? TelefoonNr { get; set; }
        [DataType(DataType.Date)]
        public DateTime? GeboorteDatum { get; set; }
        public Geslacht Geslacht { get; set; }

        //USER DATA
        public string LoginNaam { get; set; }
        [DataType(DataType.Password)]
        public string LoginPaswoord { get; set; }
        public bool Geblokkeerd { get; set; }
        public int LoginTal { get; set; }
        public int LoginFaalTal { get; set; }
    }
}
