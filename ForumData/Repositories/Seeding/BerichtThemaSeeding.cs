﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Seeding
{
    public class BerichtThemaSeeding : IEntityTypeConfiguration<BerichtThema>
    {
        public void Configure(EntityTypeBuilder<BerichtThema> builder)
        {
            builder.HasData
            (
                new
                {
                    BerichtTypeId = 1,
                    BerichtTypeCode = "AL",
                    BerichtTypeNaam = "Algemeen",
                    BerichtTypeTekst = "Wat je maar wilt"
                },
                new
                {
                    BerichtTypeId = 2,
                    BerichtTypeCode = "ID",
                    BerichtTypeNaam = "Idee",
                    BerichtTypeTekst = "Wat je maar bedenkt"
                },
                new
                {
                    BerichtTypeId = 3,
                    BerichtTypeCode = "AC",
                    BerichtTypeNaam = "Activiteit",
                    BerichtTypeTekst = "Wat je maar doet"
                }
            );
        }
    }
}