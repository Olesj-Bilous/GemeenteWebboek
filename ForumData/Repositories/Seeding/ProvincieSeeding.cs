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
    public class ProvincieSeeding : IEntityTypeConfiguration<Provincie>
    {
        public void Configure(EntityTypeBuilder<Provincie> builder)
        {
            builder.HasData
            (
                new
                {
                    ProvincieId = 1,
                    ProvincieNaam = "Oost-Vlaanderen", 
                    ProvincieCode = "OVL"
                },
                new  { ProvincieId = 2, ProvincieCode = "LIM", ProvincieNaam = "Limburg" },
                new  { ProvincieId = 3, ProvincieCode = "ANT", ProvincieNaam = "Antwerpen" },
                new  { ProvincieId = 4, ProvincieCode = "VBR", ProvincieNaam = "Vlaams-Brabant" },
                new  { ProvincieId = 5, ProvincieCode = "WVL", ProvincieNaam = "West-Vlaanderen" },
                new  { ProvincieId = 6, ProvincieCode = "WBR", ProvincieNaam = "Waals-Brabant" },
                new  { ProvincieId = 7, ProvincieCode = "HEN", ProvincieNaam = "Henegouwen" },
                new  { ProvincieId = 8, ProvincieCode = "LUI", ProvincieNaam = "Luik" },
                new  { ProvincieId = 9, ProvincieCode = "LUX", ProvincieNaam = "Luxemburg" },
                new  { ProvincieId = 10, ProvincieCode = "NAM", ProvincieNaam = "Namen" },
                new  { ProvincieId = 11, ProvincieCode = "BRU", ProvincieNaam = "Brussel" }
            );
        }
    }
}
