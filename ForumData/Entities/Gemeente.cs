using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Gemeente
    {
        public int GemeenteId { get; set; }
        public string GemeenteNaam { get; set; }

        public int PostCode { get; set; }

        public int ProvincieId { get; set; }
        public Provincie Provincie { get; set; }

        public int? HoofdGemeenteId { get; set; }
        public Gemeente HoofdGemeente { get; set; }
        public ICollection<Gemeente> DeelGemeenten { get; set; } = new List<Gemeente>();

        public int TaalId { get; set; }
        public Taal Taal { get; set; }

        public ICollection<Straat> Straten { get; set; } = new List<Straat>();

        public ICollection<Persoon> Personen { get; set; } = new List<Persoon>();

        public ICollection<Bericht> Berichten { get; set; } = new List<Bericht>();
    }
}
