using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.Configuration
{
    public class StraatConfiguration : IEntityTypeConfiguration<Straat>
    {
        public void Configure(EntityTypeBuilder<Straat> builder)
        {
            builder.ToTable("Straten");

            builder.HasKey(c => c.StraatId);

            builder.Property(b => b.StraatId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.StraatNaam)
                .HasDatabaseName("Idx_StraatNaam")
                .IsUnique();

            builder.HasIndex(b => new { b.StraatNaam, b.GemeenteId })
                .HasDatabaseName("Idx_StraatNaamEnGemeente")
                .IsUnique();

            builder.Property(b => b.StraatNaam)
                .IsRequired();

            builder.Property(b => b.GemeenteId)
                .IsRequired();

            builder.HasOne(b => b.Gemeente)
                .WithMany(c => c.Straten)
                .HasForeignKey(b => b.GemeenteId);
        }
    }
}
