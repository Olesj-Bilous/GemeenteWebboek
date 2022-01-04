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
    public class AdresConfiguration : IEntityTypeConfiguration<Adres>
    {
        public void Configure(EntityTypeBuilder<Adres> builder)
        {
            builder.ToTable("Adressen");

            builder.HasKey(c => c.AdresId);

            builder.Property(b => b.AdresId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => new { b.StraatId, b.HuisNr, b.BusNr })
                .HasDatabaseName("Idx_StraatIdEnHuisNrEnBusNr")
                .IsUnique();

            builder.Property(b => b.StraatId)
                .IsRequired();

            builder.Property(b => b.HuisNr)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(b => b.BusNr)
                .HasMaxLength(5);

            builder.HasOne(b => b.Straat)
                .WithMany(c => c.Adressen)
                .HasForeignKey(b => b.StraatId);

            builder.Property(a => a.Aangepast)
                .HasColumnType("timestamp");

            builder.Property(a => a.Aangepast)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
