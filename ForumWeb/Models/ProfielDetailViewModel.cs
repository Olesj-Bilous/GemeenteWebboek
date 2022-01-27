using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class ProfielDetailViewModel
    {
        //Poperties meegeven voor attached
        public int PersoonId { get; set; }
        public int TaalId { get; set; }
        public int AdresId { get; set; }

        //Te veranderen waardes
        [Required]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string VoorNaam { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string FamilieNaam { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? TelefoonNr { get; set; }
        [DataType(DataType.Date)]
        public DateTime? GeboorteDatum { get; set; }
        public Geslacht Geslacht { get; set; }

        //ADRES
        public string straatNaam { get; set; }
        public string HuisNr { get; set; }
        public string? BusNr { get; set; }


        //USER DATA
        public string LoginNaam { get; set; }
        [DataType(DataType.Password)]
        public string LoginPaswoord { get; set; }
        public bool Geblokkeerd { get; set; }
        public int LoginTal { get; set; }
        public int LoginFaalTal { get; set; }
        
        //Profiel data
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string KennismakingTekst { get; set; }
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public DateTime? WoontHierSinds { get; set; }
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? BeroepTekst { get; set; }
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? FirmaNaam { get; set; }
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? WebsiteAdres { get; set; }
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? FacebookNaam { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdres { get; set; }

        //user data
        public DateTime? GoedkeuringTijdstip { get; set; }
        public DateTime AanmaakTijdstip { get; set; }
        public DateTime LaatstBijgewerkt { get; set; }
        public ICollection<ProfielInteresse> ProfielInteresses { get; set; }
    }
}
