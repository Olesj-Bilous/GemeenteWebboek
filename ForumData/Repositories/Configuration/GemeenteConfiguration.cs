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
    class GemeenteConfiguration : IEntityTypeConfiguration<Gemeente>
    {
        public void Configure(EntityTypeBuilder<Gemeente> builder)
        {
            builder.ToTable("Gemeenten");

            builder.HasKey(c => c.GemeenteId);

            builder.Property(b => b.GemeenteId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.GemeenteNaam)
                .HasDatabaseName("Idx_GemeenteNaam")
                .IsUnique();

            builder.Property(b => b.GemeenteNaam)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.PostCode)
                .IsRequired();

            builder.Property(b => b.ProvincieId)
                .IsRequired();

            builder.HasOne(b => b.Provincie)
                .WithMany(c => c.Gemeenten)
                .HasForeignKey(b => b.ProvincieId);

            builder.HasOne(b => b.HoofdGemeente)
                .WithMany(c => c.DeelGemeenten)
                .HasForeignKey(b => b.HoofdGemeenteId);

            builder.Property(b => b.TaalId)
                .IsRequired();

            builder.HasOne(b => b.Taal)
                .WithMany(c => c.Gemeenten)
                .HasForeignKey(b => b.TaalId);
        }
    }
}
