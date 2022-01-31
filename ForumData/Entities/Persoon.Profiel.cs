using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Profiel : Persoon
    {
        //opmerking: DataType annotations moeten in het ASP.NET project ForumWeb gebeuren,
        //in een ViewModel aldaar,
        //niet in een EntityFramework Core bibliotheek als ForumData (hier),
        //dit heeft hier geen effect

        //[DataType(DataType.Text)]
        public string KennismakingTekst { get; set; }
        
        //[DataType(DataType.Date)]
        public DateTime? WoontHierSinds { get; set; }
        #nullable enable
        
        //[DataType(DataType.Text)]
        public string? BeroepTekst { get; set; }

        //[DataType(DataType.Text)]
        public string? FirmaNaam { get; set; }
        
        //[DataType(DataType.Url)]
        public string? WebsiteAdres { get; set; }

        //[DataType(DataType.Text)]
        public string? FacebookNaam { get; set; }
        #nullable disable
        
        //[DataType(DataType.EmailAddress)]
        public string EmailAdres { get; set; }

        //[DataType(DataType.DateTime)]
        public DateTime? GoedkeuringTijdstip { get; set; }
        
        //[DataType(DataType.DateTime)]
        public DateTime AanmaakTijdstip { get; set; }
        
        //[DataType(DataType.DateTime)]
        public DateTime LaatstBijgewerkt { get; set; }

        //navigation properties
        public ICollection<ProfielInteresse> ProfielInteresses { get; set; } = new List<ProfielInteresse>();

        public ICollection<Antwoord> Antwoorden { get; set; } = new List<Antwoord>();
        public ICollection<HoofdBericht> HoofdBerichten { get; set; } = new List<HoofdBericht>();
    }
}
