using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Profiel : Persoon
    {
        public string KennismakingTekst { get; set; }
        public DateTime? WoontHierSinds { get; set; }
#nullable enable
        public string? BeroepTekst { get; set; }
        public string? FirmaNaam { get; set; }
        public string? WebsiteAdres { get; set; }
        public string? FacebookNaam { get; set; }
#nullable disable
        public string EmailAdres { get; set; }

        public DateTime? GoedkeuringTijdstip { get; set; }
        public DateTime AanmaakTijdstip { get; set; }
        public DateTime LaatstBijgewerkt { get; set; }
        public virtual ICollection<ProfielInteresse> ProfielInteresses { get; set; } = new List<ProfielInteresse>();

        public virtual ICollection<Bericht> Berichten { get; set; } = new List<Bericht>();
    }
}
