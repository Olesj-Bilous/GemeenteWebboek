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
    public class GemeenteSeeding : IEntityTypeConfiguration<Gemeente>
    {
        public void Configure(EntityTypeBuilder<Gemeente> builder)
        {
            builder.HasData
            (
                new 
                {
                    GemeenteId = 1,
                    GemeenteNaam = "Gent", 
                    PostCode = 9000,
                    ProvincieId = 1,
                    HoofdGemeenteId = new Nullable<int>(),
                    TaalId = 1
                },
                new
                {
                    GemeenteId = 2,
                    GemeenteNaam = "West-Gent",
                    PostCode = 9010,
                    ProvincieId = 1,
                    HoofdGemeenteId = 1,
                    TaalId = 1
                },
                new
                {
                    GemeenteId = 3,
                    GemeenteNaam = "Oost-Gent",
                    PostCode = 9020,
                    ProvincieId = 1,
                    HoofdGemeenteId = 1,
                    TaalId = 1
                },
                new
                {
                    GemeenteId = 4,
                    GemeenteNaam = "Drongen",
                    PostCode = 9001,
                    ProvincieId = 1,
                    HoofdGemeenteId = 2,
                    TaalId = 1
                },
                new
                {
                    GemeenteId = 5,
                    GemeenteNaam = "Gentbrugge",
                    PostCode = 9002,
                    ProvincieId = 1,
                    HoofdGemeenteId = 3,
                    TaalId = 1
                },
                new
                {
                    GemeenteId = 6,
                    GemeenteNaam = "Oost-Gentbrugge",
                    PostCode = 9102,
                    ProvincieId = 1,
                    HoofdGemeenteId = 5,
                    TaalId = 1
                }
            );
        }
    }
}
