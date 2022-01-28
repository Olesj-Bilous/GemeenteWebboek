﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Bericht
    {
        public Bericht() { }
        public Bericht(BerichtType type, Profiel profiel, DateTime datum, string titel, string tekst)
        {
            BerichtType = type;
            Profiel = profiel;
            BerichtTijdstip = datum;
            BerichtTitel = titel;
            BerichtTekst = tekst;
        }
        public int BerichtId { get; set; }
        public int? HoofdBerichtId { get; set; }
        public Bericht HoofdBericht { get; set; }
        public int ProfielId { get; set; }
        public Profiel Profiel { get; set; }
        public int BerichtTypeId { get; set; }
        public BerichtType BerichtType { get; set; }
        public DateTime BerichtTijdstip { get; set; }
        public string BerichtTitel { get; set; }
        public string BerichtTekst { get; set; }
        public ICollection<Bericht> OnderBerichten { get; set; } = new List<Bericht>();
    }
}
