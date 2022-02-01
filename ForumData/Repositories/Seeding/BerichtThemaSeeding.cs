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
    public class BerichtThemaSeeding : IEntityTypeConfiguration<BerichtThema>
    {
        public void Configure(EntityTypeBuilder<BerichtThema> builder)
        {
            builder.HasData
            (
                new
                {
                    Id = 1,
                    Code = "AL",
                    Naam = "Algemeen",
                    Tekst = "Wat je maar wilt"
                },
                new
                {
                    Id = 2,
                    Code = "ID",
                    Naam = "Idee",
                    Tekst = "Wat je maar bedenkt"
                },
                new
                {
                    Id = 3,
                    Code = "AC",
                    Naam = "Activiteit",
                    Tekst = "Wat je maar doet"
                }
            );
        }
    }
}
