using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Antwoord : Bericht
    {        
        //navigation properties
        //HoofdBericht
        public int HoofdBerichtId { get; set; }
        public virtual HoofdBericht HoofdBericht { get; set; }

        //ParentAntwoord and ChildAntwoorden
        public int? ParentAntwoordId { get; set; }
        public Antwoord ParentAntwoord { get; set; }
        public virtual ICollection<Antwoord> ChildAntwoorden { get; set; } = new List<Antwoord>();
    }
}
