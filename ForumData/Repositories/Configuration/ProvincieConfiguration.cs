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
    public class ProvincieConfiguration : IEntityTypeConfiguration<Provincie>
    {
        public void Configure(EntityTypeBuilder<Provincie> builder)
        {
            builder.HasKey(c => c.ProvincieId);

            builder.Property(b => b.ProvincieId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.ProvincieCode)
                .HasDatabaseName("Idx_ProvincieCode")
                .IsUnique();

            builder.Property(b => b.ProvincieCode)
                .HasMaxLength(3)
                .IsRequired();

            builder.HasIndex(b => b.ProvincieNaam)
                .HasDatabaseName("Idx_ProvincieNaam")
                .IsUnique();

            builder.Property(b => b.ProvincieNaam)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
