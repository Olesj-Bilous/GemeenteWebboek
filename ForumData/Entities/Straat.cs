using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Straat
    {
        public int StraatId { get; set; }
        public string StraatNaam { get; set; }
        public int GemeenteId { get; set; }
        public Gemeente Gemeente { get; set; }
        public ICollection<Adres> Adressen { get; set; } = new List<Adres>();
    }
}
