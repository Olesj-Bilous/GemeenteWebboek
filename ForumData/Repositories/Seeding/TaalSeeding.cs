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
    public class TaalSeeding : IEntityTypeConfiguration<Taal>
    {
        public void Configure(EntityTypeBuilder<Taal> builder)
        {
            builder.HasData
            (
                new
                {
                    TaalId = 1,
                    TaalCode = "NL", 
                    TaalNaam = "Nederlands"
                },
                new
                {
                    TaalId = 2,
                    TaalCode = "FR",
                    TaalNaam = "Frans"
                },
                new { TaalId = 3, TaalCode = "en", TaalNaam = "Engels" }
            );
        }
    }
}
