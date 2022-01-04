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
    public class BerichtTypeConfiguration : IEntityTypeConfiguration<BerichtType>
    {
        public void Configure(EntityTypeBuilder<BerichtType> builder)
        {
            builder.HasKey(c => c.BerichtTypeId);

            builder.Property(b => b.BerichtTypeId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.BerichtTypeCode)
                .HasDatabaseName("Idx_BerichtTypeCode")
                .IsUnique();

            builder.Property(b => b.BerichtTypeCode)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(b => b.BerichtTypeNaam)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
