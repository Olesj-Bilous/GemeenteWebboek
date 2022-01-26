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
    public class InteresseSeeding : IEntityTypeConfiguration<Interesse>
    {
        public void Configure(EntityTypeBuilder<Interesse> builder)
        {
            builder.HasData
            (
                new
                {
                    InteresseId = 1,
                    InteresseNaam = "Muziek spelen",
                },
                new
                {
                    InteresseId = 2,
                    InteresseNaam = "Muziek luisteren",
                },
                new
                {
                    InteresseId = 3,
                    InteresseNaam = "Wandelen",
                }
            );
        }
    }
}
