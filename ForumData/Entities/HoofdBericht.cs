using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class HoofdBericht : Bericht
    {
        public string BerichtTitel { get; set; }

        //navigation properties
        //BerichtType
        public int BerichtThemaId { get; set; }
        public virtual BerichtThema BerichtThema { get; set; }

        //ChildAntwoorden
        public virtual ICollection<Antwoord> ChildAntwoorden { get; set; } = new List<Antwoord>();
    }
}
