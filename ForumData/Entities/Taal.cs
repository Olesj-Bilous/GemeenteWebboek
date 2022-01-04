using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Taal
    {
        public Taal() { }

        //public Taal(string code, string naam)
        //{
        //    TaalCode = code;
        //    TaalNaam = naam;
        //}

        public int TaalId { get; set; }
        public string TaalCode { get; set; }
        public string TaalNaam { get; set; }

        public virtual ICollection<Gemeente> Gemeenten { get; set; } = new List<Gemeente>();

        public virtual ICollection<Persoon> Personen { get; set; } = new List<Persoon>();
    }
}
