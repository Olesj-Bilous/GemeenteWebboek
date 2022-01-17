using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.Seeding
{
    public class ProfielSeeding : IEntityTypeConfiguration<Profiel>
    {
        public void Configure(EntityTypeBuilder<Profiel> builder)
        {
            builder.HasData
                (

                    new Profiel
                    {
                        //persoon gegevens
                        PersoonId = 6,
                        VoorNaam = "Dummy",
                        FamilieNaam = "Tester",
                        Geslacht = Geslacht.V,
                        GeboorteDatum = new DateTime(1984, 01, 10),
                        AdresId= 1,
                        GeboortePlaatsId = 1732,
                        TelefoonNr = "124578910",
                        LoginNaam = "Dummy",
                        LoginPaswoord = "Tester",
                        TaalId = 3,
                        WoontHierSinds = new DateTime(1900, 01, 20),
                        //profiel gegevens
                        KennismakingTekst = "Hallo ik ben een Dummy profiel",
                        BeroepTekst = "Ik speel graag dummy",
                        FirmaNaam = "TheDummyFactory",
                        WebsiteAdres = "Dummy.dom",
                        EmailAdres = "Huh?@dom.com",
                        FacebookNaam = "DummyTester",
                        AanmaakTijdstip = DateTime.Now,
                        GoedkeuringTijdstip = DateTime.Now,
                        LaatstBijgewerkt = DateTime.Now,
                    },
                    new Profiel
                    {
                        //persoon gegevens
                        PersoonId = 7,
                        VoorNaam = "Marie",
                        FamilieNaam = "HeiligeGeest",
                        Geslacht = Geslacht.V,
                        GeboorteDatum = new DateTime(1500, 06,16 ),
                        AdresId = 1,
                        GeboortePlaatsId = 8700,
                        TelefoonNr = "666-666-666",
                        LoginNaam = "Marie",
                        LoginPaswoord = "HeiligeGeest",
                        TaalId = 3,
                        WoontHierSinds = new DateTime(1510, 11, 20),
                        //profiel gegevens
                        KennismakingTekst = "De heilige geest daalt nere",
                        BeroepTekst = "Plesair du dieu",
                        FirmaNaam = "Kerk fabriek",
                        WebsiteAdres = "kerk.com",
                        EmailAdres = "wijnwater@kerk.com",
                        FacebookNaam = "MarieMoederVanJezus",
                        AanmaakTijdstip = new DateTime(2001,5,4),
                        GoedkeuringTijdstip = DateTime.Now,
                        LaatstBijgewerkt = DateTime.Now,
                    }

                );
        }
    }
}
