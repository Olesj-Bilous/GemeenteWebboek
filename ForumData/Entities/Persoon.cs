using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public enum Geslacht { M, V }
    public abstract class Persoon
    {
        public int PersoonId { get; set; }
        public string VoorNaam { get; set; }
        public string FamilieNaam { get; set; }
        public Geslacht Geslacht { get; set; }
        public DateTime? GeboorteDatum { get; set; }
        public int AdresId { get; set; }
        public virtual Adres Adres { get; set; }
        public int? GeboortePlaatsId { get; set; }
        #nullable enable
        public virtual Gemeente? GeboortePlaats { get; set; }
        public string? TelefoonNr { get; set; }
        #nullable disable
        public bool Geblokkeerd { get; set; } = false;
        public string LoginNaam { get; set; }
        public string LoginPaswoord { get; set; }
        public int LoginFaalTal { get; set; } = 0;
        public int LoginTal { get; set; } = 0;
        public int TaalId { get; set; }
        public virtual Taal Taal { get; set; }

        public byte[] Aangepast { get; set; }

    }
}
