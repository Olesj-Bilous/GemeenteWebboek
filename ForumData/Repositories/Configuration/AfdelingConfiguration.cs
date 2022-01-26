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
    public class AfdelingConfiguration : IEntityTypeConfiguration<Afdeling>
    {
        public void Configure(EntityTypeBuilder<Afdeling> builder)
        {
            builder.HasKey(c => c.AfdelingId);

            builder.Property(b => b.AfdelingId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.AfdelingCode)
                .HasDatabaseName("Idx_AfdelingCode")
                .IsUnique();

            builder.HasIndex(b => b.AfdelingNaam)
                .HasDatabaseName("Idx_AfdelingNaam")
                .IsUnique();

            builder.Property(b => b.AfdelingCode)
               .HasMaxLength(4)
               .IsRequired();

            builder.Property(b => b.AfdelingNaam)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(b => b.AfdelingTekst)
                .HasMaxLength(255);
        }
    }
}
