using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Seeding
{
    public class MedewerkerSeeding : IEntityTypeConfiguration<Medewerker>
    {
        public void Configure(EntityTypeBuilder<Medewerker> builder)
        {
            builder.HasData
            (
                new
                {
                    PersoonId = 1,
                    VoorNaam = "Jan",
                    FamilieNaam = "Jansen",
                    Geslacht = Geslacht.M,
                    GeboorteDatum = new DateTime(1980, 1, 1),
                    AdresId = 1,
                    TelefoonNr = "0477 77 77 77",
                    Geblokkeerd = false,
                    LoginNaam = "admin",
                    LoginPaswoord = "Adm!n1",
                    LoginFaalTal = 0,
                    LoginTal = 0,
                    TaalId = 1,
                    AfdelingId = 1
                },

                new Medewerker { 
                    PersoonId = 2, 
                    VoorNaam = "Piet", 
                    FamilieNaam = "Pieters", 
                    Geslacht = Geslacht.M,
                    GeboorteDatum = new DateTime(1981, 1, 1),
                    AdresId = 1, 
                    TaalId = 2, 
                    GeboortePlaatsId = 1790, 
                    TelefoonNr = "02/22222222", 
                    AfdelingId = 2, 
                    LoginNaam = "Piet", 
                    LoginPaswoord = "Baard", 
                    LoginTal = 0, 
                    LoginFaalTal = 0
                },
                 new Medewerker { 
                     PersoonId = 3,
                     VoorNaam = "Linda",
                     FamilieNaam = "Jorissens",
                     Geslacht = Geslacht.V,
                     GeboorteDatum = new DateTime(1982, 1, 1),
                     AdresId = 1,
                     TaalId = 2,
                     GeboortePlaatsId = 1810,
                     TelefoonNr = "03/33333333",
                     AfdelingId = 3,
                     LoginNaam = "Linda",
                     LoginPaswoord = "Baard",
                     LoginTal = 0,
                     LoginFaalTal = 0
                 },
                 new Medewerker { 
                     PersoonId = 4,
                     VoorNaam = "Korneel",
                     FamilieNaam = "Korneelissens",
                     Geslacht = Geslacht.M,
                     GeboorteDatum = new DateTime(1983, 1, 1),
                     AdresId = 1,
                     TaalId = 2,
                     GeboortePlaatsId = 8700,
                     TelefoonNr = "04/44444444",
                     AfdelingId = 1,
                     LoginNaam = "Korneel",
                     LoginPaswoord = "Baard",
                     LoginTal = 0,
                     LoginFaalTal = 0
                 }
            ) ;
        }
    }
}
