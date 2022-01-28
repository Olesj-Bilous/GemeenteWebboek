using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }
        public string AfdelingCode { get; set; }
        public string AfdelingNaam { get; set; }
#nullable enable
        public string? AfdelingTekst { get; set; }
#nullable disable
        public ICollection<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();
    }
}
