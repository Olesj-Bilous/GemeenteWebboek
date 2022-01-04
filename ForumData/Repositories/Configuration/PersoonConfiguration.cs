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
    public class PersoonConfiguration : IEntityTypeConfiguration<Persoon>
    {
        public void Configure(EntityTypeBuilder<Persoon> builder)
        {
            builder.ToTable("Personen");

            builder.HasKey(c => c.PersoonId);

            builder.Property(b => b.PersoonId)
                .HasMaxLength(2)
                .ValueGeneratedOnAdd();

            builder.HasDiscriminator<string>("PersoonType")
                .HasValue<Medewerker>("M")
                .HasValue<Profiel>("P");

            builder.HasIndex(b => b.LoginNaam)
                .HasDatabaseName("Idx_LoginNaam")
                .IsUnique();

            builder.HasOne(b => b.Adres)
                .WithMany(c => c.Personen)
                .HasForeignKey(b => b.AdresId);

            builder.HasOne(b => b.GeboortePlaats)
                .WithMany(c => c.Personen)
                .HasForeignKey(b => b.GeboortePlaatsId);

            builder.HasOne(b => b.Taal)
                .WithMany(c => c.Personen)
                .HasForeignKey(b => b.TaalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(b => b.VoorNaam)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.FamilieNaam)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(b => b.LoginNaam)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(b => b.LoginPaswoord)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(b => b.Geslacht)
                .IsRequired();

            builder.Property(b => b.AdresId)
                .IsRequired();

            builder.Property(b => b.Geblokkeerd)
                .IsRequired();

            builder.Property(b => b.LoginFaalTal)
                .IsRequired();

            builder.Property(b => b.LoginTal)
                .IsRequired();

            builder.Property(b => b.TaalId)
                .IsRequired();

            builder.Property(a => a.Aangepast)
                .HasColumnType("timestamp");

            builder.Property(a => a.Aangepast)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
