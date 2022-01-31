using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Configuration
{
    public class InteresseConfiguration : IEntityTypeConfiguration<Interesse>
    {
        public void Configure(EntityTypeBuilder<Interesse> builder)
        {
            builder.HasKey(c => c.InteresseId);

            builder.Property(b => b.InteresseId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.InteresseNaam)
                .HasDatabaseName("Idx_InteresseNaam")
                .IsUnique();

            builder.Property(b => b.InteresseNaam)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
