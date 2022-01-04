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
    public class StraatSeeding : IEntityTypeConfiguration<Straat>
    {
        public void Configure(EntityTypeBuilder<Straat> builder)
        {
            builder.HasData
            (
                new 
                {
                    StraatId = 1,
                    StraatNaam = "Fantasieweg",
                    GemeenteId = 1
                },
                new
                {
                    StraatId = 2,
                    StraatNaam = "Westlaan",
                    GemeenteId = 2
                },
                new 
                { 
                    StraatId = 3,
                    StraatNaam = "Oostlaan",
                    GemeenteId = 3
                },
                new
                {
                    StraatId = 4,
                    StraatNaam = "Droomsteegje",
                    GemeenteId = 4
                },
                new 
                { 
                    StraatId = 5,
                    StraatNaam = "Fictielaan",
                    GemeenteId = 5
                }
            );
        }
    }
}
