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
    public class BerichtConfiguration : IEntityTypeConfiguration<Bericht>
    {
        public void Configure(EntityTypeBuilder<Bericht> builder)
        {
            builder.ToTable("Berichten");

            builder.HasKey(c => c.BerichtId);

            builder.Property(b => b.BerichtId)
                .ValueGeneratedOnAdd();

            builder.HasOne(b => b.HoofdBericht)
                .WithMany(c => c.OnderBerichten)
                .HasForeignKey(b => b.HoofdBerichtId);

            builder.HasOne(b => b.Profiel)
                .WithMany(c => c.Berichten)
                .HasForeignKey(b => b.ProfielId);

            builder.HasOne(b => b.BerichtType)
                .WithMany(c => c.Berichten)
                .HasForeignKey(b => b.BerichtTypeId);

            builder.Property(b => b.ProfielId)
                .IsRequired();

            builder.Property(b => b.BerichtTypeId)
                .IsRequired();

            builder.Property(b => b.BerichtTijdstip)
                .IsRequired();

            builder.Property(b => b.BerichtTitel)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.BerichtTekst)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
