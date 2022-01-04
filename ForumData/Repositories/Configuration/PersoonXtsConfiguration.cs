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
    public class MedewerkerConfiguration : IEntityTypeConfiguration<Medewerker>
    {
        public void Configure(EntityTypeBuilder<Medewerker> builder)
        {
            builder.HasOne(b => b.Afdeling)
               .WithMany(c => c.Medewerkers)
               .HasForeignKey(b => b.AfdelingId);

            builder.Property(b => b.AfdelingId)
                .IsRequired();
        }
    }

    public class ProfielConfiguration : IEntityTypeConfiguration<Profiel>
    {
        public void Configure(EntityTypeBuilder<Profiel> builder)
        {
            builder.Property(b => b.KennismakingTekst)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(b => b.EmailAdres)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.BeroepTekst)
                .HasMaxLength(30);

            builder.Property(b => b.FirmaNaam)
                .HasMaxLength(30);

            builder.Property(b => b.WebsiteAdres)
                .HasMaxLength(50);

            builder.Property(b => b.FacebookNaam)
                .HasMaxLength(30);

            builder.Property(b => b.AanmaakTijdstip)
                .IsRequired();

            builder.Property(b => b.LaatstBijgewerkt)
                .IsRequired();
        }
    }
}
