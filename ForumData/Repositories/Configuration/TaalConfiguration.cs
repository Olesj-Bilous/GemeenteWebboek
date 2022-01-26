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
    public class TaalConfiguration : IEntityTypeConfiguration<Taal>
    {
        public void Configure(EntityTypeBuilder<Taal> builder)
        {
            builder.ToTable("Talen");

            builder.HasKey(c => c.TaalId);

            builder.Property(b => b.TaalId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.TaalCode)
                .HasDatabaseName("Idx_TaalCode")
                .IsUnique();

            builder.HasIndex(b => b.TaalNaam)
                .HasDatabaseName("Idx_TaalNaam")
                .IsUnique();

            builder.Property(b => b.TaalCode)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(b => b.TaalNaam)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
