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
    class ProfielInteresseConfiguration : IEntityTypeConfiguration<ProfielInteresse>
    {
        public void Configure(EntityTypeBuilder<ProfielInteresse> builder)
        {
            builder.ToTable("ProfielenInteresses");

            builder.HasKey(c => new { c.ProfielId, c.InteresseId });

            builder.HasOne(b => b.Profiel)
                .WithMany(c => c.ProfielInteresses)
                .HasForeignKey(b => b.ProfielId);

            builder.HasOne(b => b.Interesse)
                .WithMany(c => c.InteresseProfielen)
                .HasForeignKey(b => b.InteresseId);

            builder.Property(b => b.ProfielId)
                .IsRequired();

            builder.Property(b => b.InteresseId)
                .IsRequired();

            builder.Property(a => a.Aangepast)
                .HasColumnType("timestamp");

            builder.Property(a => a.Aangepast)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
