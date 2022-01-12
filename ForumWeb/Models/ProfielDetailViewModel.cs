using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class ProfielDetailViewModel
    {
        //Personal data
        public string KennismakingTekst { get; set; }
        public DateTime? WoontHierSinds { get; set; }
        public string? BeroepTekst { get; set; }
        public string? FirmaNaam { get; set; }
        public string? WebsiteAdres { get; set; }
        public string? FacebookNaam { get; set; }
        public string EmailAdres { get; set; }

        //user data
        public DateTime? GoedkeuringTijdstip { get; set; }
        public DateTime AanmaakTijdstip { get; set; }
        public DateTime LaatstBijgewerkt { get; set; }
        public ICollection<ProfielInteresse> ProfielInteresses { get; set; }
    }
}
