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
                }
            );
        }
    }
}
