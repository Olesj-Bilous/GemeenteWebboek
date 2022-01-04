using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Adres
    {
        public Adres() { }

        public Adres(Straat straat, string huisNr, string busNr)
        {
            Straat = straat;
            HuisNr = huisNr;
            BusNr = busNr;
        }

        public int AdresId { get; set; }
        public int StraatId { get; set; }
        public virtual Straat Straat { get; set; }
        public string HuisNr { get; set; }
#nullable enable
        public string? BusNr { get; set; }
#nullable disable
        public virtual ICollection<Persoon> Personen { get; set; } = new List<Persoon>();

        public byte[] Aangepast { get; set; }
    }
}
