using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public enum Geslacht { M, V }
    public abstract class Persoon
    {
        
        public int PersoonId { get; set; }

        [DataType(DataType.Text)]
        public string VoorNaam { get; set; }

        [DataType(DataType.Text)]
        public string FamilieNaam { get; set; }
        
        public Geslacht Geslacht { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? GeboorteDatum { get; set; }
        
        public int AdresId { get; set; }
        
        public Adres Adres { get; set; }
        
        public int? GeboortePlaatsId { get; set; }
        #nullable enable
        
        public Gemeente? GeboortePlaats { get; set; }
        
        public string? TelefoonNr { get; set; }
        #nullable disable
        
        public bool Geblokkeerd { get; set; } = false;
        
        public string LoginNaam { get; set; }
        
        [DataType(DataType.Password)]
        public string LoginPaswoord { get; set; }
        
        public int LoginFaalTal { get; set; } = 0;
        
        public int LoginTal { get; set; } = 0;
        
        public int TaalId { get; set; }
        
        public Taal Taal { get; set; }

        public byte[] Aangepast { get; set; }

    }
}
