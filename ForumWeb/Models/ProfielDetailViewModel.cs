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
        //PROPERTIES VOOR ATTACHED
        public int PersoonId { get; set; }
        public int TaalId { get; set; }
        public int AdresId { get; set; }

        //Te veranderen waardes
        [Required]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string VoorNaam { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string FamilieNaam { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string? TelefoonNr { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? GeboorteDatum { get; set; }
        
        public Geslacht Geslacht { get; set; }

        //ADRES
        [DataType(DataType.Text)]
        public string straatNaam { get; set; }
        
        [DataType(DataType.Text)]
        public string HuisNr { get; set; }

        [DataType(DataType.Text)]
        public string? BusNr { get; set; }


        //USER DATA
        [DataType(DataType.Text)]
        public string LoginNaam { get; set; }
        
        [DataType(DataType.Password)]
        public string LoginPaswoord { get; set; }
        
        public bool Geblokkeerd { get; set; }
        
        public int LoginTal { get; set; }
        
        public int LoginFaalTal { get; set; }

        //PROFIEL DATA
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string KennismakingTekst { get; set; }

        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public DateTime? WoontHierSinds { get; set; }

        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? BeroepTekst { get; set; }

        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? FirmaNaam { get; set; }

        [DataType(DataType.Url)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? WebsiteAdres { get; set; }

        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Max {1} teken voor {0}")]
        public string? FacebookNaam { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string EmailAdres { get; set; }

        //user data
        [DataType(DataType.DateTime)]
        public DateTime? GoedkeuringTijdstip { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AanmaakTijdstip { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LaatstBijgewerkt { get; set; }
        
        public ICollection<ProfielInteresse> ProfielInteresses { get; set; }
    }
}
