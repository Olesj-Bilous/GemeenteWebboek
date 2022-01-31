using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public abstract class Bericht
    {
        public int Id { get; set; }
        public DateTime BerichtTijdstip { get; set; }
        public string BerichtTekst { get; set; }

        //navigation properties
        //Profiel
        public int ProfielId { get; set; }
        public Profiel Profiel { get; set; }
    }
}
