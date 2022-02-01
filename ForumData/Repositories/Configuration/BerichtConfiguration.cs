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
    public class BerichtConfiguration : IEntityTypeConfiguration<Bericht>
    {
        public void Configure(EntityTypeBuilder<Bericht> builder)
        {
            builder.ToTable("Berichten");

            //primary key
            builder.HasKey(c => c.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            //discriminator
            builder.HasDiscriminator<string>("BerichtType")
                .HasValue<HoofdBericht>("H")
                .HasValue<Antwoord>("A");

            //foreign keys
            builder.HasOne(b => b.Profiel)
                .WithMany(c => c.Berichten)
                .HasForeignKey(b => b.ProfielId)
                .OnDelete(DeleteBehavior.Restrict);

            //required properties
            builder.Property(b => b.ProfielId)
                .IsRequired();

            builder.Property(b => b.BerichtTijdstip)
                .IsRequired();

            builder.Property(b => b.BerichtTekst)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
