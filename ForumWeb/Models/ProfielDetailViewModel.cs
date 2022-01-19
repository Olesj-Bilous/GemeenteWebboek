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
        //Personal data
        public int Id { get; set; }
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
