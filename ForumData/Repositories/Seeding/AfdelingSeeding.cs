﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.Seeding
{
    public class AfdelingSeeding : IEntityTypeConfiguration<Afdeling>
    {
        public void Configure(EntityTypeBuilder<Afdeling> builder)
        {
            builder.HasData
            (
                new
                {
                    AfdelingId = 1,
                    AfdelingCode = "DEV",
                    AfdelingNaam = "Ontwikkeling",
                    AfdelingTekst = "Testen van de site"
                }
            );
        }
    }
}
