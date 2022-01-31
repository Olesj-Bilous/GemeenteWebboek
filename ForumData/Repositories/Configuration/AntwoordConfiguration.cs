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
    public class AntwoordConfiguration : IEntityTypeConfiguration<Antwoord>
    {
        public void Configure(EntityTypeBuilder<Antwoord> builder)
        {
            //foreign keys
            builder.HasOne(b => b.HoofdBericht)
                .WithMany(c => c.ChildAntwoorden)
                .HasForeignKey(b => b.HoofdBerichtId);

            builder.HasOne(b => b.ParentAntwoord)
                .WithMany(c => c.ChildAntwoorden)
                .HasForeignKey(b => b.ParentAntwoordId);

            //required properties
            builder.Property(b => b.HoofdBerichtId)
                .IsRequired();
        }
    }
}
