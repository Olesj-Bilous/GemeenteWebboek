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
    public class BerichtThemaConfiguration : IEntityTypeConfiguration<BerichtThema>
    {
        public void Configure(EntityTypeBuilder<BerichtThema> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.Code)
                .HasDatabaseName("Idx_Code")
                .IsUnique();

            builder.Property(b => b.Code)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(b => b.Naam)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
