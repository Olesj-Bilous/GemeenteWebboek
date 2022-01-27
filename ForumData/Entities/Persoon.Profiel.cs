using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Profiel : Persoon
    {
        [DataType(DataType.Text)]
        public string KennismakingTekst { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? WoontHierSinds { get; set; }
        #nullable enable
        
        [DataType(DataType.Text)]
        public string? BeroepTekst { get; set; }

        [DataType(DataType.Text)]
        public string? FirmaNaam { get; set; }
        
        [DataType(DataType.Url)]
        public string? WebsiteAdres { get; set; }

        [DataType(DataType.Text)]
        public string? FacebookNaam { get; set; }
        #nullable disable
        
        [DataType(DataType.EmailAddress)]
        public string EmailAdres { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? GoedkeuringTijdstip { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime AanmaakTijdstip { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime LaatstBijgewerkt { get; set; }
        
        public virtual ICollection<ProfielInteresse> ProfielInteresses { get; set; } = new List<ProfielInteresse>();
        public virtual ICollection<Bericht> Berichten { get; set; } = new List<Bericht>();
    }
}
