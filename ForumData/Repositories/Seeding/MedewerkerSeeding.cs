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
                }
            );
        }
    }
}
