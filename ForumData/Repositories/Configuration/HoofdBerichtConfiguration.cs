using ForumData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Repositories.Configuration
{
    public class HoofdBerichtConfiguration : IEntityTypeConfiguration<HoofdBericht>
    {
        public void Configure(EntityTypeBuilder<HoofdBericht> builder)
        {
            //foreign keys
            builder.HasOne(b => b.BerichtThema)
                .WithMany(c => c.HoofdBerichten)
                .HasForeignKey(b => b.BerichtThemaId);

            //required properties
            builder.Property(b => b.BerichtTitel)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.BerichtThemaId)
                .IsRequired();
        }
    }
}
